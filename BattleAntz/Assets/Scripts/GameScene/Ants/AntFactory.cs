using UnityEngine;
using System.Collections;

public class AntFactory : MonoBehaviour {
	public Ant armyAnt;
	public Ant fireAnt;
	public Ant bullAnt;
	public GameObject spawnPosition;
	public GameObject enemyFactory;
	public Hive enemyHive;
	public bool computer;

	public int antsKilled = 0;
	public int ants_created = 0;
	public int totalarmyants = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void spawnArmyAnt(int[] upgrades){
		enemyHive.enemyarmyants += 1;
		ArmyAnt a = (ArmyAnt) Instantiate (this.armyAnt, spawnPosition.transform.position, Quaternion.identity);
		setupAnt(a, upgrades);
	}
	
	public void spawnFireAnt(int[] upgrades){
		FireAnt a = (FireAnt) Instantiate (this.fireAnt, spawnPosition.transform.position, Quaternion.identity);
		setupAnt(a, upgrades);
	}
	
	public void spawnBullAnt(int[] upgrades){
		BullAnt a = (BullAnt) Instantiate (this.bullAnt, spawnPosition.transform.position, Quaternion.identity);
		setupAnt(a, upgrades);
	}

	//Set the correct parameters for the ant to be created
	private void setupAnt(Ant a, int[] upgrades){
		a.transform.parent = this.transform;
		a.enemyHive = enemyHive;
		a.enemyFactory = enemyFactory;
		a.ID = ants_created++;
		a.upgrades = upgrades;
		a.spawn();
	}

}
