using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour {
	private RawImage box;
	private bool startFade;
	// Use this for initialization
	void Start (){
		box = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		if (startFade) {
			float fader = Mathf.Lerp (box.color.a, 255, Time.deltaTime * .0008f);
			box.color = new Color (0f, 0f, 0f, fader);
		}
	}

	public void Out() {
		startFade = true;
	}
}
