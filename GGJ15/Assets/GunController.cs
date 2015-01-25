using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
	
	public ParticleSystem nozzleParticle;
	public ParticleSystem catParticle;
	public SpriteRenderer stickUpCat;
	public BoxCollider2D catCollider;
	public Sprite deadCat;
	public AudioSource audio1;
	public AudioSource audio2;
	public float gunLatency = 3;
	public float fadeLatency = 3;
	public ScreenFader fader;
	public string nextScene;

	bool fired = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width &&
		    Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			transform.position = ray.origin;

			if (Input.GetMouseButtonDown (0) && !fired && catCollider.OverlapPoint(transform.position)) {
				fired = true;
				nozzleParticle.Play ();
				audio1.Play();
				Invoke ("KillCat", gunLatency);
			}; 
		}
	}

	void KillCat() {
		audio2.Play ();
		catParticle.Play ();
		stickUpCat.sprite = deadCat;
		Invoke ("Fade", fadeLatency);
	}

	void Fade() {
		fader.FadeAndLoadScene (nextScene);
	}
}
