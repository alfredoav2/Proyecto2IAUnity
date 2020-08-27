using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthSearch : MonoBehaviour
{
	public DSNode end;
	public DSNode begining;
	public DSNode searchBFS(float data, DSNode start)
	{
		data = end.value;
		start = begining;

		LinkedList<DSNode> visited = new LinkedList<DSNode>();
		Queue<DSNode> queue = new Queue<DSNode>();

		visited.AddLast(start);
		queue.Enqueue(start);

		while (queue.Count > 0)
		{
			start = queue.Peek();
			if (start.value.Equals(data)) return start;
			queue.Dequeue();

			for (int i = 0; i < start.vertex.Count; i++)
			{
				DSNode tmp = start.vertex[i];
				if (!visited.Contains(tmp))
				{
					visited.AddLast(tmp);
					queue.Enqueue(tmp);
				}
			}
		}

		return null;
	}
}
