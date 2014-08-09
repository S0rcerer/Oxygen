using UnityEngine;
using System.Collections;

public class MarineController : MonoBehaviour {

	public float Speed;
	public GameObject bullet;
	private float o2;
	public GUIText o2text;
	public GUITexture o2BarValue;

	private bool stayOnOxygenStation;


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
		updateOxygen ();
		o2text.text = o2.ToString();
		if (Input.GetButton("Fire1") && Time.time > nextFire) {	
			nextFire = Time.time + fireRate;
			GameObject newBullet =  Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			newBullet.GetComponent<Bullet>().player = rigidbody2D;
			newBullet.GetComponent<Rigidbody2D>().velocity = getMouseFacingVector().normalized * 20.0f;

		}


	}

	void updateOxygen()
	{
		if (stayOnOxygenStation) {
			o2 += 1.0f;
			if (o2 > 100.0f) {
				o2 = 100.0f;
			}
		} else {
			o2 -= 0.05f;
			if (o2 < 0.0f) {
				o2 = 0.0f;
			}
		}

		o2BarValue.pixelInset = new Rect (-64.0f, -29.0f, 100.0f * o2/ 100.0f, 25.0f);


	}

	void OnTriggerExit2D(Collider2D other) {
		CircleCollider2D oxygenStationCollider = GameObject.FindGameObjectWithTag("OxygenStation").GetComponent<CircleCollider2D>();
		if (other == oxygenStationCollider) {
			stayOnOxygenStation = false;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		CircleCollider2D oxygenStationCollider = GameObject.FindGameObjectWithTag("OxygenStation").GetComponent<CircleCollider2D>();
		if (other == oxygenStationCollider) {
			stayOnOxygenStation = true;
		}

	}
}
