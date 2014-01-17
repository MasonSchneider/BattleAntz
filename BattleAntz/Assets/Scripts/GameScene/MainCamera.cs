using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
	const float SCREEN_MOVEMENT_COEFFICIENT = 5;
	private Vector3 previousMousePosition;
	private Vector3 currentMousePosition;
	private Vector3 mapPosition;
	private bool leftButtonIsDown = false;
	private float minCamaraZoom = 1;
	private float maxCameraZoom = 20;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		//Marks that the left button is no longer being held
		if (Input.GetMouseButtonUp (0))
			leftButtonIsDown = false;
		
		currentMousePosition = Input.mousePosition;

		//Left mouse button down drags the main camera
		if (Input.GetMouseButton(0) && leftButtonIsDown && currentMousePosition.y < Screen.height - 90) {
			mapPosition = this.transform.position;

			//Checks if this is the first update
			if (previousMousePosition == null)
				previousMousePosition = currentMousePosition;

			//Moves the map x-coordinate if the mouse x-position has changed
			if (currentMousePosition.x.CompareTo(previousMousePosition.x) != 0)
			{
				if (currentMousePosition.x - previousMousePosition.x > SCREEN_MOVEMENT_COEFFICIENT)
				{
					mapPosition.x--;
					previousMousePosition.x = currentMousePosition.x;
				}
				else if (currentMousePosition.x - previousMousePosition.x < -SCREEN_MOVEMENT_COEFFICIENT)
				{
					mapPosition.x++;
					previousMousePosition.x = currentMousePosition.x;
				}
			}

			//Moves the map y-coordinate if the mouse y-position has changed
			if (currentMousePosition.y.CompareTo(previousMousePosition.y) != 0)
			{
				if (currentMousePosition.y - previousMousePosition.y > SCREEN_MOVEMENT_COEFFICIENT)
				{
					mapPosition.y--;
					previousMousePosition.y = currentMousePosition.y;
				}
				else if (currentMousePosition.y - previousMousePosition.y < -SCREEN_MOVEMENT_COEFFICIENT)
				{
					mapPosition.y++;
					previousMousePosition.y = currentMousePosition.y;
				}
			}
			this.transform.position = mapPosition;
		}

		//Marks that the left button was pressed down
		if (Input.GetMouseButtonDown (0))
			leftButtonIsDown = true;

		//Scroll down, "zoom" the camera out
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			if (Camera.main.orthographicSize < maxCameraZoom)
				Camera.main.orthographicSize++;
		}
		//Scroll up, "zoom" the camera in
		else if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			if (Camera.main.orthographicSize > minCamaraZoom)
				Camera.main.orthographicSize--;
		}
	}
}