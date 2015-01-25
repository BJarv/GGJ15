using UnityEngine;
using System.Collections;

public class CameraDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// we want 768
		Camera camera = GetComponent<Camera> ();
		camera.orthographicSize = Screen.height / 768 * 3;
	}
}
