using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraForming : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spheres;
    [SerializeField] private List<float> _coords;
    [SerializeField] private List<Color> _colorArray;
    [SerializeField] private List<Vector4> _data;
    private const string Pk = "_PointOffset";
    [SerializeField] private Texture2D _texture;
    [SerializeField] private Material _marerial;
    int random;
    private Color _colorDis;
    // Start is called before the first frame update
    void Start()
    {

        _data.Add(new Vector4(-0.4f, -0.3f,0,0));
        _data.Add(new Vector4(0.1f, 0.1f,0,0));
        _data.Add(new Vector4(0.1f,0.3f,0,0));
        
 
        _colorArray.Add(new Color(0.1f,0.1f,0.3f,1));
        _colorArray.Add(new Color(0.3f, 0.1f, 0.1f, 1));
        _colorArray.Add(new Color(0.1f, 0.3f, 0.1f, 1));
        _marerial.SetVectorArray("_vectorCoord", _data);
        _marerial.SetColorArray("_coolorArray", _colorArray);


    }

    // Update is called once per frame
    void Update()
    {
        _colorDis = new Color (_spheres[0].transform.position.x, _spheres[0].transform.position.y, _spheres[0].transform.position.z);
        _marerial.SetColor("_DistortColor", _colorDis);
       
    }
}
