using UnityEngine;
using System.Collections;

public class ArmyAnt : Ant {

	// Use this for initialization
	void Start () {
		speed = Constants.ARMY_ANT_SPEED*(1.0f + upgrades[0]*Constants.UPGRADE_FRACTION);
		damage = Constants.ARMY_ANT_DAMAGE*(1.0f + upgrades[2]*Constants.UPGRADE_FRACTION);
		life = maxHealth = Constants.ARMY_ANT_LIFE*(1.0f + upgrades[1]*Constants.UPGRADE_FRACTION);
		range = Constants.ARMY_ANT_LIFE;
	}

	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
