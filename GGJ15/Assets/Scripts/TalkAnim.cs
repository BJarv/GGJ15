using UnityEngine;
using System.Collections;

public class TalkAnim : MonoBehaviour {
	public Animator Male;
	public Animator Female;
	public string MaleAnimation;
	public string FemaleAnimation;
	// Use this for initialization
	void Start () {
		Male.Play (MaleAnimation);
		Female.Play (FemaleAnimation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
