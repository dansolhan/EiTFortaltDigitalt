using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavController : MonoBehaviour {

	int navButtons = 0;
	PanelControl pc;
	List<GameObject> buttons;


	// Use this for initialization
	void Start () {
		pc = (PanelControl) this.transform.parent.GetComponent ("PanelControl");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createNavButton(int index) {
		Debug.Log ("created button!");
		GameObject button = Instantiate((GameObject)Resources.Load("NavButton"));
		NavButton script = (NavButton) button.GetComponent ("NavButton");
		navButtons += 1;
		buttons.Add (button);
		button.transform.position = new Vector2(0,0);
		script.attachToSlide (index);
	}
}
