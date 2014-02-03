using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	private Vector3 lastPosition;
	private RoadController roadController;
	private Ant antTarget;

	protected float maxHealth;
	protected float speed;
	protected float damage;
	protected float life;
	protected float range;

	protected Vector3 direction;
	protected Ant targetAnt;

	public int ID;
	public int[] upgrades;
	public GameObject enemyFactory;
	public GameObject lifeBar;
	public Hive enemyHive;

	public antType type;
	public enum antType{enemy, player};

	// Use this for initialization
	public void spawn () {
		roadController = GameObject.Find("Road Controller").GetComponent("RoadController") as RoadController;
		lastPosition = transform.position;
	}


	//Attack the other ant if it exists, default behavior
	public virtual void Update(){
		//Move the ant in its desired direction
		Vector3 offset = direction-transform.position;
		float length = Mathf.Sqrt(offset.sqrMagnitude);
		transform.Translate(new Vector2(offset.x/length, offset.y/length)*speed);

		//If there is an ant to attack, attack it
		if(targetAnt != null)
			targetAnt.attack(this);

//		Vector3 offset;
//		antTarget = getNearestAnt();
//		if(antTarget == null)
//			offset = enemyHive.gameObject.transform.position-transform.position;
//		else{
//			offset = antTarget.gameObject.transform.position-transform.position;
//		}
//		float length = Mathf.Sqrt(offset.sqrMagnitude);
//		
//		transform.Translate(new Vector2(offset.x/length, offset.y/length)*speed);
//		if(antTarget != null){
//			antTarget.attack(this);
//		}
	}
	
	// After the ant has moved, check that it is still inbound
	void LateUpdate () {
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.angularVelocity = Vector3.zero;
		if(roadController.outsideRoad(transform.position)){
			transform.position = lastPosition;
		}
		lastPosition = transform.position;

		lifeBar.transform.localScale = new Vector2(life/maxHealth, lifeBar.transform.localScale.y);
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
			die();
	}

	// Take damage from attacking ant
	public void doDamage(int damage){
		if (life <= 0)
			return;
		life -= damage;
		if(life <= 0)
			die();
	}

	// Gets called everytime an ant collides with something
	void OnCollisionEnter(Collision collision) {
		//If colliding with enemy hive, do dmg and destroy self
		if(collision.gameObject.tag == enemyHive.tag){
			enemyHive.takeDamage(damage);
			die();
		}
	}
	public virtual void die(){
		enemyFactory.GetComponentInChildren<AntFactory>().antsKilled += 1;
		Destroy (this.gameObject);
	}
}