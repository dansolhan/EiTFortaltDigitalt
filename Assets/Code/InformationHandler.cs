using UnityEngine;
using System.Collections;
using Candlelight.UI;
using UnityEngine.UI;


public class InformationHandler : MonoBehaviour {

	GameObject currentWindow;
	PanelControl pc;

	// Use this for initialization
	void Start () {
	GameObject pcObject = GameObject.Find ("PanelControl");
	pc = (PanelControl) pcObject.GetComponent("PanelControl");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onTextClick(HyperText source, HyperText.LinkInfo linkInfo) {

		GameObject window;
		if (currentWindow != null) {
			Destroy(currentWindow);
			}

		switch (linkInfo.ClassName) {
			case("explanation"):
			window = Instantiate(Resources.Load("windows/ExplanationInformation", typeof(GameObject))) as GameObject;
			Transform transform = window.transform.Find("Canvas/Panel/ExplainedWord") as Transform;
			Debug.Log (transform);
			GameObject parent = transform.gameObject;
			Text explainedWord = (Text) parent.GetComponent<Text>();
			explainedWord.text = "Yep!";

			transform = window.transform.Find("Canvas/Panel/WordExplanation") as Transform;
			Debug.Log (transform);
			parent = transform.gameObject;
			Text wordExplained = (Text) parent.GetComponent<Text>();
			wordExplained.text = "This is a description of sorts!";
			currentWindow = window;
			break;

			case("detailed"):

			break;

			case("media"):

			break;

		}


	}

	public void closeCurrentWindow() {
		if (currentWindow != null) {
			Debug.Log ("Destroy!");
			Destroy (currentWindow);
			}
	}

}
