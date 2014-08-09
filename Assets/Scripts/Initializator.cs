using UnityEngine;
using System.Collections;

public class Initializator : MonoBehaviour {

	public GameObject world;
	public GameObject monster;

	float time = 0f;
	// Use this for initialization
	void Awake () 
	{
		Globals.NodeManager = new NodeManager ();
		Debug.Log (@"NodeManager created");
	}

	void Start ()
	{
		Debug.Log (@"Init Finished");
	}


	void Update()
	{
		time += Time.deltaTime;
		if (time > 1f) {
			time -= 10000000f;
			StartGame();
			Instantiate(monster);
				}
		if (time > 3f) {


		}

	}

	void StartGame()
	{
		Instantiate (world);
	}
}
