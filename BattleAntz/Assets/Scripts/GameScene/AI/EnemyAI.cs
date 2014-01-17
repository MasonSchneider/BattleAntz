using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private int strategy = 0;
	private float t;
	private float lastSpawn;
	private float nextIndex = 0;

	public AntFactory enemyFactory;
	public AntFactory computerFactory;
	public Hive hive;
	public int level;
	public float[,] schedule;

	// Use this for initialization
	void Start () {
		t = Time.time;
		schedule = LevelAI.getLevel(level);
		lastSpawn = Time.time;
	}

	void preScheduleAI(){
		for(int i=0; i<schedule.Length/3; i++){
			float time = schedule[i,0];
			if(Time.time > lastSpawn + time && i == nextIndex){
				lastSpawn += time;
				nextIndex = i<schedule.Length/3-1 ? i+1 : 0;
				if(schedule[i,1] == Publics.WORKER)
					spawnWorkers((int)schedule[i,2]);

				else if(schedule[i,1] == Publics.ARMYANT)
					spawnArmyAnts((int)schedule[i,2]);

				else if(schedule[i,1] == Publics.BULLANT)
					spawnBullAnts((int)schedule[i,2]);

				else if(schedule[i,1] == Publics.FIREANT)
					spawnFireAnts((int)schedule[i,2]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(strategy == 0){
			preScheduleAI();
		}

		//Just build and army ant every two seconds
		if(strategy == 1 && Time.time > t) {
			t = Time.time + 2;
			hive.buyArmyAnt();
		}

		//Build a worker and a random ant
		else if(strategy == 2 && hive.sugar > 650){
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

		else if(strategy == 3)
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
	
	//Spawn n workers
	private void spawnWorkers(int n){
		for(int i=0; i<n; i++)
			hive.buyWorker();
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
