using UnityEngine;
using System.Collections;

public class ArmyBehavior : Behavior {
	
	public ArmyBehavior(Ant a){
		ant = a;
	}

	//Return the direction to move in
	public override Vector2 nextDirection(){
		Ant antTarget = getLowestAnt();
		GameObject target = antTarget==null ? ant.enemyHive.gameObject : antTarget.gameObject;
		Vector2 offset = target.transform.position-ant.transform.position;
		float length = Mathf.Sqrt(offset.sqrMagnitude);
		
		return new Vector2(offset.x/length, offset.y/length);
	}
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public override Ant antToAttack(){
		//Attack the ant with lowest health
		return getLowestAnt();
	}
}
