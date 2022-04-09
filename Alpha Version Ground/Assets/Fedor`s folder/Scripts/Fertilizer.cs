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
            deleteFertilizers_Depletions(gameObject);
          
           
            
            
        }
    }
    private void OnTriggerEnter(Collider col)//Изменения получения MySoilFormationRef. Для этого добавил RigidBody в Префаб
    {
        if (col.GetComponent<SoilFormation>() != null)
        {
            MySoilFormationRef = col.gameObject;
        }
    }
    static public void deleteFertilizers_Depletions(GameObject del)
    {
        GameObject buffer;
        buffer = del;
        Fertilizer.Fertilizers_Depletions[Fertilizer.Fertilizers_Depletions.IndexOf(del)]= Fertilizer.Fertilizers_Depletions[Fertilizer.Fertilizers_Depletions.Count-1];
        Fertilizer.Fertilizers_Depletions[Fertilizer.Fertilizers_Depletions.Count - 1] = del;
        Fertilizer.Fertilizers_Depletions.Remove(del);
        Fertilizer.Fertilizers_Depletions.Capacity -= 1;
        Destroy(del);

    }
    private void deleteFertilizer(GameObject del)
    {
        
    }
}
