using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSNode<T>
{
    public T value;
    public DSNode<T> parent;
    public List<DSNode<T>> vertex = new List<DSNode<T>>();
    public DSNode(T v)
    {
        value = v;
        vertex = new List<DSNode<T>>(); 
    }
    public DSNode(T v, int size)
    {
        value = v;
        vertex = new List<DSNode<T>>(size);
    }
    ~DSNode() { vertex.Clear(); }
}
