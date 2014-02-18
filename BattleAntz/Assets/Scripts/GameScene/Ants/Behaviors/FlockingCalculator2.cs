using UnityEngine;
using System.Collections;

public class FlockingCalculator2 : object {
	public float SEPARATION_DIST 	= 1.3f;
	public float SEPARATION_ARMY 	= 30f;
	public float SEPARATION_BULL 	= 10f;
	public float SEPARATION_FIRE 	= 50f;
	public float COHESION		 	= 5.0f;
	public float ALIGNMENT		 	= 1.0f;
	public float POSITION		 	= 1.0f;
	public float THREAT			 	= 1.0f;

	private Ant unit;
	private Ant[] allyFlock;
	private Ant[] enemyFlock;
	
	public FlockingCalculator2 (Ant unit) {
		this.unit = unit;
	}
	
	public void setFlocks(Ant[] allyFlock, Ant[] enemyFlock){
		this.allyFlock = allyFlock;
		this.enemyFlock = enemyFlock;
	}
	
	public Vector2 nextVelocity() {
		Vector2 separationArmy 	= Separation<ArmyAnt>(allyFlock) * SEPARATION_ARMY;
		Vector2 separationBull 	= Separation<BullAnt>(allyFlock) * SEPARATION_BULL;
		Vector2 separationFire 	= Separation<FireAnt>(allyFlock) * SEPARATION_FIRE;
		Vector2 cohesion 		= Cohesion() * COHESION;
		Vector2 alignment 		= Alignment() * ALIGNMENT;
		Vector2 threat	 		= nextThreatVelocity() * THREAT;
//		Vector2 position 		= nextDesiredPosition() * POSITION;

//		Debug.Log("Cohesion:   " + cohesion);
//		Debug.Log("SeparaArmy: " + separationArmy);
//		Debug.Log("SeparaBull: " + separationBull);
//		Debug.Log("SeparaFire: " + separationFire);
//		Debug.Log("Alignment:  " + alignment);
//		Debug.Log("Position:   " + position);
//		Debug.Log("ThreatPos:  " + v5);
		return cohesion + alignment + separationArmy + separationBull + separationFire + threat;
	}
	
	Vector2 nextThreatVelocity (){
		if (this.enemyFlock.Length > 0) {
			Ant closestAnt = this.enemyFlock[0];
			foreach (Ant enemy in this.enemyFlock) {
				if (enemy.position().x < closestAnt.position().x) {
					closestAnt = enemy;
				}
			}
			return closestAnt.position() - unit.position();
		} else {
			return flockCenter(allyFlock) + new Vector2(100, 0);
		}
	}

	Vector2 nextDesiredPosition(){
		Vector2 mouseWorld = (GameObject.Find("Main Camera").GetComponent("Camera") as Camera).ScreenToWorldPoint(Input.mousePosition);
		return mouseWorld - flockCenter(allyFlock);
//		Vector2 desiredPosition;
//		if(enemyFlock.Length == 0){
//			Vector2 center = flockCenter(allyFlock);
//			desiredPosition = new Vector2(center.x + 1.3f, center.y);
//		}
//		else{
//			Vector2 center = flockCenter(enemyFlock);
//			float distance = Vector2.Distance(center, flockCenter(allyFlock));
//			if( distance < 15 )
//				desiredPosition = flockCenter(enemyFlock).normalized;
//			else{
//				center = flockCenter(allyFlock);
//				desiredPosition = new Vector2(center.x + 1.3f, center.y);
//			}
//		}
//		return desiredPosition;
	}
	
	Vector2 flockCenter(Ant[] flock){
		Vector2 flockCenter = Vector2.zero;
		foreach(Ant ant in flock) {
			flockCenter = flockCenter + (Vector2) ant.position();
		}
		return (flockCenter / flock.Length);
	}

	private Vector2 Cohesion () {
		if(allyFlock.Length < 2) return Vector2.zero;
		Vector2 cohesion = Vector2.zero;
		foreach (Ant other in allyFlock) {
			if (unit != other) {
				cohesion += (Vector2) other.position();	
			}
		}
		cohesion /= (allyFlock.Length - 1);
		return cohesion - (Vector2)unit.position();
	}
	
	private Vector2 Separation<T>(Ant[] flock){
		if(allyFlock.Length < 2) return Vector2.zero;
		Vector2 separation = Vector2.zero;
		foreach (Ant other in flock) {
			if (unit != other && other.GetType() == typeof(T)) {
				if (Vector3.Distance (other.position(), unit.position()) < SEPARATION_DIST) {
					separation -= (Vector2)(other.position() - unit.position());
				}
			}
		}
		return separation;
	}
	
	private Vector2 Alignment () {
		if(allyFlock.Length < 2) return Vector2.zero;
		Vector2 alignemnt = Vector3.zero;
		foreach (Ant other in allyFlock) {
			if (unit != other) {
				alignemnt += other.velocity();	
			}
		}
		alignemnt /= (allyFlock.Length - 1);
		return alignemnt - (Vector2)unit.position();
	}

}
