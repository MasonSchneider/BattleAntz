using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {
	float nextTick = 0;
	int SUGAR_RATE = 1;
	int BASE_PRODUCTION = 10;
	int WORKER_COST = 50;
	int WORKER_PRODUCTION = 10;
	int ARMY_ANT_COST = 50;
	int BULL_ANT_COST = 100;
	int FIRE_ANT_COST = 150;
	int RETURN_VALUE = 2;
	int ANT_COST = 10; // ONLY FOR DEBUGGING PURPOSES

	public int sugar;
	public int health;
	public int workers;
	public int income; // total production of the hive

	private AntController antController;

	// Use this for initialization
	void Start () {
		income  = BASE_PRODUCTION;
		sugar = 100;
		health = 100;
		antController = GameObject.Find("Ant Controller").GetComponent("AntController") as AntController;
	}
	
	// Update is called once per frame (60fps?)
	void Update () {
		Debug.Log (sugar);
		if (Time.time > nextTick) {
			nextTick = Time.time + SUGAR_RATE;
			sugar += income;
		}
	}
	
	// Buy a worker
	public bool buyWorker(){
		if(sugar >= WORKER_COST){
			sugar -= WORKER_COST;
			workers += 1;
			income += WORKER_PRODUCTION;
			return true;
		}
		return false;
	}
	// Sell a worker.
	public bool sellWorker(){
		if(workers > 0){
			workers -= 1;
			income -= WORKER_PRODUCTION;
			sugar += WORKER_COST/RETURN_VALUE;
			antController.spawnAnt();
			return true;
		}
		return false;
	}

	// Buy an army ant
	public bool buyArmyAnt(){
		if (sugar >= ARMY_ANT_COST) {
			sugar -= ANT_COST;
			// TODO create army ant
			return true;
		}
		return false;
	}
	
	public void takeDamage(int damage){
		health -= damage;
		if (health <= 0) {
			// TODO: end game
		}
	}

	public void upgrade(string upgrade){
		// worker speed, armyant health, bullant strength, fireant special
		//string ant = upgrade.Split[0]
		//string cate = upgrade.Split[1]
	}
}