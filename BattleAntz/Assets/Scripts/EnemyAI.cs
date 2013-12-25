using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Hive hive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hive.sugar > 650){
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
	}
}
