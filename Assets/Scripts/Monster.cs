using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour 
{

	Node targetNode = null;
	float maxVelocity = 4f;
	float HP;

	// Use this for initialization
	void Start () 
	{
		HP = 100.0f;
		if (targetNode == null && Globals.NodeManager != null) 
		{
			targetNode = Globals.NodeManager.SeekClosestNode((Vector2)transform.position);
			Debug.Log(@"Monster configured: " + targetNode.name);
		}
	}

	public void FaceTarget(Vector2 target)
	{
		transform.rotation = Quaternion.AngleAxis(Helpers.GetAngle((Vector2)transform.position, target) - 90, Vector3.forward);
	}

	void NodeCollision(Collider2D other)
	{
		targetNode = targetNode.NextNode;
	}

	// Update is called once per frame
	void Update () 
	{
		//this.transform.position = targetNode.transform.position;
		MoveByPath ();
	}

	public void MoveByPath()
	{
		if (targetNode != null) 
		{
			FaceTarget(targetNode.transform.position);
			Vector2 dir = targetNode.transform.position - transform.position;//FaceTarget((Vector2)targetNode.transform.position);
			//Vector2 distance = (Vector2)transform.position - (Vector2)targetNode.transform.position;
			//Vector2 offset = distance.normalized() * Time.deltaTime
			rigidbody2D.velocity = dir.normalized * maxVelocity;
			//rigidbody2D.velocity = new Vector2(10f, 10f);

		}
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log (@"Yay");
		if (other.CompareTag ("Bullet")) {
			Debug.Log("Buller");
			HP-=10.0f;
			if (HP < 0.0) {
				Destroy(gameObject);
			}
		} else {
			NodeCollision(other);
		}
	}

}
