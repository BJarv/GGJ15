using UnityEngine;
using System.Collections;

public class SceneNavigator : MonoBehaviour {

	public string nextSceneName;
	public bool useTimer = false;
	public float timeout;

	// Use this for initialization
	void Start () {
		if (useTimer) {
			Invoke("PlayNextScene", timeout);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayNextScene() {
		Application.LoadLevel (nextSceneName);
	}
}
