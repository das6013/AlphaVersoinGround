using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraForming : MonoBehaviour
{
    [SerializeField] private List<GameObject> _allObjectsFizual;
    [SerializeField] private List<Color> _colorArray;
    [SerializeField] private List<Vector4> _dataCords;
    [SerializeField] private Material _marerial;
    [SerializeField] public List<float> radiusArray; 
    float changeColorDeplition;
    int counterColor = 0;
    [SerializeField] int counter = 0;
    private Color _colorDis;
    // Start is called before the first frame update
    void Start()
    {
        _allObjectsFizual = Fertilizer.Fertilizers_Depletions;
        counter = _allObjectsFizual.Count;

    }
 

    // Update is called once per frame
    void Update()
    {   if (counter > Fertilizer.Fertilizers_Depletions.Count)
        {
            setDefult(counter - 1);
           
            counter -= 1;
        }
        else if (counter < Fertilizer.Fertilizers_Depletions.Count)
              counter = Fertilizer.Fertilizers_Depletions.Count;


        visualGenerate(Fertilizer.Fertilizers_Depletions);
    }

 
    
    private void visualGenerate(List<GameObject> test)

    {
        int counterColor = 0;


        foreach (GameObject i in test)
        {


            if (i.GetComponent<Fertilizer>() != null)
            {
                changeColorDeplition = -i.GetComponent<Fertilizer>().mineralsReserve * 0.1f;
            }
            else if (i.GetComponent<Depletion>() != null)
            {
                changeColorDeplition = i.GetComponent<Depletion>().mineralsLack*0.35f;
            }

            _colorArray[counterColor] = new Color(changeColorDeplition * 0.3f, changeColorDeplition * 0.3f, changeColorDeplition * 0.3f, 1);
            if (i.GetComponent<Fertilizer>() != null)
            {
                radiusArray[counterColor] = i.GetComponent<Fertilizer>().radius * 0.1f;
            }
            else if (i.GetComponent<Depletion>() != null)
            {
                radiusArray[counterColor] = i.GetComponent<Depletion>().radius * 0.1f;
            }

            _dataCords[counterColor] = new Vector4(i.transform.position.x * 0.2f, i.transform.position.z * 0.2f, 0, 0);
            counterColor++;
        }
        _dataCords[counterColor] = new Vector4(100, 100, 0, 0);
        _colorArray[counterColor] = new Vector4(4, 4, 4, 4);
        radiusArray[counterColor] = 0.1f;
        _marerial.SetColorArray("_colorArray", _colorArray);
        _marerial.SetVectorArray("_vectorCords", _dataCords);
        _marerial.SetFloatArray("_radius", radiusArray);
    }
    public void setDefult(int num)
    {
        _dataCords[num] = new Vector4(0,0, 0, 0);
        radiusArray[num] = 0;
        _colorArray[num] = new Color(0, 0, 0, 0);
        _marerial.SetColorArray("_colorArray", _colorArray);
        _marerial.SetVectorArray("_vectorCords", _dataCords);
        _marerial.SetFloatArray("_radius", radiusArray);

    }
 

}