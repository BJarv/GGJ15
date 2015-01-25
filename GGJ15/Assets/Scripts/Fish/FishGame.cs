using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class FishGame : MonoBehaviour {

	public GameObject fishPrefab;

	public EdgeCollider2D tankWallTop;
	public EdgeCollider2D tankWallRight;
	public EdgeCollider2D tankWallBottom;
	public EdgeCollider2D tankWallLeft;

	public float secondsLeft;
	public int numberOfFishLeft;

	FishController[] fishList;
	int numberOfFish;
	float gameDuration;
	UnityAction onSuccess, onFailure;
	bool playing;

	public void InitializeGame(int numberOfFish, float gameDuration) {
		DestroyExistingFish ();
		this.numberOfFish = numberOfFish;
		this.gameDuration = gameDuration;

		fishList = new FishController[numberOfFish];
		for (int i = 0; i < numberOfFish; i++) {
			GameObject fishObj = (GameObject) Instantiate (fishPrefab, RandomPositionInTank(), Quaternion.identity);
			FishController fish = fishObj.GetComponent<FishController>();
			fish.tankWallTop = tankWallTop;
			fish.tankWallRight = tankWallRight;
			fish.tankWallLeft = tankWallLeft;
			fish.tankWallBottom = tankWallBottom;
			fishList[i] = fish;
		}
	}

	public void SetListeners(UnityAction onSuccess, UnityAction onFailure) {
		this.onSuccess = onSuccess;
		this.onFailure = onFailure;
	}

	public void StartGame() {
		foreach (FishController fish in fishList) {
			fish.Move ();
		}
		secondsLeft = gameDuration;
		playing = true;
	}

	public void EndGame() {
		foreach (FishController fish in fishList) {
			fish.Stop ();
		}
	}

	void Update() {
		if (!playing) return;

		if (secondsLeft > 0) {
			secondsLeft = Mathf.Max(0, secondsLeft - Time.deltaTime);
		}

		CheckSuccess ();
	}

	void CheckSuccess() {
		if (secondsLeft == 0) {
			foreach (FishController fish in fishList) {
				fish.Stop ();
			}
			onSuccess();
		}
	}

	void DestroyExistingFish() {
		if (fishList != null) {
			foreach (FishController fish in fishList) {
				Destroy(fish.gameObject);
			}
		}
		fishList = null;
	}

	Vector2 RandomPositionInTank() {
		// TODO better instantiation values
		float x = Random.Range (-4, 4);
		float y = Random.Range (-3, 3);
		return new Vector2 (x, y);
	}
}
