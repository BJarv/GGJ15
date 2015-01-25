using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {
	private RawImage box;
	private bool FadeToBlack = false;
	private bool FadeFromBlack = false;
	public GameObject Title;
	public GameObject Img;
	public GameObject Black;
	public GameObject Btn;
	public GameObject Btn2;
	public Sprite envelope;
	// Use this for initialization
	void Start (){
		box = GetComponent<RawImage>();
		Title = GameObject.Find ("title");
		Img = GameObject.Find ("imgp");
		Invoke ("startFade", 5f);
		Invoke ("reverseFade", 34f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(FadeToBlack){
			float fader = Mathf.Lerp (box.color.a, 255, Time.deltaTime * .0003f);
			box.color = new Color (1f, 1f, 1f, fader);
		}
		if (FadeFromBlack) {
			float fader = Mathf.Lerp (box.color.a, 0, Time.deltaTime * 1.00000006f);
			box.color = new Color (1f, 1f, 1f, fader);
		}
	}

	void startFade(){
		FadeToBlack = true;
	}
	void reverseFade(){
		Title.GetComponent<Text>().text = "MSG!";
		Img.GetComponent<Image> ().sprite = envelope;
		Btn.SetActive (true);
		Btn2.SetActive (true);

		FadeToBlack = false;
		FadeFromBlack = true;
		Invoke ("disableBlack", 3f);
	}
	void disableBlack(){
		Black.SetActive (false);
	}
}
