using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreKeeper : MonoBehaviour {
	public static int remainDists;
	Text remaining;
	// Use this for initialization
	void Start () {
		remaining = GetComponent<Text>();
	}

	public void setNeeds(int deals) { //sets remaining distributions
		remainDists = deals;
	}

	// Update is called once per frame
	void Update () {
		remaining.text = "Distributions Remaining: " + remainDists;
		if(remainDists <= 0) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

}
