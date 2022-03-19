using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// #2 переделать на хит с колайдером
// #3 Добавить логику на случай если объет поднят и перемещён.
public class Decay : MonoBehaviour
{
    [SerializeField] private GameObject MySoilFormationRef;
    [SerializeField] private LayerMask SoilLayer;//для SoilFormationRef
    [SerializeField] private float SFRadius;//для SoilFormationRef
    private Vector3 SFCenter;//для SoilFormationRef
    private int SFFlag = 0;

    [SerializeField] private GameObject FertilizerPrefab;
    private void OnDrawGizmosSelected()//отрисовка OverlapSphere для GetMySoilFormationRef()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(SFCenter, SFRadius);
    }
    private void GetMySoilFormationRef()
    {
        // пределать Collider[] hitColliders = Physics.OverlapSphere(SFCenter, SFRadius, SoilLayer);
        foreach (Collider collider in hitColliders)
        {
            GameObject iterObjectHit = collider.gameObject;
            if (iterObjectHit != null)
            {
                if (iterObjectHit.GetComponent<SoilFormation>() != null)
                {
                    MySoilFormationRef = iterObjectHit;//вариант с GameObject, не с об. класса SoilFormation
                    SFFlag = 1;//пока ограничился одним, затем можно будет добавить логику для обновления привязки к слою земли.
                    Invoke("AddFertLogic", 5f);//Станет фертилайзером спустя ... сек. лежания на земле
                }
            }
        }
    }
    // Start is called before the first frame update
    private void AddFertLogic()
    {
        Vector3 position = transform.position;
        Instantiate(FertilizerPrefab, position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collider col)
    {
        //col.GetComponent())
    }
    // Update is called once per frame
    void Update() // #1 ненужный апдейт. колим в старте
    {
        SFCenter = transform.position;//для отрисовки сферы каста, затем убрать
        if (SFFlag == 0)//потом можно будет добавить смену этого флага
        {
            GetMySoilFormationRef();
        }
    }
}
