using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {
	private RawImage box;
	// Use this for initialization
	void Start (){
		box = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		float fader = Mathf.Lerp (box.color.a, 255, Time.deltaTime * .0008f);
		box.color = new Color (1f, 1f, 1f, fader);
	}
}
