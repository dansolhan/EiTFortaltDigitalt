using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelControl : MonoBehaviour {
	
	List<Transform> children;
	int index = 0;
	public LekeDra currentChild;
	public AudioClip onSlideSound;
	private AudioSource audioSource; 

	void Awake() {
		audioSource = (AudioSource) this.GetComponent ("AudioSource");
		children = new List<Transform>();
		foreach (Transform child in transform) {
			children.Add(child);
			Debug.Log(child.name);
		}

	}

	// Use this for initialization
	void Start () {


		Debug.Log(transform.childCount.ToString());


		currentChild = (LekeDra) children [index].gameObject.GetComponent ("LekeDra");
		currentChild.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			nextSlide();
				}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			previousSlide();
				}
	
	}

	public void startSlider() {
		index = 0;
		currentChild = (LekeDra) children [index].gameObject.GetComponent ("LekeDra");
		getSlide ("left");
	}

	public void getSlide(string side) {
		Debug.Log ("Nåværende barn: " + currentChild);
		audioSource.PlayOneShot (onSlideSound, 100f);
		currentChild.setActiveSlide (false);
		LekeDra gammel = currentChild;
		LekeDra lekeDraObject = (LekeDra) children[index].gameObject.GetComponent ("LekeDra");
		currentChild = lekeDraObject;
		currentChild.setActiveSlide (true);
		if (side == "right") {
			gammel.exitRight();
			currentChild.appearFromLeft();
				}
		if (side == "left") {
			gammel.exitLeft();
			currentChild.appearFromRight();
				}
	}


	void Center() {


	}
	
	
	public void nextSlide() {
		if (index < children.Count -1) {
				index += 1;
				getSlide ("right");
			} else {
			index = 0;
			getSlide ("right");
				}

	}

	public void previousSlide() {
				if (index > 0) {
						index -= 1;
						getSlide ("left");
				} else {
						index = children.Count - 1;
						getSlide ("left");
				}
		}


}
