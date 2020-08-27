using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidirectionalSearch<T> : MonoBehaviour
{

    public Queue<BSNode<T>> qv;
    public BSNode<T> padre = null;

    public BidirectionalSearch() { }
    public BidirectionalSearch(T data, int v)
    {
        if (padre == null)
        {
            padre = new BSNode<T>(data, v);
        }
    }

    void addEdge(T dataParend, T data, int cost)
    {
        BSNode<T> tmp = DSearch(dataParend);
        if (tmp != null && !dataParend.Equals(data))
        {
            if (DSearch(data).Equals(null))
            {
                tmp.adyacentes.Add(new BSNode<T>(data, 10000));
                tmp.costoAdyacentes.Add(cost);
            }
            else if (searchPadre(tmp, data).Equals(null))
            {
                tmp.adyacentes.Add(DSearch(data));
                tmp.costoAdyacentes.Add(cost);
            }
        }
    }

    BSNode<T> searchPadre(BSNode<T> head, T data)
    {
        BSNode<T> tmp = head;
        while (!tmp.Equals(null))
        {
            qv.Enqueue(tmp);
            if (tmp.visitado.Equals(false))
            {
                tmp.visitado = true;
                foreach (BSNode<T> adyacente in tmp.adyacentes)
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

    BSNode<T> search(T data)
    {
        Queue<BSNode<T>> qs = new Queue<BSNode<T>>();
        BSNode<T> tmp = padre;
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
                foreach (BSNode<T> adyacente in tmp.adyacentes)
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

    BSNode<T> DSearch(T data)
    {
        Stack<BSNode<T>> ss = new Stack<BSNode<T>>();
        BSNode<T> tmp = padre;
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
                foreach(BSNode<T> adyacente in tmp.adyacentes)
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
