using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextDelay : MonoBehaviour {

	public float delay = 2;

	// Use this for initialization
	void Start () {
		Invoke ("ShowText", delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ShowText() {
		GetComponent<Text> ().enabled = true;
	}
}
