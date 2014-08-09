using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Rigidbody2D player;
	private float shotDistance = 50.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.magnitude > shotDistance) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(gameObject, 0.01f);
	}
}
