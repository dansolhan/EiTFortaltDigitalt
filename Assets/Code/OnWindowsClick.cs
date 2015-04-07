using UnityEngine;
using System.Collections;

public class OnWindowsClick : MonoBehaviour {

	public PanelControl pc;

	// Use this for initialization
	void Start () {
		GameObject go = (GameObject) GameObject.Find ("InformationPanel");
		pc = go.GetComponent<PanelControl>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClick() {
		pc.closeCurrentWindow ();
		pc.unlockPanel ();

	}
}
