﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class FishGameLauncher : MonoBehaviour {

	public GameObject fishPrefab;
	public PopUpController popup;

	public int numberOfFish;
	public int gameDuration;

	public EdgeCollider2D tankWallTop;
	public EdgeCollider2D tankWallRight;
	public EdgeCollider2D tankWallBottom;
	public EdgeCollider2D tankWallLeft;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfFish; i++) {
			GameObject fishObj = (GameObject) Instantiate (fishPrefab, RandomPositionInTank(), Quaternion.identity);
			FishController fish = fishObj.GetComponent<FishController>();
			fish.tankWallTop = tankWallTop;
			fish.tankWallRight = tankWallRight;
			fish.tankWallLeft = tankWallLeft;
			fish.tankWallBottom = tankWallBottom;
		}
		ShowTutorial ();
	}
	
	// Update is called once per frame
	void Update () {
		// teach rule
		// use your paw to 
		// 3,2,1,go!
	}

	Vector2 RandomPositionInTank() {
		// TODO better instantiation values
		float x = Random.Range (-3, 3);
		float y = Random.Range (-3, 3);
		return new Vector2 (x, y);
	}

	void ShowTutorial() {
		popup.InitializePopup ("Feed the fish", "Okay", "message", delegate {
			CountDown();
		});
		popup.gameObject.SetActive(true);
//		yield return CountDown ();
	}

	void CountDown() {
		Debug.Log ("GGGG");
		popup.gameObject.SetActive(false);
//		yield return StartGame ();
	}

	void StartGame() {
//		yield return null;
	}

}
