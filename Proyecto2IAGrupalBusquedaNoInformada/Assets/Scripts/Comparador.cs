using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparador : MonoBehaviour
{
    public IterativeBreadthSearch ite;
    public BreadthSearch bre;
    public DepthSearch DFS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool compare(List<BSNode> one, List<BSNode> two)
    {

        if(one.Count == two.Count)
        {
            return true;
        }

        return false;
    }
    private void OnMouseDown()
    {
        if(compare(ite.UgandaKnukles, bre.UgandaKnukles) == false)
        {
            Debug.Log("ño");
        }
        else
        {
            Debug.Log("sim");
        }
    }
}
