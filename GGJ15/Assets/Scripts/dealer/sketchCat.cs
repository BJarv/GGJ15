using UnityEngine;
using System.Collections;

public class sketchCat : MonoBehaviour {

	public int direction = -1;
	public int minVel;
	public int maxVel;
	public Vector2 myVel;
	public bool canBuy = true;
	public bool buying = false;
	public bool touchingPlayer = false;
	public bool alerted = false;
	public GameObject player;
	public bool completed = false;
	public bool spaceKeyUp = false;
	public bool spaceKeyDown = false;
	public GameObject pedCont;
	public bool spawned = false;
	public bool endingGame = false;
	public float dealTime = 3f;
	public float timer;
	public bool timing = false;
	public GameObject exclam;
	public GameObject questn;

	// Use this for initialization
	void Start () {
		exclam = gameObject.transform.Find("above/!").gameObject;
		questn = gameObject.transform.Find("above/?").gameObject;
		timer = dealTime;
		pedCont = GameObject.Find("pedestrianController");
		player = GameObject.Find ("player");
		myVel = new Vector2(direction * Random.Range (minVel, maxVel), 0);
	}
	
	// Update is called once per frame
	void Update () {
		flip (direction);
		if(!buying) {
			rigidbody2D.velocity = myVel;
		} else {
			if(!player.GetComponent<player>().canSell) {
				exclam.SetActive(true);
				questn.SetActive(false);
				alerted = true;
				buying = false;
				player.GetComponent<player>().canMove = true;
			}
		}
		if(Input.GetKeyUp (KeyCode.Space) && buying && touchingPlayer){
			spaceKeyUp = true;
		}
		if(canBuy && Input.GetKeyDown (KeyCode.Space) && player.GetComponent<player>().canSell && !completed && !alerted && touchingPlayer) {
			spaceKeyDown = true;
		}
		if(timing){
			timer -= Time.deltaTime; 
			//fill bar
			if(timer < 0) {
				timing = false;
				//timer = dealTime;
			}
		}
		if(transform.position.x < pedCont.GetComponent<pedCont>().leftSpawn.x - 3f || transform.position.x > pedCont.GetComponent<pedCont>().rightSpawn.x + 3f && !spawned) {
			pedCont.GetComponent<pedCont>().spawnThug ();
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

	void OnTriggerEnter2D(Collider2D colObj) {
		if(colObj.tag == "Player") {
			touchingPlayer = true;
			if(!alerted && !completed){
				questn.SetActive(true);
			}
		}
	}
	void OnTriggerExit2D(Collider2D colObj) {
		if(colObj.tag == "Player") {
			touchingPlayer = false;
			questn.SetActive(false);
		}
	}


	void OnTriggerStay2D(Collider2D colObj) {
		if(colObj.tag == "Player") {
			if(spaceKeyDown) { //attempt selling
				spaceKeyDown = false;
				colObj.GetComponent<player>().canMove = false;
				buying = true;
				canBuy = false;
				rigidbody2D.velocity = Vector2.zero;
				questn.SetActive(false);
				timing = true;
				Invoke ("checkComplete", dealTime);
			} 
			if(Input.GetKey (KeyCode.Space) && !player.GetComponent<player>().canSell) { //caught selling
				exclam.SetActive(true);
				questn.SetActive(false);
				alerted = true;
				canBuy = false;
				timing = false;
			}
			if(spaceKeyUp && buying && !completed && !alerted) { //cancel selling 
				timer = dealTime;
				timing = false;
				spaceKeyUp = false;
				CancelInvoke();
				questn.SetActive(true);
				colObj.GetComponent<player>().canMove = true;
				canBuy = true;
				buying = false;
			}
			if(Input.GetKeyDown (KeyCode.Space) && !player.GetComponent<player>().canSell) { //tried to sell while in vision of cop
				canBuy = false;
			}
		}
	}

	void checkComplete() {
		if(!alerted && buying){
			player.GetComponent<player>().canMove = true;
			buying = false;
			completed = true;
			pedCont.GetComponent<pedCont>().spawnThug ();
			spawned = true;
			collider2D.enabled = false;
			scoreKeeper.remainDists -= 1;
		}
	}
	

}
