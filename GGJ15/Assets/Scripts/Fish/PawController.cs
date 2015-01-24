using UnityEngine;
using System.Collections;

public class PawController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		transform.position = ray.origin;

		if (Input.GetMouseButtonDown (0)) {
			// start waves
			// deflect fishes
			GameObject[] fishes = GameObject.FindGameObjectsWithTag("Fish");
			foreach (var fishObj in fishes) {
				FishController fish = fishObj.GetComponent<FishController>();
				fish.Scatter (transform.position);
			}
		}; 
	}
}
