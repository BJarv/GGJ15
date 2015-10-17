using UnityEngine;
using System.Collections;

public class PumpController : MonoBehaviour {

	public ParticleSystem bubbles;

	// Use this for initialization
	void Start () {
		bubbles.GetComponent<Renderer>().sortingLayerName = "Effects";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		FishController fish = other.gameObject.GetComponent<FishController> ();
		if (fish) {
			fish.Die();
		}
	}
}
