using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer3 : MonoBehaviour {
	private float tm= 0.0f;
	[HideInInspector]public Text count;
	float minutes;
	int tmin;
	float seconds;
	int tsec;
	bool timing;
	public GameObject pedCont;


	void Start (){
		pedCont = GameObject.Find ("pedestrianController");
		count = GetComponent<Text>();
	}
	// Update is called once per frame
	void FixedUpdate() {
		if(timing) {
			tm -= Time.deltaTime;
			string minutes = Mathf.Floor (tm / 60).ToString ("00");
			string seconds = (tm % 60).ToString ("00");
			count.text =  minutes.ToString () + " : "+seconds.ToString ();
			if(tm <= 0) {
				timing = false;
				pedCont.GetComponent<pedCont>().end ("lose");
			}
		}
	}
	public void startTime(float time){
		tm = time;
		timing = true;
	}
}