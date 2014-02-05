using UnityEngine;
using System.Collections;

public class FireAnt : Ant {
	// Use this for initialization
	void Start () {
		speed = Constants.FIRE_ANT_SPEED*(1.0f + upgrades[0]*Constants.UPGRADE_FRACTION);
		damage = Constants.FIRE_ANT_DAMAGE*(1.0f + upgrades[2]*Constants.UPGRADE_FRACTION);
		life = maxHealth = Constants.FIRE_ANT_LIFE*(1.0f + upgrades[1]*Constants.UPGRADE_FRACTION);
		range = Constants.FIRE_ANT_RANGE;
		behavior = new DefaultBehavior(this);
	}
	
	public override void spawn(){
		//This is an enemy, right spawn
		if (this.enemyHive.tag == "PlayerHive") {
			behavior = new FireBehavior(this);
		}
		//This is the player, left spawn
		else{
			behavior = new DefaultBehavior(this);
		}
		base.spawn();
	}

	public override void die(){ // Deal 30 damage to enemies around this ant
		enemyFactory.GetComponentInChildren<AntFactory>().antsKilled += 1;
		if(upgrades[3] == 1){
			Ant[] ants = enemyFactory.GetComponentsInChildren<Ant>();
			foreach(Ant a in ants){
				Vector2 diff = a.gameObject.transform.position-transform.position;
				if(diff.sqrMagnitude < Constants.BANELING_RADIUS){
					a.doDamage (Constants.BANELING_DAMAGE);
				}
			}
		}
		Destroy(this.gameObject);
	}
}
