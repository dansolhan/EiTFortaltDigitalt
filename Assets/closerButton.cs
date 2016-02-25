using UnityEngine;
using System.Collections;

public class closerButton : MonoBehaviour {

	PanelControl pc;

	// Use this for initialization
	void Start () {
		GameObject IP = GameObject.Find ("InformationPanel");
		pc = (PanelControl) IP.GetComponent ("PanelControl");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void onCloseButtonClick() {
		Debug.Log ("now closing!");
		pc.onCloseButtonClick ();
	}
}
