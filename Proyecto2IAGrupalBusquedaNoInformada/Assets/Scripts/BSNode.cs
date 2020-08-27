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
    public BSNode padre;
    public List<BSNode> adyacentes;
    public List<float> costoAdyacentes;
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
        adyacentes = new List<BSNode>();
        costoAdyacentes = new List<float>();
    }
}
