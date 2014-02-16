using UnityEngine;
using System.Collections;

public class ArmyAnt : Ant {

	void Start () {
		maxHealth = Constants.ARMY_ANT_LIFE;
		if(Constants.multiplayer && Network.isClient)
			return;
		speed = Constants.ARMY_ANT_SPEED*(1.0f + upgrades[0]*Constants.UPGRADE_FRACTION);
		damage = Constants.ARMY_ANT_DAMAGE*(1.0f + upgrades[2]*Constants.UPGRADE_FRACTION);
		life = Constants.ARMY_ANT_LIFE*(1.0f + upgrades[1]*Constants.UPGRADE_FRACTION);
		range = Constants.ARMY_ANT_RANGE;

		if(upgrades[Constants.U_SPECIAL] == 1){
			damage += enemyHive.enemyarmyants;
			life += enemyHive.enemyarmyants;
		}
	}

	public override void spawn(){
		//This is an enemy, right spawn
		if (this.enemyHive.tag == "PlayerHive") {
			behavior = new FlockingBehavior(this);
		}
		//This is the player, left spawn
		else{
			behavior = new FlockingBehavior(this);
		}
		base.spawn();
	}

	public override void die(){
		enemyHive.enemyarmyants -= 1;
		base.die();
	}
}
