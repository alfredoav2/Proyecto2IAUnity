using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BSNode <T>
{
    T data;
    public int val = 100000;
    public bool visitado = false;
    public BSNode<T> padre;
    public List<BSNode<T>> adyacentes;
    public List<int> costoAdyacentes;
    public T getData()
    {
        return data;
    }
    public BSNode() { }
    public BSNode(T d, int v)
    {
        data = d;
        val = v;
    }
    ~BSNode() { }
}
