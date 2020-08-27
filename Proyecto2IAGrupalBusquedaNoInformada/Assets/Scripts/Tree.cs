using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
	[SerializeField]
	public GameObject nodoDepthSearch;
	public DSNode root;
	public DSNode last;

	public Tree()
	{
		root = null;
		last = null;
	}
	public Tree(float data)
	{
		root = new DSNode(data);
		last = null;

	}
	public Tree(DSNode node)
	{
		root = node;
	}

	public DSNode searchDFSIterative(float data)
	{
		return lookforDPSIterative(data, root);
	}

	public DSNode searchDFS(float data)
	{
		return lookForDPS(data, root);
	}

	bool insert(float parent, float data)
	{
		DSNode tmp = lookForDPS(parent, root);

		if (tmp != null)
		{
			if (lookForDPS(data, root) != null)
				return false;
			DSNode nodo = Instantiate(nodoDepthSearch).GetComponent<DSNode>();
			tmp.vertex.Add(nodo);
			nodo.value = data;
			nodo.parent = tmp;
			return true;
		}
		else
		{
			return false;
		}
	}

	void erase(float data)
	{
		DSNode to_erase = searchDFS(data);

		if (!to_erase.Equals(null))
		{
			//Aqui puede haver un problema
			to_erase = null;
		}
	}

	DSNode lookforDPSIterative(float data, DSNode node)
	{
		if (node.Equals(null)) return null;

		//Aqui se puede añadir a un stack
		LinkedList<DSNode> visited = new LinkedList<DSNode>();
		Stack<DSNode> stack = new Stack<DSNode>();
		DSNode current = node;
		stack.Push(node);
		while (stack.Count > 0)
		{
			current = stack.Peek();
			stack.Pop();

			if (!visited.Contains(current))
			{
				//std::cout << current->value << " ";
				Debug.Log(current.value);
				visited.AddLast(current);

			}

			if (current.value.Equals(data))
			{
				return current;
			}

			for (int i = current.vertex.Count - 1; i >= 0; i--)
			{
				if (!visited.Contains(current.vertex[i]))
				{
					stack.Push(current.vertex[i]);
				}
			}
		}

		return null;
	}

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

	DSNode searchBFS(float data, DSNode start)
	{
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

	// Start is called before the first frame update
	void Start()
	{
        insert(0, 1);
        insert(0, 2);
        insert(0, 4);
        insert(0, 6);
        insert(4, 5);
        insert(0, 4);
        insert(4, 5);
        insert(0, 8);
        insert(1, 10);
        insert(4, 1);
        insert(4, 9);
        insert(10, 4);
        insert(10, 20);
        insert(5, 20);
        insert(20, 50);
        insert(20, 51);
        insert(10, 52);
        insert(10, 52);
        insert(5, 20);
        insert(9, 13);
        insert(13, 15);

        //Debug.Log(g.searchDFS(9).value);
    }

	// Update is called once per frame
	void Update()
	{

	}
}
