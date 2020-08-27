using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterativeBreadthSearch : MonoBehaviour
{
    public int data;
    public BSNode nodusMaximus;
    List<BSNode> visited = new List<BSNode>();
    Stack stack = new Stack();


    // Start is called before the first frame update

    public BSNode IterativeBS(BSNode start,BSNode end)
    {
        BSNode current = nodusMaximus;
        stack.Push(nodusMaximus);
        if (!visited.Contains(current))
        {
            visited.Add(current);
        }

        if (current.val == end.data)
        {
            return current;
        }

        for (int i = current.adyacentes.Count; i >= 0; i--)
        {
            if (!visited.Contains(current.adyacentes[i]))
            {
                stack.Push(current.adyacentes[i]);
            }
        }
        return null;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
