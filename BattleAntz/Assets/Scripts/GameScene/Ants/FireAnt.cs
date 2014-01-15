using UnityEngine;
using System.Collections;

public class FireAnt : Ant {

	// Use this for initialization
	void Start () {
		speed = 0.1f*(1 + upgrades[0]*1.0f/3.0f);
		damage = 50 + upgrades[2]*10;
		life = 50 + upgrades[1]*10;
		range = 2.5f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
