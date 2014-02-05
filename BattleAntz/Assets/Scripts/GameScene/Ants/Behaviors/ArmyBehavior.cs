using UnityEngine;
using System.Collections;

public class ArmyBehavior : Behavior {
	
	public ArmyBehavior(Ant a){
		ant = a;
	}

	//Return the direction to move in
	public override Vector3 nextDirection(){
		Ant antTarget = getLowestAnt();
		GameObject target = antTarget==null ? ant.enemyHive.gameObject : antTarget.gameObject;
		Vector3 offset = target.transform.position-ant.transform.position;
		float length = Mathf.Sqrt(offset.sqrMagnitude);
		
		return new Vector3(offset.x/length, offset.y/length, 0);
	}
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public override Ant antToAttack(){
		//Attack the ant with lowest health
		return getLowestAnt();
	}
}
