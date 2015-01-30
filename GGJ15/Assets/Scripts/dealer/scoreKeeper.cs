using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreKeeper : MonoBehaviour {
	public static int remainDists = 1;
	public GameObject pedCont;
	Text remaining;
	public bool ended = false;
	// Use this for initialization
	void Start () {
		pedCont = GameObject.Find ("pedestrianController");
		remaining = GetComponent<Text>();
	}

	public void setNeeds(int deals) { //sets remaining distributions
		remainDists = deals;
	}

	// Update is called once per frame
	void Update () {
		remaining.text = "Distributions Remaining: " + remainDists;
		if(remainDists <= 0 && !ended) {
			ended = true;
			pedCont.GetComponent<pedCont>().end("win");
			ended = false;
			//Application.LoadLevel (Application.loadedLevel);
		}
	}

}
