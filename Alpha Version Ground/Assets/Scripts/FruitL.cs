using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitL : MonoBehaviour
{
    //[SerializeField]GameObject _objFruit;
    private FixedJoint fxJoint;
    private Rigidbody rb;
    float maxFruitScale = 0.4f;
    public bool isGrowed = false;
    void Start()
    {
        fxJoint = gameObject.GetComponent<FixedJoint>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private float LevelToAmount(float _level)
    {
        return (_level * maxFruitScale);
    }
    public void Grow(float level)
    {
        float _amount = LevelToAmount(level);
        if (gameObject.transform.localScale.x + _amount < maxFruitScale)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + _amount, gameObject.transform.localScale.y + _amount,
                gameObject.transform.localScale.z + _amount);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(maxFruitScale, maxFruitScale, maxFruitScale);
            Destroy(gameObject.GetComponent<FixedJoint>());
            isGrowed = true;
        }
        
    }
    void Update()
    {
        
    }
}
