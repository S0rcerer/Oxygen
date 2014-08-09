using UnityEngine;
using System.Collections;

public class MarineController : MonoBehaviour {

	public float Speed;
	public GUIText text;
	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate ()
	{
		float x = Input.GetAxis("Horizontal") * Speed;
		float y = Input.GetAxis("Vertical") * Speed;
		rigidbody2D.velocity = new Vector2 (x, y);
		Quaternion rotation = transform.localRotation;
		rotation.z = getMouseFacing ();
		transform.rotation = Quaternion.AngleAxis (getMouseFacing() - 90, Vector3.forward);
	}

	float getMouseFacing()
	{
		Vector2 marinePos = rigidbody2D.position;
		Vector2 worldCursorPosition = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float angle = Mathf.Atan2 ((worldCursorPosition.y - marinePos.y), (worldCursorPosition.x - marinePos.x));
		return (angle * Mathf.Rad2Deg);
	}

	// Update is called once per frame
	void Update () {

	}
}
