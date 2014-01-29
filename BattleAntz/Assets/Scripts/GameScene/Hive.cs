using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {
	float nextTick = 0;
	
	public int sugar;
	public float health;
	public int workers;
	public int income; // total production of the hive

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
		}
	}
	
	// Buy a worker
	public bool buyWorker(){
		if(sugar >= Constants.WORKER_COST){
			sugar -= Constants.WORKER_COST;
			workers += 1;
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
			return true;
		}
		return false;
	}

	//Buy a bull ant
	public bool buyBullAnt(){
		if (sugar >= Constants.BULL_ANT_COST) {
			sugar -= Constants.BULL_ANT_COST;
			antFactory.spawnBullAnt(upgrades[Constants.U_BULLANT]);
			return true;
		}
		return false;
	}
	
	//Buy a fire ant
	public bool buyFireAnt(){
		if (sugar >= Constants.FIRE_ANT_COST) {
			sugar -= Constants.FIRE_ANT_COST;
			antFactory.spawnFireAnt(upgrades[Constants.U_FIREANT]);
			return true;
		}
		return false;
	}
	
	public void takeDamage(float damage){
		health -= damage/2;
		if (health <= 0) {
			health = 0;
			if(gameObject.tag == "PlayerHive"){
				GameObject.Find("Game Menu").GetComponent<GameOverMenu>().gameOver("You lose!");
			}
			else{
				GameObject.Find("Game Menu").GetComponent<GameOverMenu>().gameOver("You win!");
			}
		}
	}

	public bool upgrade(int[] specificupgrade){
		int a = specificupgrade [0];
		int b = specificupgrade [1];
		if (sugar >= Constants.UPGRADE_COST){ // Check if enough sugar
			if(a == Constants.U_WORKER){ // TODO: Worker upgrades
				Debug.Log("worker" + a + " " + b);
				return false;
			}
			else if(b == Constants.U_SPECIAL){
				if (upgrades [a][b] < 1) { // Check if upgrade not full
					// reduce sugar
					sugar -= Constants.UPGRADE_COST;

					// Increase upgrade
					upgrades[a][b]++;
					Debug.Log("special success " + a + " " + b);
					return true;
				}
			}
			else if (b == Constants.U_SPEED || b == Constants.U_STRENGTH || b == Constants.U_HEALTH){
				if (upgrades [a][b] < 2) { // Check if upgrade not full
					// reduce sugar
					sugar -= Constants.UPGRADE_COST;
					// Increase upgrade
					upgrades[a][b]++;
					Debug.Log("speed str hp success " + a + " " + b);
					return true;
				}
			}
		}
		Debug.Log ("not success" + a + " " + b);
		return false;
	}
}