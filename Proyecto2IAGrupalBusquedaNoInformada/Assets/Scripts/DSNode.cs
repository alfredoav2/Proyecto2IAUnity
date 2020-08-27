using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSNode : MonoBehaviour
{

    public float value;
    public DSNode parent;
    public List<DSNode> vertex = new List<DSNode>();
    public DSNode(float v)
    {
        value = v;
        vertex = new List<DSNode>(); 
    }
    public DSNode(float v, int size)
    {
        value = v;
        vertex = new List<DSNode>(size);
    }
    ~DSNode() { vertex.Clear(); }
}
