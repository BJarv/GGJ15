using UnityEngine;
using System.Collections;

public class PumpController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
