using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {
	float nextTick = 0;
	public int sugar;
	public float health;
	public int workers;
	public int income; // total production of the hive

	public int workersCreated = 0;
	public int sugarProduced = 0;
	int armyantsCreated = 0;
	int fireantsCreated = 0;
	int bullantsCreated = 0;
	public int enemyarmyants = 0;

	// String array storing the current upgrades of the hive
	// 0-indexed, [ant class][upgrade type]
	public int[][] upgrades = new int[4][];
	
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
			nextTick = Time.time + Constants.SUGAR_RATE;
			sugar += income;
			sugarProduced += income;
		}
	}
	
	// Buy a worker
	public bool buyWorker(){
		if(sugar >= Constants.WORKER_COST){
			sugar -= Constants.WORKER_COST;
			workers += 1;
			workersCreated += 1;
			income += (int) (Constants.WORKER_PRODUCTION*(1+(upgrades[Constants.U_WORKER][Constants.U_SPEED]+upgrades[Constants.U_WORKER][Constants.U_STRENGTH])*.10));
			return true;
		}
		return false;
	}

	// Sell a worker.
	public bool sellWorker(){
		if(workers > 0){
			workers -= 1;
			income -= Constants.WORKER_PRODUCTION;
			sugar += Constants.WORKER_COST/Constants.RETURN_VALUE;
			return true;
		}
		return false;
	}

	// Buy an army ant
	public bool buyArmyAnt(){
		if (sugar >= Constants.ARMY_ANT_COST) {
			sugar -= Constants.ARMY_ANT_COST;
			antFactory.spawnArmyAnt(upgrades[Constants.U_ARMYANT]);
			armyantsCreated += 1;
			return true;
		}
		return false;
	}

	//Buy a bull ant
	public bool buyBullAnt(){
		if (sugar >= Constants.BULL_ANT_COST) {
			sugar -= Constants.BULL_ANT_COST;
			antFactory.spawnBullAnt(upgrades[Constants.U_BULLANT]);
			bullantsCreated += 1;
			return true;
		}
		return false;
	}
	
	//Buy a fire ant
	public bool buyFireAnt(){
		if (sugar >= Constants.FIRE_ANT_COST) {
			sugar -= Constants.FIRE_ANT_COST;
			antFactory.spawnFireAnt(upgrades[Constants.U_FIREANT]);
			fireantsCreated += 1;
			return true;
		}
		return false;
	}
	
	public void takeDamage(float damage){
		health -= damage/2;
		if (health <= 0) {
			health = 0;
			endGame();
		}
	}

	public void endGame(){
		if (gameObject.tag == "PlayerHive") {
			if(health <= 0){
				GameObject.Find ("Game Menu").GetComponent<GameOverMenu> ().gameOver ("You Lose!", workersCreated, armyantsCreated, bullantsCreated, fireantsCreated, sugarProduced, antFactory.antsKilled);
			} else {
				GameObject.Find ("Game Menu").GetComponent<GameOverMenu> ().gameOver ("You win!", workersCreated, armyantsCreated, bullantsCreated, fireantsCreated, sugarProduced, antFactory.antsKilled);
			}
		} else {
			antFactory.enemyHive.endGame();
		}

	}

	public bool upgrade(int[] specificupgrade){
		int ant = specificupgrade[0];
		int type = specificupgrade[1];
		if (sugar >= Constants.UPGRADE_COST){ // Check if enough sugar
			if(ant == Constants.U_WORKER){ // TODO: Worker upgrades
				Debug.Log("worker" + ant + " " + type);
				return false;
			}
			else if(type == Constants.U_SPECIAL){
				if (upgrades [ant][type] < 1) { // Check if upgrade not full
					// reduce sugar
					sugar -= Constants.UPGRADE_COST;
					
					// Increase upgrade
					upgrades[ant][type]++;
					Debug.Log("special success " + ant + " " + type);
					return true;
				}
			}
			else if (type == Constants.U_SPEED || type == Constants.U_STRENGTH || type == Constants.U_HEALTH){
				if (upgrades [ant][type] < 2) { // Check if upgrade not full
					// reduce sugar
					sugar -= Constants.UPGRADE_COST;
					// Increase upgrade
					upgrades[ant][type]++;
					Debug.Log("speed str hp success " + ant + " " + type);
					return true;
				}
			}
		}
		Debug.Log ("not success" + ant + " " + type);
		return false;
	}
}