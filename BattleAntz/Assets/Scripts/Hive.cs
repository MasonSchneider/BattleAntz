using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {
	int WORKER_COST = 10;
	int WORKER_PRODUCTION = 5;
	int ANT_COST = 10;
	public int sugar;
	public int health;
	private int workers;
	int income; // 10 Sugar per second base production
	// Use this for initialization
	void Start () {
		income  = 1;
		sugar = 100;
		health = 100;
	}
	
	// Update is called once per frame (60fps?)
	void Update () {
		sugar += income + workers*WORKER_PRODUCTION;
	}
	
	// Buy a certain number of workers.
	void buyWorker(int n){
		sugar -= n * WORKER_COST;
		workers += n;
	}
	
	void buyAnt(int n){
		sugar -= n * ANT_COST;
		// SPAWN N ants
	}
	
	void takeDamage(int damage){
		health -= damage;
	}
}