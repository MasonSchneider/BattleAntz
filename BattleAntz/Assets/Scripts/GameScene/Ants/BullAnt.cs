using UnityEngine;
using System.Collections;

public class BullAnt : Ant {
	
	// Use this for initialization
	void Start () {
		speed = 0.05f;
		damage = 30;
		life = 100;
		range = 1;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
