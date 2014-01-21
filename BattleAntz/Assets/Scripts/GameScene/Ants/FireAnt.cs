using UnityEngine;
using System.Collections;

public class FireAnt : Ant {

	// Use this for initialization
	void Start () {

		// WARNING THIS CREATES AN ERROR!!!
//		speed = 0.1f*(1 + upgrades[0]*1.0f/3.0f);
//		damage = 50 + upgrades[2]*10;
//		life = maxHealth = 50 + upgrades[1]*10;


		speed = 0.1f;
		damage = 50;
		life = maxHealth = 50;


		range = 2.5f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}

	public override void die(){
		// Deal 15 damage to everyone around this ant
		Destroy (this.gameObject);
	}
}
