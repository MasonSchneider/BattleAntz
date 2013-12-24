using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Hive hive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hive.sugar > 200){
			if(Random.Range(0,2) == 0)
				hive.buyFireAnt();
			else
				hive.buyArmyAnt();
		}
	}
}
