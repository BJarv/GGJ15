using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PopUpController : MonoBehaviour {

	public Text buttonLabel;
	public Text titleLabel;
	public Text messageLabel;
	public Button button;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializePopup (string titleTxt, string buttonTxt, string msgTxt, UnityAction onClickListener) {
		titleLabel.text = titleTxt;
		buttonLabel.text = buttonTxt;
		messageLabel.text = msgTxt;
		button.onClick.RemoveAllListeners ();
		button.onClick.AddListener (onClickListener);
	}
}
