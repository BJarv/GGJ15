using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AirportSceneScript : MonoBehaviour {

	public Text textUI;
	public Image imageUI;
	public Sprite byeImage;
	public FadeOut fader;
	public AudioSource airportSource;
	public AudioClip airportSound;
	public AudioClip takeoffSound;

	bool fadeAudio = false;

	// Use this for initialization
	void Start () {
		Invoke ("ShowText", 2);
		Invoke ("ShowLeaving", 5);
		Invoke ("FadeOut", 10);
		Invoke ("NextScene", 20);
	}

	void ShowText() {
		airportSource.clip = airportSound;
		airportSource.Play ();
		textUI.enabled = true;
	}

	void ShowLeaving() {
		textUI.enabled = false;
		imageUI.sprite = byeImage;
		fadeAudio = true;
	}
	
	void FadeOut() {
		fader.Out ();
		airportSource.clip = takeoffSound;
		airportSource.volume = 1;
		airportSource.Play ();
	}

	void NextScene() {
		Application.LoadLevel("call1");
	}

	void Update() {
		if (fadeAudio) {
			airportSource.volume = Mathf.Lerp (airportSource.volume, 0, Time.deltaTime * .1f);
		}
	}
}
