using UnityEngine;
using System.Collections;

public class ArmyAnt : Ant {

	// Use this for initialization
	void Start () {
		speed = 0.2f*(1 + upgrades[0]*1.0f/3.0f);
		damage = 10 + upgrades[2]*3;
		life = 50 + upgrades[1]*10;
		range = 1;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
