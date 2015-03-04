using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelControl : MonoBehaviour {
	
	List<Transform> children;
	int index = 0;
	public LekeDra currentChild;
	public AudioClip onSlideSound;
	private AudioSource audioSource; 

	// Use this for initialization
	void Start () {
		audioSource = (AudioSource) this.GetComponent ("AudioSource");
		children = new List<Transform>();
		Debug.Log(transform.childCount.ToString());

		foreach (Transform child in transform) {
			children.Add(child);
			Debug.Log(child.name);
		}

		currentChild = (LekeDra) children [index].gameObject.GetComponent ("LekeDra");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void getSlide(string side) {
		audioSource.PlayOneShot (onSlideSound, 100f);
		currentChild.setActive(false);
		LekeDra lekeDraObject = (LekeDra) children[index].gameObject.GetComponent ("LekeDra");
		currentChild = lekeDraObject;
		currentChild.setActive (true);
		if (side == "right") {
			currentChild.appearFromRight();
				}
		if (side == "left") {
			currentChild.appearFromLeft();
				}
	}


	void Center() {


	}

	public void nextSlide() {
		if (index < children.Count -1) {
				index += 1;
				getSlide ("left");
			} else {
			index = 0;
			getSlide ("left");
				}

	}

	public void previousSlide() {
		if (index > 0) {
			index -= 1;
			getSlide ("right");
				}
		else {
			index = children.Count -1;
			getSlide("right");
		}
	}




}
