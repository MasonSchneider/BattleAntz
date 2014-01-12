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

	private int ants_created = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void spawnArmyAnt(){
		ArmyAnt a = (ArmyAnt) Instantiate (this.armyAnt, spawnPosition.transform.position, Quaternion.identity);
		setupAnt(a);
	}
	
	public void spawnFireAnt(){
		FireAnt a = (FireAnt) Instantiate (this.fireAnt, spawnPosition.transform.position, Quaternion.identity);
		setupAnt(a);
	}
	
	public void spawnBullAnt(){
		BullAnt a = (BullAnt) Instantiate (this.bullAnt, spawnPosition.transform.position, Quaternion.identity);
		setupAnt(a);
	}

	//Set the correct parameters for the ant to be created
	private void setupAnt(Ant a){
		a.transform.parent = this.transform;
		a.enemyHive = enemyHive;
		a.enemyFactory = enemyFactory;
		a.ID = ants_created++;
		a.spawn();
	}

}
