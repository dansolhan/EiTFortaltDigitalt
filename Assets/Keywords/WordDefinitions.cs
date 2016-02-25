using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class WordDefinitions : MonoBehaviour {

	Dictionary<string, string> definitions;

	string PATH = "Text/definitions/";

	// Use this for initialization
	void Start () {
		definitions = new Dictionary<string, string> ();
		Debug.LogError ("Now attempting to create journal entry!");
		//Object[] allText = Resources.LoadAll (PATH);
		
		foreach (Object objectText in Resources.LoadAll (PATH)) {
			TextAsset text = (TextAsset) objectText;
			string definition = text.text;
			Debug.Log(definition);
			Debug.LogError("Now creating journal for " + text.name);
			definitions[text.name] = definition;

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public string getDefinition(string word) {
		Debug.Log ("Now getting key: " + word);
		string topicText = definitions[word];
		char[] a = topicText.ToCharArray();
		a[0] = char.ToUpper(a[0]);
		return new string (a);
	}
}
