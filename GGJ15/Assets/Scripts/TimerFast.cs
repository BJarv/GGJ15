using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerFast : MonoBehaviour {
	public float tm = 0f;
	public Text count;

	float minutes;
	int tmin;
	float seconds;
	int tsec;
	// Update is called once per frame
	void FixedUpdate() {
		tm +=Time.deltaTime*35;
		string minutes = Mathf.Floor (tm / 60).ToString ("00");
		string seconds = (tm % 60).ToString ("00");
		count.text =  minutes.ToString () + " : "+seconds.ToString ();
	}


}
