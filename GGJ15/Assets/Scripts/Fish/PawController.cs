using UnityEngine;
using System.Collections;

public class PawController : MonoBehaviour {

	public float durationBetweenHits = 1;
	public ParticleSystem tapEffect;
	public Transform epicenter;

	float lastHit;

	// Use this for initialization
	void Start () {
		tapEffect.renderer.sortingLayerName = "Effects";
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		transform.position = new Vector2(ray.origin.x, ray.origin.y);;

		if (Input.GetMouseButtonDown (0) && lastHit + durationBetweenHits < Time.time) {
			lastHit = Time.time;
			// start waves
			// deflect fish
			ScatterFish ();
			PlayTapVisualEffect();
			PlayTapSoundEffect();
		}; 
	}

	void ScatterFish() {
		GameObject[] fishes = GameObject.FindGameObjectsWithTag("Fish");
		foreach (var fishObj in fishes) {
			FishController fish = fishObj.GetComponent<FishController>();
			if (fish) fish.Scatter (epicenter.position);
		}
	}

	void PlayTapVisualEffect() {
		Instantiate(tapEffect, epicenter.position, Quaternion.identity);
	}

	void PlayTapSoundEffect() {
		AudioSource tap = GetComponent<AudioSource>();
		tap.Stop ();
		tap.Play ();
	}
}
