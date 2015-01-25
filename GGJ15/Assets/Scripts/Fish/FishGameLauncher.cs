using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class FishGameLauncher : MonoBehaviour {

	public static bool UseHigherDifficulty = false;
	
	public PopUpController popup;
	public Text countDownLabel;
	public FishGame game;
	
	public int numberOfFish;
	public int gameDuration;

	float secondsLeft;

	// Use this for initialization
	void Start () {
		InitializeGame ();
		game.SetListeners (delegate {
			HandleSuccess();
		}, delegate {
			HandleFailure ();
		});
		ShowTutorial ();
	}

	void Update() {
		countDownLabel.text = game.secondsLeft.ToString ();
	}

	void InitializeGame () {
		if (UseHigherDifficulty) {
			game.InitializeGame (15, 2, 25);
		} else {
			game.InitializeGame (10, 3, 20);
		}
	}
	
	void ShowTutorial() {
		popup.InitializePopup ("Save the Fish", "Okay", "Tap on the glass to keep the fish away from the pump.", delegate {
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
		popup.InitializePopup ("Save the Fish", "Okay", "Yay, you're a hero!", delegate {
			popup.gameObject.SetActive(false);
			if (!UseHigherDifficulty) {
				UseHigherDifficulty = true;
				Application.LoadLevel("CallBetweenFishGame");
			} else {
				Application.LoadLevel("2Phone2");
			}
		});
		popup.gameObject.SetActive(true);
	}

	void HandleFailure() {
		popup.InitializePopup ("Save the Fish", "Try Again", "Too many fish were killed.", delegate {
			popup.gameObject.SetActive(false);
			InitializeGame();
			game.StartGame();
		});
		popup.gameObject.SetActive(true);
	}
}
