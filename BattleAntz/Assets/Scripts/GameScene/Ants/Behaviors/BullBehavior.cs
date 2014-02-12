using UnityEngine;
using System.Collections;

public class BullBehavior : Behavior {
	
	public BullBehavior(Ant a){
		ant = a;
	}

	//Return the direction to move in
	public override Vector2 nextDirection(){
		return Vector2.zero;
	}
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public override Ant antToAttack(){
		return null;
	}
}
