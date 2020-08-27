using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedDepthSearch : MonoBehaviour
{
	public DSNode end;
	public DSNode begining;
	public DSNode last;
	public int profuncidad;
	public int profundidadMaxima;

	DSNode lookForDPSLimit(float data, DSNode node, int deep, int maxDeep)
	{
		node = begining;
		data = last.value;
		deep = profuncidad;
		maxDeep = profundidadMaxima;

		int _deep = deep;
		if (_deep <= maxDeep)
		{
			_deep++;
			if (!node) return null;

			if (node.value == data)
			{
				last = node;
				return node;
			}

			//Aqui se puede añadir a un stack
			for (int i = 0; i < node.vertex.Count; i++)
			{
				if (node.vertex[i])
					lookForDPSLimit(data, node.vertex[i], _deep, maxDeep);
				if (last.value == data)
				{
					_deep--;
					return last;
				}
			}
			//Aqui se borraría del stack

			return null;
		}

		return null;
	}

}
