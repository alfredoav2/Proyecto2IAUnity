using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidirectionalSearch : MonoBehaviour
{

    public Queue<BSNode> qv;
    public BSNode padre = null;

    public BidirectionalSearch() { }
    public BidirectionalSearch(float data, int v)
    {
        if (padre == null)
        {
            padre = new BSNode(data, v);
        }
    }

    void addEdge(float dataParend, float data, float cost)
    {
        BSNode tmp = DSearch(dataParend);
        if (tmp != null && !dataParend.Equals(data))
        {
            if (DSearch(data).Equals(null))
            {
                tmp.adyacentes.Add(new BSNode(data, 10000));
                tmp.costoAdyacentes.Add(cost);
            }
            else if (searchPadre(tmp, data).Equals(null))
            {
                tmp.adyacentes.Add(DSearch(data));
                tmp.costoAdyacentes.Add(cost);
            }
        }
    }

    BSNode searchPadre(BSNode head, float data)
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

    BSNode search(float data)
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

    BSNode DSearch(float data)
    {
        Stack<BSNode> ss = new Stack<BSNode>();
        BSNode tmp = padre;
        ss.Push(tmp);
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
                foreach(BSNode adyacente in tmp.adyacentes)
                if (adyacente.visitado != true)
                {
                    ss.Push(adyacente);
                }
            }
            else
            {
                ss.Pop();
            }
            if (ss.Peek().Equals(null))
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

    void resetVisitados()
    {
        while (qv.Count > 0)
        {
            qv.Peek().visitado = false;
            qv.Dequeue();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
