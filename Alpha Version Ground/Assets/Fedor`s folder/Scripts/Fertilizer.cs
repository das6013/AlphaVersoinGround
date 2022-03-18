using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Очень много того же самого
public class Fertilizer : MonoBehaviour
{
    [SerializeField] private GameObject MySoilFormationRef;//если достаточно объекта (поидее да, т.к. используется только для сравнения -> можно просто число использовать)
    [SerializeField] private LayerMask SoilLayer;
    public float mineralsReserve;
    public float radius;

    [SerializeField] private float SFRadius;
    private Vector3 SFCenter;
    private int SFFlag = 0;

    private void Destoyer()//Нужно удалить эту функцию, дестроейр переместить
    {
        if (mineralsReserve < 0.25)
        {
            Destroy(gameObject, .5f);
        }
    }
    private void OnDrawGizmosSelected()//отрисовка OverlapSphere для GetMySoilFormationRef()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(SFCenter, SFRadius);
    }
    private void GetMySoilFormationRef()//Изменить логику в соответсвии с Decay по аналогии с Depletion - получать SoilFormation при создании  объекта
    {
        Collider[] hitColliders = Physics.OverlapSphere(SFCenter, SFRadius, SoilLayer);
        foreach (Collider collider in hitColliders)
        {
            GameObject iterObjectHit = collider.gameObject;
            if (iterObjectHit != null)
            {
                if (iterObjectHit.GetComponent<SoilFormation>() != null)
                {
                    MySoilFormationRef = iterObjectHit;//вариант с GameObject, не с об. класса SoilFormation
                    SFFlag = 1;//пока ограничился одним, затем можно будет добавить логику для обновления привязки к слою земли.
                }
            }
        }
    }
    // Start is called before the first frame update
    void Update()
    {
        SFCenter = transform.position;//для отрисовки сферы каста, затем убрать
        Destoyer();
        if (SFFlag == 0)//потом можно будет добавить
        {
            GetMySoilFormationRef();
        }
    }
}
