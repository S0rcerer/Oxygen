using UnityEngine;
using System.Collections;

public delegate void Action(Collision2D collision);

public class NodeCollider : MonoBehaviour {

	public event Action OnColl;

	void Start()
	{
		Debug.Log (@"NodeCollider ready. Parent: " + transform.parent);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		OnColl (collision);
		Debug.Log (@"yay");
	}

}
