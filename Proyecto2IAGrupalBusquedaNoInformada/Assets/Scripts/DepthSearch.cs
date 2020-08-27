using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DepthSearch : MonoBehaviour
{
	public DSNode end;
	public DSNode begining;
	public DSNode last;
	public DSNode lookForDPS(float data, DSNode node)
	{
		data = end.value;
		node = begining;

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
}
