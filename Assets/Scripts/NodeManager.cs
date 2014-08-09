using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeManager
{
	List<Node> Nodes;

	public NodeManager ()
	{
		Nodes = new List<Node> ();
	}

	public void AddNode(Node node)
	{
		if (node != null) 
		{
			Nodes.Add (node);
			Debug.Log(@"Node (" + node.name + @") added");
		}

	}

	public Node SeekClosestNode(Vector2 point)
	{
		Node closestNode = null;
		float distance = float.MaxValue;
		foreach (Node node in Nodes) 
		{
			float d = ((Vector2)(node.transform.position) - point).magnitude;
			if (closestNode == null || d < distance) 
			{
				distance = d;
				closestNode = node;
				Debug.Log(@"New optimum: " + node.name);
			}
		}
		return closestNode;
	}
}
