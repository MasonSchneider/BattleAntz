using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	private float delta_x = 0.3f;
	private float delta_y = 0.1f;
	
	private RoadController roadController;
	// Use this for initialization
	void Start () {
		roadController = GameObject.Find("Road Controller").GetComponent("RoadController") as RoadController;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.rigidbody.velocity = Vector3.zero;
		Vector2 newPosition = (Vector2)transform.position + new Vector2(delta_x*Random.Range(-1.0f,1.0f), delta_y*Random.Range(-1.0f,1.0f));
		if(roadController.outsideRoad(newPosition))
			gameObject.transform.position = roadController.pushInside(newPosition);
		else
			gameObject.transform.position = newPosition;
	}
}
