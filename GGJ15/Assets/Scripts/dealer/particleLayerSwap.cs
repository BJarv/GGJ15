using UnityEngine;
using System.Collections;

public class particleLayerSwap : MonoBehaviour {
	void Start () {
		gameObject.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Effects";
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
