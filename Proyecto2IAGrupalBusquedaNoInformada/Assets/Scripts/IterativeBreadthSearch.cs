using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterativeBreadthSearch : MonoBehaviour
{
    public int data;
    public int dataStart;
    public BSNode nodusMaximus;
    public Graph graph;
    Stack stack = new Stack();
    public List<BSNode> UgandaKnukles = new List<BSNode>(); 
    // Start is called before the first frame update

    public BSNode IterativeBS(BSNode start, BSNode node)
    {

        if (!node) return null;

        //Aqui se puede añadir a un stack
        List<BSNode> visited = new List<BSNode>();
        Stack<BSNode> stack = new Stack<BSNode>();
        BSNode current = node;
        stack.Push(start);
        while (stack.Count > 0)
        {
            current = stack.Peek();
            stack.Pop();

            if (!visited.Contains(current))
            {
                visited.Add(current);
            }

            if (current.getData() == data)
            {
                //UgandaKnukles.Add(current);
                //Debug.Log(current.data);
                return current;
            }

            for (int i = current.adyacentes.Count - 1; i >= 0; i--)
            {
                if (!visited.Contains(current.adyacentes[i]))
                {
                    stack.Push(current.adyacentes[i]);
                    UgandaKnukles.Add(current.adyacentes[i]);
                    Debug.Log(current.adyacentes[i].data);
                }
            }
        }
        return null;
        //BSNode current = nodusMaximus;

        //stack.Push(nodusMaximus);
        //if (!visited.Contains(current))
        //{
        //    visited.Add(current);
        //}

        //if (current.val == end.data)
        //{
        //    return current;
        //}

        //for (int i = current.adyacentes.Count-1; i >= 0; i--)
        //{
        //    if (!visited.Contains(current.adyacentes[i]))
        //    {
        //        stack.Push(current.adyacentes[i]);
        //    }
        //}
        //return null;
    }
    void Start()
    {

        //IterativeBS(graph.search(dataStart), graph.search(data));
        //Debug.Log(IterativeBS(graph.search(dataStart), graph.search(data)).data);
    }
    private void OnMouseDown()
    {
        IterativeBS(graph.search(dataStart), graph.search(data));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
