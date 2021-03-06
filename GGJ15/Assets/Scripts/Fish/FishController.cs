﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class FishController : MonoBehaviour {
	public float minVelocity = 1;
	public float maxVelocity = 5;
	public float scatterActivationDistance = 6;

	public EdgeCollider2D tankWallTop;
	public EdgeCollider2D tankWallRight;
	public EdgeCollider2D tankWallBottom;
	public EdgeCollider2D tankWallLeft;

	public UnityAction deathHandler;

	public Sprite deadFishSprite;

	private bool alive = true;

	public void Move() {
		GetComponent<Rigidbody2D>().velocity = RandomVelocity ();
	}

	public void Stop() {
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	public void Die() {
		if (!alive) return;
		alive = false;

		// apply gravity
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
		GetComponent<Rigidbody2D>().gravityScale = 1;
		GetComponent<Rigidbody2D>().isKinematic = false;

		SpriteRenderer r = GetComponent<SpriteRenderer> ();
		r.sprite = deadFishSprite;

		// prevent further interaction
		Destroy (GetComponent<BoxCollider2D> ());
		deathHandler ();
	}

	public void Scatter(Vector2 source) {
		if (!alive || Vector2.Distance(transform.position, source) > scatterActivationDistance) return;
		Vector2 newDirection = (Vector2)transform.position - source;
		Vector2 newVelocity = Random.Range (minVelocity, maxVelocity) * newDirection.normalized;
		GetComponent<Rigidbody2D>().velocity = newVelocity;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (!alive) return;
		if (other == tankWallTop || other == tankWallBottom) {
			ReverseYVelocity ();
		} else if (other == tankWallLeft || other == tankWallRight) {
			ReverseXVelocity();
		}
	}

	// helpers

	Vector2 RandomVelocity() {
		float xV = Random.Range (minVelocity, maxVelocity);
		float yV = Random.Range (minVelocity, maxVelocity);
		xV = Random.value > 0.5 ? xV : -1 * xV;
		// always head up
//		yV = Random.value > 0.5 ? yV : -1 * yV;
		return new Vector2 (xV, yV);
	}

	void ReverseXVelocity() {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-1 * GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
	}

	void ReverseYVelocity() {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, -1 * GetComponent<Rigidbody2D>().velocity.y);
	}
}
