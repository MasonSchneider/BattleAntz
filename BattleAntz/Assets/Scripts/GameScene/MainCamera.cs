using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
	const float SCREEN_MOVEMENT_COEFFICIENT = 7;
	private Vector3 mapPosition;
	private float minCamaraZoom = 6;
	private float maxCameraZoom = 18;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		//Pinch zoom [for mobile devices]
		if (Input.touchCount >= 2)
		{
			Vector2 touch0, touch1;
			float distance;
			touch0 = Input.GetTouch(0).position;
			touch1 = Input.GetTouch(1).position;
			
			distance = Vector2.Distance(touch0, touch1);
			
			if (distance < 0)
			{
				if (Camera.main.orthographicSize < maxCameraZoom)
					Camera.main.orthographicSize++;
			}
			else if (distance > 0)
			{
				if (Camera.main.orthographicSize > minCamaraZoom)
					Camera.main.orthographicSize--;
			}
		}
	}

	public void OnGUI()
	{
		//Zoom when using scroll wheel (or zoom on synaptics laptop pad)
		if (Event.current.type == EventType.ScrollWheel) 
		{
			if (Event.current.delta.y < 0)
			{
				if (Camera.main.orthographicSize > minCamaraZoom)
					Camera.main.orthographicSize--;
			}
			else if (Event.current.delta.y > 0)
			{
				if (Camera.main.orthographicSize < maxCameraZoom)
					Camera.main.orthographicSize++;
			}
		}

		//Pan camera when mouse button is dragged
		if (Event.current.type == EventType.MouseDrag) 
		{
			if (Input.GetMouseButton(0) && Input.mousePosition.y < Screen.height - 90) {
				
				mapPosition = this.transform.position;

				TranslateInXDirection();

				//Not currently in use
				//TranslateInYDirection();

				//Actually moves the camera
				this.transform.position = mapPosition;
			}
		}
	}
	
	//Moves the map x-coordinate if the mouse x-position has changed
	void TranslateInXDirection()
	{
		if (Event.current.delta.x > SCREEN_MOVEMENT_COEFFICIENT) {
			mapPosition.x--;
		}
		else
			if (Event.current.delta.x < -SCREEN_MOVEMENT_COEFFICIENT) {
				mapPosition.x++;
			}
	}
	
	//Moves the map y-coordinate if the mouse y-position has changed
	void TranslateInYDirection()
	{
		if (Event.current.delta.y > SCREEN_MOVEMENT_COEFFICIENT) {
			mapPosition.y++;
		}
		else
			if (Event.current.delta.y < -SCREEN_MOVEMENT_COEFFICIENT) {
				mapPosition.y--;
			}
	}
}