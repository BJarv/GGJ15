using UnityEngine;
using System.Collections;

public class cop : MonoBehaviour {

	public int direction = -1;
	public int minVel;
	public int maxVel;
	public Vector2 myVel;
	public GameObject player;
	public bool endingGame = false;
	public GameObject pedCont;
	public float copSpawnDelay = 3f;
	public float copVision = 9f;
	
	// Use this for initialization
	void Start () {
		pedCont = GameObject.Find("pedestrianController");
		player = GameObject.Find ("player");
		myVel = new Vector2(direction * Random.Range (minVel, maxVel), 0);
	}

	bool onScreen() {
		if(transform.position.x > -copVision && transform.position.x < copVision) {
			return true;
		} else return false;
	}

	// Update is called once per frame
	void Update () {
		flip (direction);
		if(transform.position.x < player.transform.position.x && direction == 1 && onScreen()) {
			player.GetComponent<player>().canSell = false;
		
		} else if (transform.position.x > player.transform.position.x && direction == -1 && onScreen ()) {
			player.GetComponent<player>().canSell = false;

		} else {
			player.GetComponent<player>().canSell = true;
		}
		rigidbody2D.velocity = myVel; 

		if(transform.position.x < pedCont.GetComponent<pedCont>().leftSpawn.x - 3f || transform.position.x > pedCont.GetComponent<pedCont>().rightSpawn.x + 3f) {
			pedCont.GetComponent<pedCont>().spawnCopWDelay (copSpawnDelay);
			pedCont.GetComponent<pedCont>().destroyThis(gameObject);
		}
	}

	void flip(float moveH)
	{
		if (moveH < 0)
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		else if (moveH > 0)
			transform.localEulerAngles = new Vector3 (0, 180, 0);
	}
}
