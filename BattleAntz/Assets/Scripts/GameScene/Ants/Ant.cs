using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	private Vector3 lastPosition;
	private RoadController roadController;
	private Ant antTarget;

	public float maxHealth;
	public float speed;
	public float damage;
	public float life;
	public float range;

	protected Behavior behavior;

	public int ID;
	public int[] upgrades;
	public GameObject enemyFactory;
	public GameObject lifeBar;
	public Hive enemyHive;
	public Material playerAntMaterial;

	// Use this for initialization
	public virtual void spawn () {
		roadController = GameObject.Find("Road Controller").GetComponent("RoadController") as RoadController;
		lastPosition = transform.position;
		if (this.enemyHive.tag != "PlayerHive") {
			this.renderer.material = playerAntMaterial;
		}
	}

	public virtual void Update(){
	}

	public void FixedUpdate(){
		//Move the ant in its desired direction
		transform.Translate(behavior.nextDirection()*speed);
		
		//If there is an ant to attack, attack it
		Ant ant = behavior.antToAttack();
		if(ant != null)
			ant.attack(this);
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