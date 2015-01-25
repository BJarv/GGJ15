using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerFast : MonoBehaviour {
	private float tm= 0.0f;
	public Text count;

	float minutes;
	int tmin;
	float seconds;
	int tsec;
	// Update is called once per frame
	void FixedUpdate() {
		tm +=Time.deltaTime*4;
		string minutes = Mathf.Floor (tm / 60).ToString ("00");
		string seconds = (tm % 60).ToString ("00");
		count.text =  minutes.ToString () + " : "+seconds.ToString ();
	}


}
