using UnityEngine;
using System.Collections;

public class MarineController : MonoBehaviour {

	public float Speed;
	public GameObject bullet;
	public GUIText text;

	public float fireRate = 0.000001f;
	private double nextFire = 0.0F;
	public int shotFrames;

	// Use this for initialization
	void Start () {
		shotFrames = 0;
	}

	void FixedUpdate ()
	{
		float x = Input.GetAxis("Horizontal") * Speed;
		float y = Input.GetAxis("Vertical") * Speed;
		rigidbody2D.velocity = new Vector2 (x, y);
		Quaternion rotation = transform.localRotation;
		rotation.z = getMouseFacing ();
		transform.localRotation = Quaternion.AngleAxis (getMouseFacing() - 90, Vector3.forward);
	}



	float getMouseFacing()
	{
		Vector2 marinePos = rigidbody2D.position;
		Vector2 worldCursorPosition = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float angle = Mathf.Atan2 ((worldCursorPosition.y - marinePos.y), (worldCursorPosition.x - marinePos.x));
		return (angle * Mathf.Rad2Deg);
	}

	Vector2 getMouseFacingVector()
	{
		Vector2 marinePos = rigidbody2D.position;
		Vector2 worldCursorPosition = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);

		return worldCursorPosition - marinePos;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {	
			nextFire = Time.time + fireRate;
			GameObject newBullet =  Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody2D>().velocity = getMouseFacingVector().normalized * 20.0f;

		}
	}
}
