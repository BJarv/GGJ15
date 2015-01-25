using UnityEngine;
using System.Collections;

public class barFlip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void flip(float moveH) {
		if (moveH < 0)
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		else if (moveH > 0)
			transform.localEulerAngles = new Vector3 (0, 180, 0);
	}
}
