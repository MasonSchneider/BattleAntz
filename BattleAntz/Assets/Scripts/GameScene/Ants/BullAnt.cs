using UnityEngine;
using System.Collections;

public class BullAnt : Ant {
	
	// Use this for initialization
	void Start () {
		speed = 0.05f*(1 + upgrades[3])*(1 + upgrades[0]*1.0f/3.0f); // special upgrade of bullant +1 AS and MS
		damage = 30 + upgrades[2]*6;
		life = maxHealth =100 + upgrades[1]*20;
		range = 1;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}

	public override void die(){
		Destroy (this.gameObject);
	}
}
