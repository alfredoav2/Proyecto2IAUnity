using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BSNode : MonoBehaviour
{
    public float data;
    public float val = 100000;
    public bool visitado = false;
    public int levelx;
    public int levely;
    public BSNode padre;
    public List<BSNode> adyacentes = new List<BSNode>();
    public List<float> costoAdyacentes = new List<float>();
    public float getData()
    {
        return data;
    }
    public BSNode() { }
    public BSNode(float d, float v)
    {
        data = d;
        val = v;
    }
    ~BSNode() { }

    private void Start()
    {
        
    }
}
