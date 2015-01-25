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

	FishController[] fishList;
	int numberOfDeadFish;
	int maxNumberOfDeadFish;
	float gameDuration;
	UnityAction onSuccess, onFailure;
	bool playing;

	public void InitializeGame(int numberOfFish, int maxNumberOfDeadFish, float gameDuration) {
		DestroyExistingFish ();
		numberOfDeadFish = 0;
		this.gameDuration = gameDuration;

		fishList = new FishController[numberOfFish];
		for (int i = 0; i < numberOfFish; i++) {
			GameObject fishObj = (GameObject) Instantiate (fishPrefab, RandomPositionInTank(), Quaternion.identity);
			FishController fish = fishObj.GetComponent<FishController>();
			fish.tankWallTop = tankWallTop;
			fish.tankWallRight = tankWallRight;
			fish.tankWallLeft = tankWallLeft;
			fish.tankWallBottom = tankWallBottom;
			fish.deathHandler = delegate {
				HandleFishDeath();
			};
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

	void HandleFishDeath() {
		numberOfDeadFish++;
		if (numberOfDeadFish >= maxNumberOfDeadFish) onFailure();
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
