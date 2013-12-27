using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private int strategy = 1;
	private float t;
	public Hive hive;
	// Use this for initialization
	void Start () {
		t = Time.time + 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(strategy == 0 && Time.time > t) {
			t = Time.time + 2;
			hive.buyArmyAnt();
		}

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
	}
}
