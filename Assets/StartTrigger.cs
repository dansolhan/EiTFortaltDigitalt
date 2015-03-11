using UnityEngine;
using System.Collections;

public class StartTrigger : MonoBehaviour {

	PanelControl PC;


	void Awake() {
		PC = (PanelControl) GameObject.Find("InformationPanel").GetComponent("PanelControl");
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

				if (Input.GetKey (KeyCode.Return)) {
						PC.enabled = true;
						PC.startSlider ();
						GameObject parenty = gameObject.transform.parent.gameObject;
						parenty.SetActive (false);

				}
		}
	
	}

