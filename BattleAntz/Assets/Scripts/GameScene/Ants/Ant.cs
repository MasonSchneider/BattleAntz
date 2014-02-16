using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	private Vector3 lastPosition;
	private RoadController roadController;

	public float maxHealth;
	public float speed;
	public float damage;
	public float life;
	public float range;

	protected Behavior behavior;

	public int ID;
	public int[] upgrades;
	public GameObject enemyFactory;
	public GameObject allyFactory;
	public GameObject lifeBar;
	public Hive enemyHive;
	public Material playerAntMaterial;

	// Use this for initialization
	public virtual void spawn () {
		roadController = GameObject.Find("Road Controller").GetComponent("RoadController") as RoadController;
		lastPosition = transform.position;
		if (this.enemyHive.tag == "PlayerHive") {
			this.renderer.material = playerAntMaterial;
			if(Constants.multiplayer)
				networkView.RPC("setTexture", RPCMode.Others, true);
		}
	}
	
	[RPC]
	private void setTexture(bool player){
		if(player) this.renderer.material = playerAntMaterial;
	}

	public virtual void Update(){
		if(Constants.multiplayer && Network.isServer)
			networkView.RPC("updateHealth", RPCMode.Others, this.life);
	}
	
	[RPC]
	private void updateHealth(float health){
		this.life = health;
	}

	public Vector2 velocity() {
		return (Vector2) behavior.nextDirection () * speed;
	}

	public Vector3 position() {
		return transform.position;
	}

	public void FixedUpdate(){
		if(Constants.multiplayer && Network.isClient)
			return;
		//Move the ant in its desired direction
		transform.Translate(velocity());
		
		//If there is an ant to attack, attack it
		Ant ant = behavior.antToAttack();
		if(ant != null){
			float distance = Mathf.Sqrt((ant.gameObject.transform.position-transform.position).sqrMagnitude);
			if(distance < this.range){
				ant.doDamage(this.damage * Time.deltaTime);
			}
		}
	}
	
	// After the ant has moved, check that it is still inbound
	void LateUpdate () {
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.rigidbody.angularVelocity = Vector3.zero;
		lifeBar.transform.localScale = new Vector2(life/maxHealth, lifeBar.transform.localScale.y);

		if(Constants.multiplayer && Network.isClient){
			return;
		}

		if(roadController.outsideRoad(transform.position)){
			transform.position = lastPosition;
		}
		lastPosition = transform.position;

	}

	// Take damage from attacking ant
	public void doDamage(float damage){
		if (life <= 0)
			return;
		life -= damage;
		if(life <= 0)
			die();
	}

	// Gets called everytime an ant collides with something
	void OnCollisionEnter(Collision collision) {
		if(Constants.multiplayer && Network.isClient)
			return;
		//If colliding with enemy hive, do dmg and destroy self
		if(collision.gameObject.tag == enemyHive.tag){
			enemyHive.takeDamage(damage);
			die();
		}
	}
	public virtual void die(){
		enemyFactory.GetComponentInChildren<AntFactory>().antsKilled += 1;
		if(Constants.multiplayer && Network.isServer)
			Network.Destroy(this.gameObject);
		else if(!Constants.multiplayer)
			Destroy (this.gameObject);
	}
}