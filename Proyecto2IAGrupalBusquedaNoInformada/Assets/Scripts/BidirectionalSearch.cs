using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidirectionalSearch : MonoBehaviour
{

    public Queue<BSNode> qv = new Queue<BSNode>();
    public BSNode padre = null;

    public BidirectionalSearch() { }
    public BidirectionalSearch(float data, int v)
    {
        if (padre == null)
        {
            padre = new BSNode(data, v);
        }
    }

    public void addEdge(float dataParend, float data, float cost)
    {
        BSNode tmp = DSearch(dataParend);
        if (tmp != null && !dataParend.Equals(data))
        {
            if (DSearch(data) == null)
            {
                tmp.adyacentes.Add(new BSNode(data, 10000));
                tmp.costoAdyacentes.Add(cost);
            }
            else if (searchPadre(tmp, data) == null)
            {
                tmp.adyacentes.Add(DSearch(data));
                tmp.costoAdyacentes.Add(cost);
            }
        }
    }

    public BSNode searchPadre(BSNode head, float data)
    {
        BSNode tmp = head;
        while (!tmp.Equals(null))
        {
            qv.Enqueue(tmp);
            if (tmp.visitado.Equals(false))
            {
                tmp.visitado = true;
                foreach (BSNode adyacente in tmp.adyacentes)
                {
                    adyacente.visitado = true;
                    qv.Enqueue(adyacente);
                    if (adyacente.getData().Equals(data))
                    {
                        resetVisitados();
                        tmp = adyacente;
                        return tmp;
                    }
                }
                resetVisitados();
                return null;
            }
        }
        return null;
    }

    public BSNode search(float data)
    {
        Queue<BSNode> qs = new Queue<BSNode>();
        BSNode tmp = padre;
        while (!tmp.Equals(null))
        {
            qv.Enqueue(tmp);
            if (tmp.getData().Equals(data))
            {
                resetVisitados();
                return tmp;
            }
            else if (tmp.visitado != true)
            {
                tmp.visitado = true;
                foreach (BSNode adyacente in tmp.adyacentes)
                {
                    qs.Enqueue(adyacente);
                    qv.Enqueue(adyacente);
                }
            }
            if (qs.Peek().Equals(null))
            {
                resetVisitados();
                return null;
            }
            tmp = qs.Peek();
            qs.Dequeue();
        }
        return null;
    }

    public BSNode DSearch(float data)
    {
        Stack<BSNode> ss = new Stack<BSNode>();
        BSNode tmp = padre;
        ss.Push(tmp);
        if (ss.Count > 0)
        {
            while (tmp != null)
            {
                //cout << tmp->visitado << endl;
                tmp.getData();
                if (tmp.getData().Equals(data))
                {
                    resetVisitados();
                    return tmp;
                }
                else if (tmp.visitado != true)
                {
                    tmp.visitado = true;
                    qv.Enqueue(tmp);
                    ss.Pop();
                    foreach (BSNode adyacente in tmp.adyacentes)
                    {
                        if (adyacente.visitado != true)
                        {
                            ss.Push(adyacente);
                        }
                    }
                }
                else
                {
                    ss.Pop();
                }
                if (ss.Count<=0)
                {
                    resetVisitados();
                    //cout << "nop" << endl;
                    return null;
                }
                tmp = ss.Peek();
            }
            resetVisitados();
            return null;
        }
        return null;
    }

    public void resetVisitados()
    {
        if (qv.Count > 0)
        {
            while (qv.Count > 0)
            {
                qv.Peek().visitado = false;
                qv.Dequeue();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BidirectionalSearch gr = new BidirectionalSearch(0, 0);
        gr.addEdge(0, 1, 1);
        gr.addEdge(0, 2, 2);
        gr.addEdge(0, 8, 3);
        gr.addEdge(0, 3, 5);
        gr.addEdge(3, 5, 3);
        gr.addEdge(3, 4, 2);
        gr.addEdge(1, 4, 1);
        gr.addEdge(2, 4, 2);
        gr.addEdge(2, 1, 3);
        gr.addEdge(4, 6, 6);
        gr.addEdge(5, 6, 2);

        Debug.Log(gr.search(5).getData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
