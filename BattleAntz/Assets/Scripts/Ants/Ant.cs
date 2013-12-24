using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	private Vector3 lastPosition;
	private RoadController roadController;
	private float speed = 0.3f;

	public Vector3 target;
	// Use this for initialization
	public void spawn () {
		roadController = GameObject.Find("Road Controller").GetComponent("RoadController") as RoadController;
		lastPosition = transform.position;
	}

	void FixedUpdate(){
		Vector3 offset = target-transform.position;
		float length = Mathf.Sqrt(offset.x*offset.x + offset.y*offset.y);
		transform.Translate(new Vector2(offset.x/length, offset.y/length)*speed);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.angularVelocity = Vector3.zero;
		if(roadController.outsideRoad(transform.position)){
			transform.position = lastPosition;
		}
		lastPosition = transform.position;
	}
}
