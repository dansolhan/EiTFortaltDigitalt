using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelControl : MonoBehaviour {
	
	List<Transform> children;
	int index = 0;
	int lastIndex;
	public LekeDra currentChild;
	public AudioClip onSlideSound;
	private AudioSource audioSource;
	public List<GameObject> navButtons;

	void Awake() {
		children = new List<Transform> ();
		navButtons = new List<GameObject> ();
		audioSource = (AudioSource) this.GetComponent ("AudioSource");
		int localIndex = 0;
		foreach (Transform child in transform) {
			children.Add(child);
			localIndex +=1;
		}

	}

	// Use this for initialization
	void Start () {


		currentChild = (LekeDra) children [index].gameObject.GetComponent ("LekeDra");
		currentChild.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			previousSlide();
				}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			nextSlide();
				}
	
	}

	public void startSlider() {
		int localIndex = 0;
		foreach (Transform child in children) {
			createNavButton(localIndex);
			localIndex +=1;
		}
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
			gammel.exitLeft();
			currentChild.appearFromRight();
			}

		if (side == "left") {
			gammel.exitRight();
			NavButton gammelNavButton = (NavButton) navButtons[index].GetComponent ("NavButton");
			gammelNavButton.uncheck();
			currentChild.appearFromLeft();
			}

		NavButton oldNavButton = (NavButton) navButtons[lastIndex].GetComponent ("NavButton");
		oldNavButton.uncheck ();
		NavButton navButton = (NavButton) navButtons[index].GetComponent ("NavButton");
		navButton.check ();
	}

	public void getSlide(int index) {
				if (index != this.index) {
						lastIndex = this.index;
						audioSource.PlayOneShot (onSlideSound, 100f);
						currentChild.setActiveSlide (false);
						LekeDra gammel = currentChild;
						LekeDra lekeDraObject = (LekeDra)children [index].gameObject.GetComponent ("LekeDra");
						currentChild = lekeDraObject;
						currentChild.setActiveSlide (true);
						NavButton oldNavButton = (NavButton)navButtons [lastIndex].GetComponent ("NavButton");
						NavButton navButton = (NavButton)navButtons [index].GetComponent ("NavButton");
						navButton.check ();
						oldNavButton.uncheck ();

						if (index < this.index) {
								gammel.exitRight ();
								currentChild.appearFromLeft ();
						}
						if (index > this.index) {
								gammel.exitLeft ();
								currentChild.appearFromRight ();
						}
				this.index = index;
	
				}
		Debug.Log ("Current index: " + this.index);
		Debug.Log ("Last index: " + this.lastIndex);
		}


	void Center() {


	}

	public void createNavButton(int localIndex) {
		GameObject button = Instantiate((GameObject)Resources.Load("NavButton"));
		NavButton script = (NavButton) button.GetComponent ("NavButton");
		navButtons.Add (button);
		button.transform.position = new Vector2((localIndex%8f) - 6f, ((Mathf.Floor(-(localIndex/8)))-7.5f)/2);
		script.index = localIndex;
	}
	
	public void nextSlide() {
		if (index < children.Count -1) {
				lastIndex = index;
				index += 1;
				Debug.Log("The index iiiiis " + index);
				getSlide ("right");
			} else {
			lastIndex = index;
			index = 0;
			getSlide ("right");
				}

	}

	public void previousSlide() {
		if (index > 0) {
			lastIndex = index;
			index -= 1;
			getSlide ("left");
		} else {
		lastIndex = index;
		index = children.Count - 1;
		getSlide ("left");
		}
	}


}
