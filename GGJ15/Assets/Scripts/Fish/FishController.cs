﻿using UnityEngine;
using System.Collections;

public class FishController : MonoBehaviour {
	public float minVelocity = 1;
	public float maxVelocity = 5;

	public EdgeCollider2D tankWallTop;
	public EdgeCollider2D tankWallRight;
	public EdgeCollider2D tankWallBottom;
	public EdgeCollider2D tankWallLeft;

	private bool alive = true;

	// Use this for initialization
	void Start () {
		Debug.Log ("gagaga");
		float xV = Random.Range (minVelocity, maxVelocity);
		float yV = Random.Range (minVelocity, maxVelocity);
		rigidbody2D.velocity = new Vector2 (xV, yV);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (!alive) return;
		if (other == tankWallTop || other == tankWallBottom) {
			ReverseYVelocity ();
		} else if (other == tankWallLeft || other == tankWallRight) {
			ReverseXVelocity();
		}
	}

	void ReverseXVelocity() {
		rigidbody2D.velocity = new Vector2 (-1 * rigidbody2D.velocity.x, rigidbody2D.velocity.y);
	}

	void ReverseYVelocity() {
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -1 * rigidbody2D.velocity.y);
	}

	public void Die() {
		if (!alive) return;
		alive = false;
		rigidbody2D.velocity = new Vector2 (0, 0);
		rigidbody2D.gravityScale = 1;
	}
}
