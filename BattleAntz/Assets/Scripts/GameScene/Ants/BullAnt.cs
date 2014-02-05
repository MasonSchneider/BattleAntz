﻿using UnityEngine;
using System.Collections;

public class BullAnt : Ant {
	
	// Use this for initialization
	void Start () {
		speed = Constants.BULL_ANT_SPEED*(1.0f + upgrades[3])*(1.0f + upgrades[0]*Constants.UPGRADE_FRACTION); // special upgrade of bullant +1 AS and MS
		damage = Constants.BULL_ANT_DAMAGE*(1.0f + upgrades[2]*Constants.UPGRADE_FRACTION);
		life = maxHealth = Constants.BULL_ANT_LIFE*(1.0f + upgrades[1]*Constants.UPGRADE_FRACTION);
		range = Constants.BULL_ANT_RANGE;
		behavior = new DefaultBehavior(this);
	}
	
	public override void spawn(){
		//This is an enemy, right spawn
		if (this.enemyHive.tag == "PlayerHive") {
			behavior = new BullBehavior(this);
		}
		//This is the player, left spawn
		else{
			behavior = new DefaultBehavior(this);
		}
		base.spawn();
	}
}
