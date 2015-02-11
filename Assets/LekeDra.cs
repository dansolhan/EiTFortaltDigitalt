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

	public Vector3 awayRight = new Vector3 (2000, 0, 1);
	public Vector3 awayLeft = new Vector3 (-2000, 0,1);

	public Vector3 rightEdge;
	public Vector3 leftEdge;

	public string alignment;
	public string command;

	
	void Awake () {
		defaultPosition = new Vector3 (0, 0, 1);
		rightEdge = new Vector3(800f, 0f,0f);
		leftEdge = new Vector3(-800f, 0f,0f);

		Canvas canvas = GetComponentInParent <Canvas>();
		if (canvas != null) {
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform as RectTransform;
		}
	}

	void Update() {
		if (!isDragged) {positionChange ();}
		checkCommand ();
	}


	void positionChange() {
		if (destination == "home") {
				panelRectTransform.localPosition = Vector3.Lerp (panelRectTransform.localPosition, defaultPosition, smooth * Time.deltaTime);
			}
		if (destination == "awayRight") {
			panelRectTransform.localPosition = Vector3.Lerp(panelRectTransform.localPosition, awayRight, smooth * Time.deltaTime);
		}
		if (destination == "awayLeft") {
			panelRectTransform.localPosition = Vector3.Lerp(panelRectTransform.localPosition, awayLeft, smooth * Time.deltaTime);
		}

	}
	
	public void OnPointerDown (PointerEventData data) {
		isDragged = true;
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);

	}

	public void OnPointerUp (PointerEventData data) {
		isDragged = false;
		Vector3 zeroPos = new Vector3 (0, 0, 0);
		Vector3 myPos = panelRectTransform.localPosition;

		if (panelRectTransform.localPosition.x > rightEdge.x) {
						destination = "awayRight";		
				} else if (panelRectTransform.localPosition.x < leftEdge.x) {
						destination = "awayLeft";
				} else {
						destination = "home";
				}

		}


	public void OnDrag (PointerEventData data) {
		float oldPos = canvasRectTransform.position.y;
		if (panelRectTransform == null)
			return;
		
		Vector2 localPointerPosition;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
			canvasRectTransform, data.position, data.pressEventCamera, out localPointerPosition
			)) {

			Vector3 newPosition = localPointerPosition - pointerOffset;
			newPosition.y = oldPos;
			panelRectTransform.localPosition = newPosition;
		}
	}

	private void checkCommand() {
	
	if (command == "appear" && alignment == "right") {
			panelRectTransform.localPosition = Vector3.Lerp(panelRectTransform.localPosition, rightEdge, smooth * Time.deltaTime);
		}
	if (command == "appear" && alignment == "left") {
			panelRectTransform.localPosition = Vector3.Lerp(panelRectTransform.localPosition, -leftEdge, smooth * Time.deltaTime);
		}
	
	}

	public void setCommand(string command) {
		this.command = command;

	}







}