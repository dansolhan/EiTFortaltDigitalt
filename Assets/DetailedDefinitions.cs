using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class DetailedDefinitions : MonoBehaviour {
	
	public Dictionary<string, string> detailedDefinitions;
	
	string PATH = "Text/detailed/";
	
	// Use this for initialization
	void Start () {
		detailedDefinitions = new Dictionary<string, string> ();
		Debug.LogError ("Now attempting to create journal entry!");
		Object[] allText = Resources.LoadAll (PATH);

		foreach (Object objectText in allText) {
			TextAsset text = (TextAsset) objectText;
			string definition = text.text;
			Debug.Log(definition);
			Debug.LogError("Now creating journal for " + text.name);
			detailedDefinitions[text.name] = definition;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public string getDefinition(string word) {
		Debug.Log ("Now getting key: " + word);
		string topicText = detailedDefinitions[word];
		Debug.Log ("This is the topic text: " + topicText);
		char[] a = topicText.ToCharArray();
		a[0] = char.ToUpper(a[0]);
		return new string (a);
	}
}