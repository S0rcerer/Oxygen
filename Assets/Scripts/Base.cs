using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	Construction[,] constructions;
	Node[,] nodes;
	//BasePathfinder patfinder;

	// Use this for initialization
	void Start () {
	
	}

	public void InitBase()
	{
		constructions = new Construction[Globals.BaseSize, Globals.BaseSize];
		nodes = new Node[Globals.BaseSize, Globals.BaseSize];
	}

	public bool IsCellFree (int x, int y)
	{
		if (x > 0 && x < Globals.BaseSize-1) 
		{
			if (y > 0 && y < Globals.BaseSize-1) 
			{
				return constructions[x, y] == null;
			}
		}
		return false;
	}

	public void Build(Construction construction)
	{
		if (IsCellFree(construction.X, construction.Y))
		{
			constructions[construction.X, construction.Y] = construction;
		}

	}

	public void RefreshPaths()
	{

	}

	// Update is called once per frame
	void Update () {
	
	}
}
