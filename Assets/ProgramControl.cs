using UnityEngine;
using System.Collections;

public class ProgramControl : MonoBehaviour {

	public GameObject extraData;
	public GameObject mediaData;
	public GameObject explainData;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		extraData.SetActive (false);
		mediaData.SetActive (false);
		explainData.SetActive (false);
	}
}
