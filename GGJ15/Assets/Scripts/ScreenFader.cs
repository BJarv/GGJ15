using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
	public float fadeSpeed = 0.5f;          // Speed that the screen fades to and from black.
	bool startFade = false;
	string nextScene;
	float alpha;
	
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		GetComponent<GUITexture>().GetComponent<Renderer>().sortingLayerName = "Effects";
	}

	void OnGUI() {
		if (startFade) {
			var color = GetComponent<GUITexture>().color;
			color.a = alpha;
			GetComponent<GUITexture>().color = color;

			if(GetComponent<GUITexture>().color.a >= 0.95f) {
				Application.LoadLevel(nextScene);
				startFade = false;
			}
		}
	}

	void Update() {
		if (startFade) {
			alpha += fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01(alpha);
		}
	}
	
	public void FadeAndLoadScene (string nextScene) {
		this.nextScene = nextScene;
		// Make sure the texture is enabled.
		GetComponent<GUITexture>().enabled = true;
		Color black = Color.black;
		alpha = 0;
		black.a = 0;
		GetComponent<GUITexture>().color = black;

		startFade = true;
	}
}