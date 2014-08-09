using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour 
{
	public Node NextNode = null;

	void Start()
	{
		RegisterNode ();
	}

	public void RegisterNode()
	{
		if (Globals.NodeManager != null) 
		{
			Globals.NodeManager.AddNode(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log (@"Yay0");
	}
}
