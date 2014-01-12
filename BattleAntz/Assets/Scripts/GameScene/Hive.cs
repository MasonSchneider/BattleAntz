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
	
	const int UPGRADE_COST = 500;

	const int U_WORKER = 0;
	const int U_ARMYANT = 1;
	const int U_BULLANT = 2;
	const int U_FIREANT = 3;
	
	const int U_SPEED = 0;
	const int U_HEALTH = 1;
	const int U_STRENGTH = 2;
	const int U_SPECIAL = 3;
	
	public int sugar;
	public float health;
	public int workers;
	public int income; // total production of the hive

	// String array storing the current upgrades of the hive
	// 0-indexed, [ant class][upgrade type]
	protected int[][] upgrades = new int[4][];
	
	public AntFactory antFactory;

	// Use this for initialization
	public virtual void Start () {
		upgrades[0] = new int[4];
		upgrades[1] = new int[4];
		upgrades[2] = new int[4];
		upgrades[3] = new int[4];
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
			antFactory.spawnArmyAnt(upgrades[U_ARMYANT]);
			return true;
		}
		return false;
	}

	//Buy a bull ant
	public bool buyBullAnt(){
		if (sugar >= BULL_ANT_COST) {
			sugar -= BULL_ANT_COST;
			antFactory.spawnBullAnt(upgrades[U_BULLANT]);
			return true;
		}
		return false;
	}
	
	//Buy a fire ant
	public bool buyFireAnt(){
		if (sugar >= FIRE_ANT_COST) {
			sugar -= FIRE_ANT_COST;
			antFactory.spawnFireAnt(upgrades[U_FIREANT]);
			return true;
		}
		return false;
	}
	
	public void takeDamage(float damage){
		health -= damage;
		if (health <= 0) {
			health = 0;
			Application.LoadLevel("EndScene");
		}
	}

	public void upgrade(string u){
		if (sugar >= UPGRADE_COST){ // Check if enough sugar
			if (upgrades [u[0]][u[1]] < 2) { // Check if upgrade not full
				// reduce sugar
				sugar -= UPGRADE_COST;
				// Increase upgrade
				upgrades[u[0]][u[1]]++;
			}
		}
	}
}