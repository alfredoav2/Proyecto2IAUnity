using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DepthSearch : MonoBehaviour
{
	public DSNode root;
	public DSNode last;

	public DepthSearch()
	{
		root = null;
		last = null;
	}
	public DepthSearch(float data)
	{
		root = new DSNode(data);
		last = null;

	}
	public DepthSearch(DSNode node) 
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

		if (!tmp.Equals(null))
		{
			if (lookForDPS(data, root) != null)
				return false;
			DSNode newNode = new DSNode (data);
			tmp.vertex.Add(newNode);
			newNode.parent = tmp;
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

			for (int i = current.vertex.Count- 1; i >= 0; i--)
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
		DepthSearch g = new DepthSearch(0);
		g.insert(0, 1);
		g.insert(0, 2);
		g.insert(0, 4);
		g.insert(0, 6);
		g.insert(4, 5);
		g.insert(0, 4);
		g.insert(4, 5);
		g.insert(0, 8);
		g.insert(1, 10);
		g.insert(4, 1);
		g.insert(4, 9);
		g.insert(10, 4);
		g.insert(10, 20);
		g.insert(5, 20);
		g.insert(20, 50);
		g.insert(20, 51);
		g.insert(10, 52);
		g.insert(10, 52);
		g.insert(5, 20);
		g.insert(9, 13);
		g.insert(13, 15);

		Debug.Log(g.searchDFS(9).value);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
