using UnityEngine;
using System.Collections;

public class ArmyAnt : Ant {

	// Use this for initialization
	void Start () {
		speed = 0.2f;
		damage = 10;
		life = 50;
		range = 1;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
