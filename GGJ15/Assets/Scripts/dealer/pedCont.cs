using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class pedCont : MonoBehaviour {

	public GameObject ped;
	public GameObject cop;
	public GameObject thug;
	public Vector2 leftSpawn;
	public Vector2 rightSpawn;
	public float spawnEvery = .5f;
	public float spawnThugEvery = 1f;
    public GameObject player;
	public GameObject scoreKeep;
	public int deals = 3;
	public float time = 50f;
	public GameObject pop;
	public GameObject timer;
	// Use this for initialization
	void Start () {
		timer = GameObject.Find ("Main Camera/Canvas/timer");
		scoreKeep = GameObject.Find ("Main Camera/Canvas/scoreKeeper");
		player = GameObject.Find ("player");
		leftSpawn = transform.Find ("leftSpawn").transform.position;
		rightSpawn = transform.Find ("rightSpawn").transform.position;
		//InvokeRepeating("spawnThug", .1f, spawnThugEvery);
		player.GetComponent<player>().canMove = false;
		InvokeRepeating("spawnPed", .1f, spawnEvery);
		if(PlayerPrefs.GetInt ("difficulty") == 1) {
			deals = 5;
			time = 70f;
		}

		pop.GetComponent<PopUpController>().InitializePopup("Dealing Game","Okay","Distribute Catnip to thugs, but don't do it while any cops are facing you! Move left or right and press space to deal.", delegate {
			pop.SetActive(false);
			player.GetComponent<player>().canMove = true;
			timer.GetComponent<Timer3>().startTime(time);
			scoreKeep.GetComponent<scoreKeeper>().setNeeds(deals);
			spawnThug ();
			Invoke ("spawnCop", 10f);
		});
	}


	public void spawnThug() {
		int leftOrRight = Random.Range(0, 2);
		Vector2 pos;
		int direction;
		if(leftOrRight == 0){
			pos = leftSpawn;
			direction = 1;
		} else {
			pos = rightSpawn;
			direction = -1;
		}
		pos = new Vector2 (pos.x, player.transform.position.y);
		GameObject tempThug = Instantiate(thug, pos, Quaternion.identity) as GameObject;
		tempThug.GetComponent<sketchCat>().direction = direction;
		//Destroy (tempThug, 30f);
	}

	public void spawnCop() {
		int leftOrRight = Random.Range(0, 2);
		int layer = Random.Range (1, 4);
		Vector2 pos;
		int direction;
		if(leftOrRight == 0){
			pos = leftSpawn;
			direction = 1;
		} else {
			pos = rightSpawn;
			direction = -1;
		}
		GameObject tempCop = Instantiate(cop, pos, Quaternion.identity) as GameObject;
		tempCop.GetComponent<cop>().direction = direction;
		if(layer == 1){
			tempCop.transform.position = new Vector2 (tempCop.transform.position.x, tempCop.transform.position.y + .5f);
			tempCop.GetComponent<SpriteRenderer>().renderer.sortingLayerName = "Enemy 1";
		} else if(layer == 2){
			tempCop.GetComponent<SpriteRenderer>().renderer.sortingLayerName = "Enemy 2";
		} else if(layer == 3){
			tempCop.transform.position = new Vector2 (tempCop.transform.position.x, tempCop.transform.position.y - .5f);
			tempCop.GetComponent<SpriteRenderer>().renderer.sortingLayerName = "Enemy 3";
		}
		//Destroy (tempCop, 30f);
	}

	public void spawnCopWDelay(float delay){
		Invoke ("spawnCop", delay);
	}

	public void spawnPed(){

		int leftOrRight = Random.Range(0, 2);
		int layer = Random.Range (1, 4);
		Vector2 pos;
		int direction;
		if(leftOrRight == 0){
			pos = leftSpawn;
			direction = 1;
		} else {
			pos = rightSpawn;
			direction = -1;
		}
		GameObject tempPed = Instantiate(ped, pos, Quaternion.identity) as GameObject;
		tempPed.GetComponent<pedestrian>().direction = direction;
		if(layer == 1){
			tempPed.transform.position = new Vector2 (tempPed.transform.position.x, tempPed.transform.position.y + .5f);
			tempPed.GetComponent<SpriteRenderer>().renderer.sortingLayerName = "Enemy 1";
		} else if(layer == 2){
			tempPed.GetComponent<SpriteRenderer>().renderer.sortingLayerName = "Enemy 2";
		} else if(layer == 3){
			tempPed.transform.position = new Vector2 (tempPed.transform.position.x, tempPed.transform.position.y - .5f);
			tempPed.GetComponent<SpriteRenderer>().renderer.sortingLayerName = "Enemy 3";
		}
		//Destroy (tempPed, 30f);
	}

	public void destroyThis(GameObject me) {
		Destroy(me);

	}

	public void end(string cond) { 
		pop.SetActive (true);
		if(cond == "win") { //win
			if(PlayerPrefs.GetInt ("difficulty") == 1) {
				Debug.Log ("no difficulty, setting it");
				PlayerPrefs.SetInt ("difficulty", 1);
				pop.GetComponent<PopUpController>().InitializePopup("Dealing Game","Head Home","Making some serious bank! Catnip Cris will be pleased.", delegate {
					Application.LoadLevel (Application.loadedLevel);
				});
			} else {
				Debug.Log ("has a key");
				pop.GetComponent<PopUpController>().InitializePopup("Dealing Game","Head Home","Making some serious bank! Catnip Cris will be pleased.", delegate {	
					Application.LoadLevel (Application.loadedLevel);
				});
			}

		}
		if(cond == "lose") { //lose
			player.GetComponent<player>().canMove = false;
			pop.GetComponent<PopUpController>().InitializePopup("Dealing Game","Try Again","Catnip Cris is gonna be livid, better get back and there and make up for it.", delegate {

				Application.LoadLevel (Application.loadedLevel);
			});
		}

	}

}
