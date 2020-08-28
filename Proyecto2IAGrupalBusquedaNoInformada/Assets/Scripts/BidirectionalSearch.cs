using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidirectionalSearch : MonoBehaviour
{
	public DSNode Finish;
	public DSNode begining;
	public DSNode last;

	public DSNode lookForDPS(float data, DSNode node)
	{
		if (node.Equals(null)) return null;

		if (node.value.Equals(data))
		{
			last = node;
			return node;
		}

		//Aqui se puede añadir a un stack

		for (int i = 0; i < node.vertex.Count; i++)
		{
			if (!node.vertex[i].Equals(null))
				lookForDPS(data, node.vertex[i]);
			if (last.value.Equals(data))
				return last;
		}

		//Aqui se borraría del stack
		return null;
	}

	DSNode BiderectionalSearch(DSNode start, DSNode end)
	{
		start = begining;
		end = Finish;
		if (start && end && lookForDPS(end.value, start))
		{
			List<DSNode> pathToEnd = new List<DSNode>(); // Alfredo

			DSNode tmp;
			tmp = end;

			if (pathToEnd.Count <= 0)
			{
				while (tmp.value != start.value)
				{
					pathToEnd.Add(tmp);
					tmp = tmp.parent;
				}
			}
			if (lookForDPS(pathToEnd[pathToEnd.Count - 1].value, start))
			{
				tmp = pathToEnd[pathToEnd.Count - 1];
 
				return tmp;
			}

			return null;
		}
		return null;
	}
}
