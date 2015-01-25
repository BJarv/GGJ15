using UnityEngine;
using System.Collections;

public class FishController : MonoBehaviour {
	public float minVelocity = 1;
	public float maxVelocity = 5;
	public float scatterActivationDistance = 6;

	public EdgeCollider2D tankWallTop;
	public EdgeCollider2D tankWallRight;
	public EdgeCollider2D tankWallBottom;
	public EdgeCollider2D tankWallLeft;

	public Sprite deadFishSprite;

	private bool alive = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move() {
		rigidbody2D.velocity = RandomVelocity ();
	}

	public void Die() {
		if (!alive) return;
		alive = false;

		// apply gravity
		rigidbody2D.velocity = new Vector2 (0, 0);
		rigidbody2D.gravityScale = 1;
		rigidbody2D.isKinematic = false;

		SpriteRenderer r = GetComponent<SpriteRenderer> ();
		r.sprite = deadFishSprite;

		// prevent further interaction
		Destroy (GetComponent<BoxCollider2D> ());
	}

	public void Scatter(Vector2 source) {
		if (!alive || Vector2.Distance(transform.position, source) > scatterActivationDistance) return;
		Vector2 newDirection = (Vector2)transform.position - source;
		Vector2 newVelocity = Random.Range (minVelocity, maxVelocity) * newDirection.normalized;
		rigidbody2D.velocity = newVelocity;
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
		rigidbody2D.velocity = new Vector2 (-1 * rigidbody2D.velocity.x, rigidbody2D.velocity.y);
	}

	void ReverseYVelocity() {
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -1 * rigidbody2D.velocity.y);
	}
}
