using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class FishGameLauncher : MonoBehaviour {
	
	public PopUpController popup;
	public Text countDownLabel;
	public FishGame game;
	
	public int numberOfFish;
	public int gameDuration;

	float secondsLeft;

	// Use this for initialization
	void Start () {
		game.InitializeGame (10, 5);
		game.SetListeners (delegate {
			HandleSuccess();
				}, delegate {
				});
		ShowTutorial ();
	}

	void Update() {
		countDownLabel.text = game.secondsLeft.ToString ();
	}
	
	void ShowTutorial() {
		popup.InitializePopup ("Save the Fish", "Sure", "Tap on the glass to keep fish away from the pump.", delegate {
			popup.gameObject.SetActive(false);
			game.StartGame();
		});
		popup.gameObject.SetActive(true);
	}

	void StartGame() {
		GameObject[] fishes = GameObject.FindGameObjectsWithTag("Fish");
		foreach (var fishObj in fishes) {
			FishController fish = fishObj.GetComponent<FishController>();
			fish.Move ();
		}
		secondsLeft = gameDuration;
		countDownLabel.text = secondsLeft.ToString();
	}

	void HandleSuccess() {
		popup.InitializePopup ("Save the fish", "Sure", "Yay, you're a hero!", delegate {
			popup.gameObject.SetActive(false);
		});
		popup.gameObject.SetActive(true);
	}

	void HandleFailure() {
		popup.InitializePopup ("Save the fish", "Try Again", "Too many fish were killed.", delegate {
			popup.gameObject.SetActive(false);
			game.StartGame();
		});
		popup.gameObject.SetActive(true);
	}
}
