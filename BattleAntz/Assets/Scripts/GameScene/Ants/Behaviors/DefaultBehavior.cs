using UnityEngine;
using System.Collections;

public class DefaultBehavior : Behavior {
	
	public DefaultBehavior(Ant a){
		ant = a;
	}
	
	//Return the direction to move in
	public override Vector3 nextDirection(){
		Ant antTarget = getNearestAnt();
		GameObject target = antTarget==null ? ant.enemyHive.gameObject : antTarget.gameObject;
		Vector3 offset = target.transform.position-ant.transform.position;
		float length = Mathf.Sqrt(offset.sqrMagnitude);

		return new Vector3(offset.x/length, offset.y/length, 0);
	}
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public override Ant antToAttack(){
		return getNearestAnt();
	}

}
