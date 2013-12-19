using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour {
	public GameObject upperRight;
	public GameObject lowerLeft;

	public bool drawBounds;

	// Use this for initialization
	void Start () {
	
	}

	void OnDrawGizmos(){
		if(drawBounds){
			Gizmos.color = Color.white;
			Gizmos.DrawWireCube((upperRight.transform.position+lowerLeft.transform.position)/2,
			                    upperRight.transform.position-lowerLeft.transform.position);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	// Check if a position is outside of the road bounds
	public bool outsideRoad(Vector2 position){
		if(position.x > upperRight.transform.position.x ||
		   position.x < lowerLeft.transform.position.x ||
		   position.y > upperRight.transform.position.y ||
		   position.y < lowerLeft.transform.position.y)
			return true;
		return false;
	}

	public Vector2 pushInside(Vector2 outside){
		Vector2 inside = outside;
		if(outside.x > upperRight.transform.position.x)
			inside.x -= outside.x - upperRight.transform.position.x;

		if(outside.x < lowerLeft.transform.position.x)
			inside.x += lowerLeft.transform.position.x - outside.x;

		if(outside.y > upperRight.transform.position.y)
			inside.y -= outside.y - upperRight.transform.position.y;

		if(outside.y < lowerLeft.transform.position.y)
			inside.y += lowerLeft.transform.position.y - outside.y;
		return inside;
	}
}
