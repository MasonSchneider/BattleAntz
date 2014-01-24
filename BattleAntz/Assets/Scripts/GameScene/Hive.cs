using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {
	float nextTick = 0;
	
	public int sugar;
	public float health;
	public int workers;
	public int income; // total production of the hive
	private Constants constants;

	// String array storing the current upgrades of the hive
	// 0-indexed, [ant class][upgrade type]
	protected int[][] upgrades = new int[4][];
	
	public AntFactory antFactory;

	// Use this for initialization
	public virtual void Start () {
		constants = gameObject.GetComponent<Constants>();
		upgrades[0] = new int[4];
		upgrades[1] = new int[4];
		upgrades[2] = new int[4];
		upgrades[3] = new int[4];
	}
	
	// Update is called once per frame (60fps?)
	public virtual void Update () {
		if (Time.time > nextTick) {
			nextTick = Time.time + constants.SUGAR_RATE;
			sugar += income;
		}
	}
	
	// Buy a worker
	public bool buyWorker(){
		if(sugar >= constants.WORKER_COST){
			sugar -= constants.WORKER_COST;
			workers += 1;
			income += (int) (constants.WORKER_PRODUCTION*(1+(upgrades[constants.U_WORKER][constants.U_SPEED]+upgrades[constants.U_WORKER][constants.U_STRENGTH])*.10));
			return true;
		}
		return false;
	}

	// Sell a worker.
	public bool sellWorker(){
		if(workers > 0){
			workers -= 1;
			income -= constants.WORKER_PRODUCTION;
			sugar += constants.WORKER_COST/constants.RETURN_VALUE;
			return true;
		}
		return false;
	}

	// Buy an army ant
	public bool buyArmyAnt(){
		if (sugar >= constants.ARMY_ANT_COST) {
			sugar -= constants.ARMY_ANT_COST;
			antFactory.spawnArmyAnt(upgrades[constants.U_ARMYANT]);
			return true;
		}
		return false;
	}

	//Buy a bull ant
	public bool buyBullAnt(){
		if (sugar >= constants.BULL_ANT_COST) {
			sugar -= constants.BULL_ANT_COST;
			antFactory.spawnBullAnt(upgrades[constants.U_BULLANT]);
			return true;
		}
		return false;
	}
	
	//Buy a fire ant
	public bool buyFireAnt(){
		if (sugar >= constants.FIRE_ANT_COST) {
			sugar -= constants.FIRE_ANT_COST;
			antFactory.spawnFireAnt(upgrades[constants.U_FIREANT]);
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
		if (sugar >= constants.UPGRADE_COST){ // Check if enough sugar
			if(a == constants.U_WORKER){ // TODO: Worker upgrades
				Debug.Log("worker" + a + " " + b);
				return false;
			}
			else if(b == constants.U_SPECIAL){
				if (upgrades [a][b] < 1) { // Check if upgrade not full
					// reduce sugar
					sugar -= constants.UPGRADE_COST;

					// Increase upgrade
					upgrades[a][b]++;
					Debug.Log("special success " + a + " " + b);
					return true;
				}
			}
			else if (b == constants.U_SPEED || b == constants.U_STRENGTH || b == constants.U_HEALTH){
				if (upgrades [a][b] < 2) { // Check if upgrade not full
					// reduce sugar
					sugar -= constants.UPGRADE_COST;
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