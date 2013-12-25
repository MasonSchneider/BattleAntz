using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {
	float nextTick = 0;
	int SUGAR_RATE = 1;
//	int BASE_PRODUCTION = 10;
	int WORKER_COST = 50;
	int WORKER_PRODUCTION = 10;
	int ARMY_ANT_COST = 50;
	int BULL_ANT_COST = 100;
	int FIRE_ANT_COST = 150;
	int RETURN_VALUE = 2;

	public int sugar;
	public int health;
	public int workers;
	public int income; // total production of the hive

	public AntFactory antFactory;

	// Use this for initialization
	public virtual void Start () {
	}
	
	// Update is called once per frame (60fps?)
	public virtual void Update () {
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
			return true;
		}
		return false;
	}

	// Buy an army ant
	public bool buyArmyAnt(){
		if (sugar >= ARMY_ANT_COST) {
			sugar -= ARMY_ANT_COST;
			antFactory.spawnArmyAnt();
			return true;
		}
		return false;
	}
	
	//Buy a fire ant
	public bool buyFireAnt(){
		if (sugar >= FIRE_ANT_COST) {
			sugar -= FIRE_ANT_COST;
			antFactory.spawnFireAnt();
			return true;
		}
		return false;
	}

	//Buy a bull ant
	public bool buyBullAnt(){
		if (sugar >= BULL_ANT_COST) {
			sugar -= BULL_ANT_COST;
			antFactory.spawnBullAnt();
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
		// string ant = upgrade.Split[0]
		// string cate = upgrade.Split[1]
	}
}