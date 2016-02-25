using UnityEngine;
using System.Collections;

public class StartTrigger : MonoBehaviour {

	PanelControl PC;
	public AudioSource introAudio;

	void Awake() {
		PC = (PanelControl) GameObject.Find("Canvas/InformationPanel").GetComponent("PanelControl");
	}

	void Start () {
		introAudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetKey (KeyCode.Return)) {
					Debug.Log("What happened??");
						PC.enabled = true;
						PC.startSlider ();
						GameObject parenty = gameObject.transform.parent.gameObject;
						parenty.SetActive (false);
				}
		}
	
	}

