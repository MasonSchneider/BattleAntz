using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {
	int WORKER_COST = 50;
	int WORKER_PRODUCTION = 10;
	int ARMY_ANT_COST = 50;
	int BULL_ANT_COST = 100;
	int FIRE_ANT_COST = 150;
	int ANT_COST = 10; // ONLY FOR DEBUGGING PURPOSES

	public int sugar;
	public int health;
	private int workers;
	int income; // 10 Sugar per second base production
	public Hive(){ // Constructor
		Start ();
	}
	// Use this for initialization
	void Start () {
		income  = 10;
		sugar = 100;
		health = 100;
	}
	
	// Update is called once per frame (60fps?)
	void Update () {
		sugar += income + workers*WORKER_PRODUCTION;
	}
	
	// Buy a certain number of workers.
	void buyWorker(int n){
		if(sugar > n*WORKER_COST){
			sugar -= n * WORKER_COST;
			workers += n;
		}
	}
	
	void buyAnt(int n){
		if (sugar > n * ANT_COST) {
			sugar -= n * ANT_COST;
			// TODO: SPAWN N ants
		}
	}
	
	void takeDamage(int damage){
		health -= damage;
		if (health <= 0) {
			// TODO: end game
		}
	}

	void upgrade(string upgrade){
		// worker speed, armyant health, bullant strength, fireant special
		//string ant = upgrade.Split[0]
		//string cate = upgrade.Split[1]
	}
}