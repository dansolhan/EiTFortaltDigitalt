using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LekeDra : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
	
	private Vector2 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;
	public PanelControl panelControl;
	public Vector3 defaultPosition;
	public float smooth;
	private bool isDragged;
	private string destination;


	Vector3 awayRight = new Vector3 (2000, 0, 1);
	Vector3 awayLeft = new Vector3 (-2000, 0,1);
	Vector3 middle = new Vector3(1,1,1);

	Vector3 rightEdge = new Vector3(400f, 0f,0f);
	Vector3 leftEdge = new Vector3(-400f, 0f,0f);
	Vector3 PopupEdgeLeft = new Vector3 (200, 0,1);
	Vector3 PopupEdgeRight = new Vector3 (1800, 0,1);
	bool isActive;


	private Vector3 from;
	private Vector3 to;

	private PanelControl panelController;

	
	void Awake () {
		setActive (false);
		panelController = (PanelControl) this.transform.parent.GetComponent ("PanelControl");




		Canvas canvas = GetComponentInParent <Canvas>();
		if (canvas != null) {
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform as RectTransform;
		}
		to = panelRectTransform.localPosition;
	}

	void Update() {
		if (!isDragged) {performMove();}
	}

	public void moveToCenter() {
		Debug.Log ("Moving to Center!");
		to = middle;
	}

	public void appearFromLeft() {
		Debug.Log ("Appearing from Left!");
		panelRectTransform.localPosition = awayLeft;
		to = middle;
	}

	public void appearFromRight() {
		panelRectTransform.localPosition = awayRight;
		to = middle;
	}


	public void exitRight() {
		Debug.Log("Appearing to the Right!");
		to = awayRight;
	}

	public void exitLeft() {
		Debug.Log ("Appearing to the Left!");
		to = awayLeft;
	}

	public void goToLeftQueue() {

	}

	public void OnPointerDown (PointerEventData data) {
		isDragged = true;
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);

	}

	public void OnPointerUp (PointerEventData data) {
		isDragged = false;
 		Vector3 myPos = panelRectTransform.localPosition;

		if (panelRectTransform.localPosition.x > rightEdge.x) {
						exitRight ();
						panelController.nextSlide ();
				} else if (panelRectTransform.localPosition.x < leftEdge.x) {
						exitLeft ();
						panelController.previousSlide ();

				} else {
						if (this.isActive) {
						//		moveToCenter ();
						}
				}

		}


	public void OnDrag (PointerEventData data) {
		float oldPos = canvasRectTransform.position.y;
		if (panelRectTransform == null) {
				return;
				}
		
		Vector2 localPointerPosition;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
			canvasRectTransform, data.position, data.pressEventCamera, out localPointerPosition
			)) {

			Vector3 newPosition = localPointerPosition - pointerOffset;
			newPosition.y = oldPos;
			panelRectTransform.localPosition = newPosition;
		}
	}

	private void performMove() {
		panelRectTransform.localPosition = Vector3.Lerp(panelRectTransform.localPosition, to, smooth * Time.deltaTime);
	
	}

	public void setActive(bool active) {
		this.isActive = active;

	}

	public bool getActive() {
		return isActive;
	}






}