using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DepthSearch<T> : MonoBehaviour
{
	public DSNode<T> root;
	public DSNode<T> last;

	public DepthSearch()
	{
		root = null;
		last = null;
	}
	public DepthSearch(T data)
	{
		root = new DSNode<T>(data);
		last = null;

	}
	public DepthSearch(DSNode<T> node) 
	{
		root = node;
	}

	public DSNode<T> searchDFSIterative(T data)
	{
		return lookforDPSIterative(data, root);
	}

	public DSNode<T> searchDFS(T data)
	{
		return lookForDPS(data, root);
	}

	bool insert(T parent, T data)
	{
		DSNode<T> tmp = lookForDPS(parent, root);

		if (!tmp.Equals(null))
		{
			if (!lookForDPS(data, root).Equals(null))
				return false;
			DSNode<T> newNode = new DSNode<T>(data);
			tmp.vertex.Add(newNode);
			newNode.parent = tmp;
			return true;
		}
		else
		{
			return false;
		}
	}

	void erase(T data)
	{
		DSNode<T> to_erase = searchDFS(data);

		if (!to_erase.Equals(null))
		{
			//Aqui puede haver un problema
			to_erase = null;
		}
	}

	DSNode<T> lookforDPSIterative(T data, DSNode<T> node)
	{
		if (node.Equals(null)) return null;

		//Aqui se puede añadir a un stack
		LinkedList<DSNode<T>> visited = new LinkedList<DSNode<T>>();
		Stack<DSNode<T>> stack = new Stack<DSNode<T>>();
		DSNode<T> current = node;
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

	public DSNode<T> lookForDPS(T data, DSNode<T> node)
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

	DSNode<T> searchBFS(T data, DSNode<T> start)
	{
		LinkedList<DSNode<T>> visited = new LinkedList<DSNode<T>>();
		Queue<DSNode<T>> queue = new Queue<DSNode<T>>();

		visited.AddLast(start);
		queue.Enqueue(start);

		while (queue.Count > 0)
		{
			start = queue.Peek();
			if (start.value.Equals(data)) return start;
			queue.Dequeue();

			for (int i = 0; i < start.vertex.Count; i++)
			{
				DSNode<T> tmp = start.vertex[i];
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
