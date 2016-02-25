using UnityEngine;
using System.Collections;
using Candlelight.UI;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class InformationHandler : MonoBehaviour {

	GameObject currentWindow;
	PanelControl pc;
	public WordDefinitions definitions;
	public DetailedDefinitions detailedDefinitions;
	public Canvas currentCanvas;



	// Use this for initialization
	void Start () {
	GameObject pcObject = GameObject.Find ("Canvas/InformationPanel");
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

		Transform currentTransform;
		GameObject parentObject;
		Debug.Log (linkInfo.ClassName);

		switch (linkInfo.ClassName) {
			case("explanation"):
			window = Instantiate(Resources.Load("windows/ExplanationInformation", typeof(GameObject))) as GameObject;
			window.transform.SetParent(currentCanvas.transform,false);
			currentTransform = window.transform.Find("Canvas/Panel/ExplainedWord") as Transform;
			Debug.Log (currentTransform);
			parentObject = currentTransform.gameObject;
			Text explainedWord = (Text) parentObject.GetComponent<Text>();

			string topicText = Regex.Replace(linkInfo.Id, " ", "");
			char[] a = topicText.ToCharArray();
			a[0] = char.ToUpper(a[0]);
			explainedWord.text = new string(a);

			Debug.Log (source.GetLinkKeywordCollections());


			currentTransform = window.transform.Find("Canvas/Panel/WordExplanation") as Transform;
			Debug.Log (currentTransform);
			parentObject = currentTransform.gameObject;
			Text wordExplained = (Text) parentObject.GetComponent<Text>();
			string topicDescription = definitions.getDefinition(linkInfo.Id);
			wordExplained.text = topicDescription;
			currentWindow = window;
			break;

			case("deeper"):
			window = Instantiate(Resources.Load("windows/DetailedInformation", typeof(GameObject))) as GameObject;
			currentTransform = window.transform.Find("MainPanel") as Transform;
			window.transform.SetParent (currentCanvas.transform,false);
			Transform titleTransform = (Transform) window.transform.Find ("MainPanel/detailedTitle");
			GameObject titleObject = titleTransform.gameObject;

			Text title = (Text) titleObject.GetComponent("Text");
			char[] b = linkInfo.Id.ToCharArray();
			b[0] = char.ToUpper(b[0]);
			title.text = new string(b);

			pc.lockPanel();

			Transform detailedTransform = window.transform.Find ("MainPanel/DetailedText/TEXT");
			GameObject detailedObject = detailedTransform.gameObject;
			Text detailed = (Text) detailedObject.GetComponent("Text");
			detailed.text = detailedDefinitions.getDefinition(linkInfo.Id);
			currentWindow = window;
			break;

			case("media"):
			break;

			default: {break;}

		}


	}

	public void closeCurrentWindow() {
		if (currentWindow != null) {
			Debug.Log ("Destroy!");
			Destroy (currentWindow);
			}
	}

}
