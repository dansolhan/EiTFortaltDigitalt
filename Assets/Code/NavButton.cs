using UnityEngine;
using System.Collections;

public class NavButton : MonoBehaviour {

	public int index;
	SpriteRenderer sr;
	bool isChecked;
	private Sprite isCheckedSprite;
	private Sprite isUncheckedSprite;

	void Awake() {
		sr = (SpriteRenderer)GetComponent ("SpriteRenderer");
		isCheckedSprite = (Sprite) Resources.Load<Sprite> ("Sprites/selectBox");
		isUncheckedSprite = (Sprite) Resources.Load<Sprite> ("Sprites/UnselectBox");


	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void attachToSlide(int index) {
		this.index = index; 
	}

	public void check() {
		sr.sprite = isCheckedSprite;
		isChecked = true;
		Debug.Log ("Now checking button with index! " + index);
	}

	public void uncheck() {
		sr.sprite = isUncheckedSprite;
		isChecked = false;
	}

	void OnMouseDown() {
		GameObject ip = (GameObject)GameObject.Find ("InformationPanel");
		PanelControl pc = (PanelControl) ip.GetComponent ("PanelControl");
		Debug.Log ("CLICKERED!");
		pc.getSlide (index);

	}
}
