// AntFlockingBehavior Algorithm object
// by Isaac Sanders, Winter 2014
using UnityEngine;
using System.Collections.Generic;


public class FlockingCalculator : object {
	public float ALIGNMENT_WEIGHT = 1.0f;
	public float SEPARATION_WEIGHT = 1.0f;
	public float COHESION_WEIGHT = 1.0f;
	public float POSITION_WEIGHT = 1.0F;
	public float THREAT_WEIGHT = 1.0f;
	public int NEIGHBOR_COUNT = 4;
	public float MIN_DISTANCE = 5.0f;
	public float MAX_DISTANCE = 10.0f;

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

	Vector2 nextThreatVelocity ()
	{
		if (this.enemyFlock.Length > 0) {
			Ant closestAnt = this.enemyFlock[0];
			foreach (Ant enemy in this.enemyFlock) {
				if (enemy.position().x < closestAnt.position().x) {
					closestAnt = enemy;
				}
			}
			return closestAnt.position() - unit.position();
		} else {
			return Vector2.zero;
		}
	}

	public Vector2 nextVelocity() {
		Vector2 cohesion = nextCohesionVelocity ();
		Vector2 separation = nextSeparationVelocity ();
		Vector2 alignment = nextAlignmentVelocity ();
		Vector2 position = nextDesiredPosition ();
		Vector2 threat = nextThreatVelocity();
		Debug.Log("Cohesion:   " + cohesion);
		Debug.Log("Separation: " + separation);
		Debug.Log("Alignment:  " + alignment);
		Debug.Log("Position:   " + position);
		Debug.Log("ThreatPos:  " + threat);

		return 	alignment * ALIGNMENT_WEIGHT + 
				separation * SEPARATION_WEIGHT + 
				cohesion * COHESION_WEIGHT +
				threat * THREAT_WEIGHT + 
				position;
	}

	Vector2 nextDesiredPosition(){
		return Vector2.zero - flockCenter(allyFlock);
//		Vector2 desiredPosition;
//		if(enemyFlock.Length == 0){
//			Vector2 center = flockCenter(allyFlock);
//			desiredPosition = new Vector2(center.x + 1.3f, center.y);
//		}
//		else{
//			Vector2 center = flockCenter(enemyFlock);
//			float distance = Vector2.Distance(center, flockCenter(allyFlock));
//			if( distance < 10 )
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

	Vector2 nextAlignmentVelocity() {
		Vector2 sum = Vector2.zero;
		foreach(Ant other in allyFlock) {
			if (other != unit && shouldAlignWith(other)) {
				sum += (Vector2) other.velocity();
			}
		}
		return sum * (1.0f / allyFlock.Length);
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

