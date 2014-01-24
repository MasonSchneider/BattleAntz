using UnityEngine;
using System.Collections;

public class FireAnt : Ant {
	int radius = 250;
	int BANELING_DAMAGE = 10;
	// Use this for initialization
	void Start () {
		speed = 0.1f*(1 + upgrades[0]*1.0f/3.0f);
		damage = 50 + upgrades[2]*10;
		life = maxHealth = 50 + upgrades[1]*10;
		range = 2.5f;

		//speed = 0.1f;
		//damage = 50;
		//life = maxHealth = 50;
		//range = 2.5f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}

	public override void die(){ // Deal 30 damage to enemies around this ant
		if(upgrades[3] == 1){
			Ant[] ants = enemyFactory.GetComponentsInChildren<Ant>();
			foreach(Ant a in ants){
				Vector2 diff = a.gameObject.transform.position-transform.position;
				if(diff.sqrMagnitude < radius){
					a.doDamage (BANELING_DAMAGE);
				}
			}
		}
		Destroy(this.gameObject);
	}
}
