using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour {
	private float tm= 326.0f;
	public Text count;
	// Update is called once per frame
	void FixedUpdate() {
		tm += Time.deltaTime;
		string minutes = Mathf.Floor (tm / 60).ToString ("00");
		string seconds = (tm % 60).ToString ("00");
		count.text =  minutes.ToString () + " : "+seconds.ToString ();
	}
}
