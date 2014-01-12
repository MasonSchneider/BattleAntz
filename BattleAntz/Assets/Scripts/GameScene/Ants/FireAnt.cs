using UnityEngine;
using System.Collections;

public class FireAnt : Ant {

	// Use this for initialization
	void Start () {
		speed = 0.1f;
		damage = 50;
		life = 50;
		range = 2.5f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
