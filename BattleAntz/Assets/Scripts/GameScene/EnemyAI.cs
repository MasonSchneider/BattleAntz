using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private int strategy = 2;
	private float t;
	
	public AntFactory enemyFactory;
	public AntFactory computerFactory;
	public Hive hive;
	// Use this for initialization
	void Start () {
		t = Time.time + 1;
	}
	
	// Update is called once per frame
	void Update () {

		//Just build and army ant every two seconds
		if(strategy == 0 && Time.time > t) {
			t = Time.time + 2;
			hive.buyArmyAnt();
		}

		//Build a worker and a random ant
		else if(strategy == 1 && hive.sugar > 650){
			while(hive.sugar > 100){
				hive.buyWorker();
				int r = Random.Range(0, 4);
				if(r == 0)
					hive.buyArmyAnt();
				else if(r == 1)
					hive.buyBullAnt();
				else if(r == 2)
					hive.buyFireAnt();
			}
		}

		else if(strategy == 2)
			macroCounterStrat();
	}

	//Build the same amount of units the enemy has or else workers
	private void macroCounterStrat(){
		Ant[] computerAnts = computerFactory.GetComponentsInChildren<Ant>();
		Ant[] enemyAnts = enemyFactory.GetComponentsInChildren<Ant>();
		
		int cArmyAnts = numberAnts(computerAnts, "ArmyAnt");
		int cBullAnts = numberAnts(computerAnts, "BullAnt");
		int cFireAnts = numberAnts(computerAnts, "FireAnt");

		int eArmyAnts = numberAnts(enemyAnts, "ArmyAnt");
		int eBullAnts = numberAnts(enemyAnts, "BullAnt");
		int eFireAnts = numberAnts(enemyAnts, "FireAnt");
		
		if(cArmyAnts < eArmyAnts)
			spawnArmyAnts(eArmyAnts - cArmyAnts);
		
		if(cBullAnts < eBullAnts)
			spawnBullAnts(eBullAnts - cBullAnts);
		
		if(cFireAnts < eFireAnts)
			spawnFireAnts(eFireAnts - cFireAnts);

		hive.buyWorker();
	}

	//Get number of ants from either computer or player
	private int numberAnts(Ant[] ants, string tag){
		int count = 0;
		foreach(Ant a in ants){
			if(a.tag == tag)
				count++;
		}
		return count;
	}

	//Spawn n army ants
	private void spawnArmyAnts(int n){
		for(int i=0; i<n; i++)
			hive.buyArmyAnt();
	}

	//Spawn n bull ants
	private void spawnBullAnts(int n){
		for(int i=0; i<n; i++)
			hive.buyBullAnt();
	}

	//Spawn n fire ants
	private void spawnFireAnts(int n){
		for(int i=0; i<n; i++)
			hive.buyFireAnt();
	}
}
