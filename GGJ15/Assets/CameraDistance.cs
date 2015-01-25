using UnityEngine;
using System.Collections;

public class CameraDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// we want 768
		Camera camera = GetComponent<Camera> ();
		camera.orthographicSize = Mathf.Max(Screen.height / 768.0f * 2.25f, 1.0f);
	}
}
