using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthSearch : MonoBehaviour
{
	public Graph graph;
	public int endValue;
	public int beginingValue;
	public BSNode end;
	public BSNode begining;
	public List<BSNode> UgandaKnukles = new List<BSNode>();
	public BSNode searchBFS(float data, BSNode start)
	{
		LinkedList<BSNode> visited = new LinkedList<BSNode>();
		Queue<BSNode> queue = new Queue<BSNode>();

		//data = endValue;
		//start = begining;

		

		visited.AddLast(start);
		queue.Enqueue(start);

		while (queue.Count > 0)
		{
			start = queue.Peek();
			if (start.getData().Equals(data)) return start;
			queue.Dequeue();

			for (int i = 0; i < start.adyacentes.Count; i++)
			{
				BSNode tmp = start.adyacentes[i];

				if (!visited.Contains(tmp))
				{
					visited.AddFirst(tmp);
					queue.Enqueue(tmp);
					UgandaKnukles.Add(tmp);
					Debug.Log("lol " + tmp.data);
				}
			}
		}

		return null;
	}
    private void Start()
    {
		//searchBFS(endValue, begining);
	
	}

    private void OnMouseDown()
    {
		Debug.Log(searchBFS(endValue, begining).data);
	}
}
