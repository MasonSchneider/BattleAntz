using UnityEngine;
using System.Collections;

public class DefaultBehavior : MonoBehaviour {

	
	//Return the direction to move in
	public static Vector3 nextDirection(){
		return Vector2.zero;
	}
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public static Ant antToAttack(){
		return null;
	}

}
