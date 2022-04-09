using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorApi : MonoBehaviour
{
    
    [SerializeField] GameObject tree;
    Generator gen;
    public bool isGrowed;
    public GeneratorApi(GameObject _tree)
    {
        tree = _tree;
        gen = tree.GetComponentInChildren<Generator>();
    }
    
    public void SetLevelOfGrow(float level)//range between 0 - 1
    {
        if (level > 0 && level <= 1)
        {
            int amount = (int)(level * 90);//hard coded 120 (in my opinion it's max distance from root that can be)
        
            gen.GrowUpOnAmount(amount);
        }
        else
        {
            Debug.LogError("Stop It: level < 0 or level > 1");
        }
        isGrowed = gen.growed;
    }
}
