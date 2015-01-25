using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public float maxSpeed = 2f;
	public float addSpeed = 25f;
	public bool canMove = true;
	public bool canSell = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove){
			float moveH = Input.GetAxis("Horizontal");
			flip (moveH);
			//Debug.Log(rigidbody2D.velocity.x <= maxSpeed);
			if(moveH > 0) {
				if(rigidbody2D.velocity.x <= maxSpeed)
					rigidbody2D.AddForce(new Vector2 (moveH * addSpeed, 0));
			}
			else if(moveH < 0) {
				if(rigidbody2D.velocity.x > -maxSpeed)
					rigidbody2D.AddForce(new Vector2 (moveH * addSpeed, 0));
			}
			else {
				rigidbody2D.velocity = Vector2.zero;
			}
		} else {
			rigidbody2D.velocity = Vector2.zero;
		}
	}

	void flip(float moveH)
	{
		if (moveH < 0)
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		else if (moveH > 0)
			transform.localEulerAngles = new Vector3 (0, 180, 0);
	}
}
