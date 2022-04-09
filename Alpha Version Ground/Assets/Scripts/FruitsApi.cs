using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsApi : MonoBehaviour
{
    public List<GameObject> fruits = new List<GameObject>();
    private Generator gen;
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject _applePref;
    List<GameObject> toDelete = new List<GameObject>();
    // Start is called before the first frame update
    public FruitsApi(GameObject _tree, GameObject applePref)
    {
        _applePref = applePref;
        tree = _tree;
        gen = tree.GetComponentInChildren<Generator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnFruit()
    {
        if (gen.growed != false)
        {
            fruits.Add(Instantiate(_applePref, gen.fruitPoints[Random.Range(0, gen.fruitPoints.Count - 1)], Quaternion.identity));
        }
    }
    private void DeleteApple(GameObject gm)
    {
        
        fruits[fruits.IndexOf(gm)] = fruits[fruits.Count-1];
        fruits[fruits.Count - 1] = gm;
        fruits.Remove(gm);
        fruits.Capacity -= 1;
    }
    public void fruitsGrowUp(float _level)
    {
        if (gen.growed != false)
        {
            if (fruits != null)
            {
                foreach (GameObject fruit in fruits)
                {

                    FruitL frL = fruit.GetComponent<FruitL>();
                    if (frL.isGrowed == false)
                        frL.Grow(_level);
                    else
                        toDelete.Add(fruit);
                }
                foreach(GameObject toDel in toDelete)
                {
                    DeleteApple(toDel);
                }
                toDelete = new List<GameObject>();
            }
        }
    }
}
