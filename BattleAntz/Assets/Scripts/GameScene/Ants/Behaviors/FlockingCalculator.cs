// AntFlockingBehavior Algorithm object
// by Isaac Sanders, Winter 2014
using UnityEngine;
using System.Collections.Generic;


public class FlockingCalculator : object {
	public static float ALIGNMENT_WEIGHT = 1.0f / 3.0f;
	public static float SEPARATION_WEIGHT = 1.0f / 3.0f;
	public static float COHESION_WEIGHT = 1.0f / 3.0f;
	public static float POSITION_WEIGHT = 2.0F;
	public static int NEIGHBOR_COUNT = 4;
	public static float MIN_DISTANCE = 0.0f;
	public static float MAX_DISTANCE = 5.0f;

	private Ant unit;
	private Ant[] allyFlock;
	private Ant[] enemyFlock;

	public FlockingCalculator (Ant unit) {
		this.unit = unit;
	}

	public void setFlocks(Ant[] allyFlock, Ant[] enemyFlock) {
		this.allyFlock = allyFlock;
		this.enemyFlock = enemyFlock;
	}

	public Vector2 nextVelocity() {
		return 	nextAlignmentVelocity () * ALIGNMENT_WEIGHT + 
				nextSeparationVelocity () * SEPARATION_WEIGHT + 
				nextCohesionVelocity () * COHESION_WEIGHT + 
				nextDesiredPosition();
	}

	Vector2 nextDesiredPosition(){
		Vector2 desiredPosition;
		if(enemyFlock.Length == 0){
			Vector2 center = flockCenter(allyFlock);
			desiredPosition = new Vector2(center.x + POSITION_WEIGHT, center.y);
		}
		else{
			desiredPosition = flockCenter(enemyFlock).normalized;
		}
		return desiredPosition;
	}

	Vector2 flockCenter(Ant[] flock){
		Vector2 flockCenter = Vector2.zero;
		foreach(Ant ant in flock) {
			flockCenter = flockCenter + (Vector2) ant.transform.position;
		}
		flockCenter = flockCenter / (flock.Length );
		return (flockCenter - (Vector2) unit.position());
	}

	Vector2 nextAlignmentVelocity() {
		Vector2 sum = Vector2.zero;
		foreach(Ant other in allyFlock) {
			if (other != unit && shouldAlignWith(other)) {
				sum += (Vector2) other.velocity();
			}
		}
		return sum * (1.0f / NEIGHBOR_COUNT);
	}
	
	bool shouldAlignWith (Ant other) {
		float dist = distance (other);
		return MIN_DISTANCE <= dist && MAX_DISTANCE >= dist;
	}	

	Vector2 nextSeparationVelocity () {
		Vector2 sum = Vector2.zero;
		foreach (Ant other in allyFlock) {
			if (other != unit && shouldSeparateFrom(other)) {
				sum += (Vector2) (unit.velocity() + other.velocity()) / distance (other);
			}
		}
		return sum;
	}

	bool shouldSeparateFrom (Ant other) {
		return distance (other) <= MIN_DISTANCE;
	}

	Vector2 nextCohesionVelocity () {
		Vector2 sum = Vector2.zero;
		foreach (Ant other in allyFlock) {
			if (other != unit && shouldAlignWith(other)) {
				sum += (Vector2) (unit.position() - other.position());
			}
		}
		return sum;
	}

	float distance(Ant other) {
		return Vector2.Distance (unit.position(), other.position());
	}
}

