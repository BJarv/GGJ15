using UnityEngine;
using System.Collections;

public class FishGameLauncher : MonoBehaviour {

	public GameObject fishPrefab;
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

	IEnumerator ShowTutorial() {
		yield return CountDown ();
	}

	IEnumerator CountDown() {
		yield return StartGame ();
	}

	IEnumerator StartGame() {
		yield return null;
	}

}
