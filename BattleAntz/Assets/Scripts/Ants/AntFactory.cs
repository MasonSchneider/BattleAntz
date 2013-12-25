using UnityEngine;
using System.Collections;

public class AntFactory : MonoBehaviour {
	public Ant armyAnt;
	public Ant fireAnt;
	public Ant bullAnt;
	public GameObject spawnPosition;
	public GameObject targetPosition;

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

	private void setupAnt(Ant a){
		a.transform.parent = this.transform;
		a.target = targetPosition.transform.position;
		a.spawn();
	}

}
