using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    [SerializeField] private GameObject MySoilFormationRef;//если достаточно объекта (поидее да, т.к. используется только для сравнения -> можно просто число использовать)

    public float mineralsReserve;
    public float radius;

    public static List<GameObject> Fertilizers_Depletions = new List<GameObject>();//лист со всеми Fertilizer-s на сцене. Объекты типа GameObject
    private void Start()
    {
        Fertilizers_Depletions.Add(gameObject);//пополняем лист. При уничтожении объекта, объект из листа не удаляется ИМЕТЬ ВВИДУ
    }
    // Start is called before the first frame update
    void Update()
    {
        if (mineralsReserve < 0.25)
        {
            //Fertilizer.Fertilizers_Depletions.Remove(gameObject);
            Destroy(gameObject, .5f);//Тут его быть не должно, куда его переместить - пока не понятно
        }
    }
    private void OnTriggerEnter(Collider col)//Изменения получения MySoilFormationRef. Для этого добавил RigidBody в Префаб
    {
        if (col.GetComponent<SoilFormation>() != null)
        {
            MySoilFormationRef = col.gameObject;
        }
    }
}
