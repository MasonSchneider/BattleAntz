﻿using UnityEngine;
using System.Collections;

public class ArmyAnt : Ant {
	// Use this for initialization
	void Start () {
		speed = Constants.ARMY_ANT_SPEED*(1.0f + upgrades[0]*Constants.UPGRADE_FRACTION);
		damage = Constants.ARMY_ANT_DAMAGE*(1.0f + upgrades[2]*Constants.UPGRADE_FRACTION);
		life = maxHealth = Constants.ARMY_ANT_LIFE*(1.0f + upgrades[1]*Constants.UPGRADE_FRACTION);
		range = Constants.ARMY_ANT_RANGE;

		if(upgrades[Constants.U_SPECIAL] == 1){
			damage += enemyHive.enemyarmyants;
			life += enemyHive.enemyarmyants;
		}
	}

	public override void spawn(){
		base.spawn();
		if (this.enemyHive.tag != "PlayerHive") {
			this.renderer.material = playerAntMaterial;
		}
	}

	// Update is called once per frame
	public override void Update () {
		if (this.enemyHive.tag != "PlayerHive") {
			targetAnt = ArmyBehavior.antToAttack();
			direction = ArmyBehavior.nextDirection();
		}
		else{
			targetAnt = DefaultBehavior.antToAttack();
			direction = DefaultBehavior.nextDirection();
		}

		base.Update();
	}

	public override void die(){
		enemyHive.enemyarmyants -= 1;
		Destroy(this.gameObject);
	}
}
