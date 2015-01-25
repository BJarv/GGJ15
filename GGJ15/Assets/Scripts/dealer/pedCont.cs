using UnityEngine;
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
	public GameObject scoreKeeper;
	public int deals = 5;
	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find ("Main Camera/Canvas/scoreKeeper");
		scoreKeeper.GetComponent<scoreKeeper>().setNeeds(deals);
		player = GameObject.Find ("player");
		leftSpawn = transform.Find ("leftSpawn").transform.position;
		rightSpawn = transform.Find ("rightSpawn").transform.position;
		InvokeRepeating("spawnPed", .1f, spawnEvery);
		spawnThug ();
		Invoke ("spawnCop", 10f);
		//InvokeRepeating("spawnThug", .1f, spawnThugEvery);
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

}
