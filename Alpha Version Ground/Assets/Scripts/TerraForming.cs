using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraForming : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spheres;
    [SerializeField] private List<Color> _colorArray;
    [SerializeField] private List<Vector4> _dataCords;
    [SerializeField] private Material _marerial;

    [SerializeField] private GameObject prefabCast;
    [SerializeField] private Vector3 _coordHit;
    [SerializeField] private Material _marerialRefresh;
    int counter=0;
    int counterColor = 0;
    private Color _colorDis;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        int counterColor = 0;
        foreach (GameObject i in _spheres)
        {
            i.GetComponent<Renderer>().material.color = new Color(i.transform.position.x, i.transform.position.y, i.transform.position.z,1);
            _colorArray[counterColor] = i.GetComponent<Renderer>().material.color;
            counterColor++;
        }
        _marerial.SetColorArray("_colorArray", _colorArray);

    }

    private void OnCollisionEnter(Collision collision)
    {
       
        _coordHit = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
        _spheres.Add(Instantiate(prefabCast, _coordHit+10*transform.up,Quaternion.Euler(0,0,0)));
        _dataCords[counter]= (new Vector4(_coordHit.x, _coordHit.z, 0, 0));
        _colorArray[counter]=(_spheres[_spheres.Count - 1].GetComponent<Renderer>().material.color);        
        _marerial.SetColorArray("_colorArray", _colorArray);
        _marerial.SetVectorArray("_vectorCords", _dataCords);
        counter++;


    }
    private void newCord()
    { 
    }
}