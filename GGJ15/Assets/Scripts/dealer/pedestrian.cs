using UnityEngine;
using System.Collections;

public class pedestrian : MonoBehaviour {

	public int direction = -1;
	public float minVel;
	public float maxVel;
	public Vector2 myVel;
	public GameObject pedCont;

	// Use this for initialization
	void Start () {
		pedCont = GameObject.Find("pedestrianController");
		myVel = new Vector2(direction * Random.Range (minVel, maxVel), 0);

	}
	
	// Update is called once per frame
	void Update () {
		flip (direction);
		GetComponent<Rigidbody2D>().velocity = myVel; 
		if(transform.position.x < pedCont.GetComponent<pedCont>().leftSpawn.x - 3f || transform.position.x > pedCont.GetComponent<pedCont>().rightSpawn.x + 3f) {
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
