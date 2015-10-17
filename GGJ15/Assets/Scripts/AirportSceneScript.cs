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
	public Text laterTextUI;

	bool fadeAudio = false;

	// Use this for initialization
	void Start () {
		Invoke ("ShowText", 2);
		Invoke ("ShowLeaving", 5);
		Invoke ("FadeOut", 10);
		Invoke ("TwoDaysLater", 19);
		Invoke ("NextScene", 21);
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

	void TwoDaysLater() {
		laterTextUI.text = "2 DAYS LATER";
	}

	void NextScene() {
		Application.LoadLevel("call1");
	}

	void Update() {
		if (fadeAudio) {
			airportSource.volume = Mathf.Lerp (airportSource.volume, 0, Time.deltaTime * .12f);
		}
	}
}
