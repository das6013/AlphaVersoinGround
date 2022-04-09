using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeCode : MonoBehaviour
{
    GeneratorApi genApi;
    FruitsApi fruitApi;
    [SerializeField] GameObject tr;
    [SerializeField] GameObject applePref;
    void Start()
    {
        genApi = new GeneratorApi(tr);
        fruitApi = new FruitsApi(tr, applePref);
    }
    public void ButGen(float _amount)
    {
        genApi.SetLevelOfGrow(_amount);
    }
    public void ButspawnFruit()
    {
        fruitApi.spawnFruit();
    }
    public void GrowFruits(float _amount)
    {
        fruitApi.fruitsGrowUp(_amount);
    }
    
}
