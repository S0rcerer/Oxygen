using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Rigidbody2D player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		BoxCollider2D playerCollider = player.GetComponent<BoxCollider2D> ();
		if (other != playerCollider) {
			Destroy (gameObject);
		}
	}
}
