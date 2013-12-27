using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	private Vector3 lastPosition;
	private RoadController roadController;
	private Ant antTarget;

	protected float speed;
	protected float damage;
	protected float life;
	protected float range;

	public int ID;
	public GameObject enemyFactory;
	public Vector3 hiveTarget;

	// Use this for initialization
	public void spawn () {
		roadController = GameObject.Find("Road Controller").GetComponent("RoadController") as RoadController;
		lastPosition = transform.position;
	}

	// Move the ant forward to either an ant or the enemy hive
	void FixedUpdate(){
		Vector3 offset;
		antTarget = getNearestAnt();
		if(antTarget == null)
			offset = hiveTarget-transform.position;
		else{
			offset = antTarget.gameObject.transform.position-transform.position;
		}
		float length = Mathf.Sqrt(offset.sqrMagnitude);
		
		transform.Translate(new Vector2(offset.x/length, offset.y/length)*speed);
	}

	//Attack the other ant if it exists
	public virtual void Update(){
		if(antTarget != null){
			antTarget.attack(this);
		}
	}
	
	// After the ant has moved, check that it is still inbound
	void LateUpdate () {
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.angularVelocity = Vector3.zero;
		if(roadController.outsideRoad(transform.position)){
			transform.position = lastPosition;
		}
		lastPosition = transform.position;
	}

	// Find the nearest enemy ant
	private Ant getNearestAnt(){
		Ant[] ants = enemyFactory.GetComponentsInChildren<Ant>();
		Ant target = null;
		float nearest = -1;
		foreach(Ant a in ants){
			Vector2 diff = a.gameObject.transform.position-transform.position;
			if(diff.sqrMagnitude < nearest || nearest < 0 ){
				target = a;
				nearest = diff.sqrMagnitude;
			}
		}
		return target;
	}

	// If within range, take damage from attacking ant
	public void attack(Ant a){
		float distance = Mathf.Sqrt((a.gameObject.transform.position-transform.position).sqrMagnitude);
		if(distance < a.range){
			life -= a.damage * Time.deltaTime;
		}
		if(life < 0)
			Destroy(this.gameObject);
	}

}