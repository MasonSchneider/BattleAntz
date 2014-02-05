using UnityEngine;
using System.Collections;

public class FireBehavior : Behavior {
	
	public FireBehavior(Ant a){
		ant = a;
	}

	//Return the direction to move in
	public override Vector3 nextDirection(){
		return Vector2.zero;
	}
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public override Ant antToAttack(){
		return null;
	}
}
