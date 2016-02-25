using UnityEngine;
using System.Collections;

public class ProgramControl : MonoBehaviour {

	public GameObject extraData;
	public GameObject mediaData;
	public GameObject explainData;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (1128, 635, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
	
	}

	public void endGame() {
		Application.Quit();

	}
}
