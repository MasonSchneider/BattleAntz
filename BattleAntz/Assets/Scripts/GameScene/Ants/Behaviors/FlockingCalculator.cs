// AntFlockingBehavior Algorithm object
// by Isaac Sanders, Winter 2014
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class FlockingCalculator : object {
	public static float ALIGNMENT_WEIGHT = 0.4f;
	public static float SEPARATION_WEIGHT = 0.4f;
	public static float COHESION_WEIGHT = 1.1f;
	public static float THREAT_WEIGHT = 1.2f;
	public static int NEIGHBOR_COUNT = 10;
	public static float MIN_NEIGHBOR_DISTANCE = 0.2f;
	public static float MAX_NEIGHBOR_DISTANCE = 1.0f;
	public static float MIN_THREAT_DISTANCE = 9.0f;
	public static float MAX_THREAT_DISTANCE = 10.0f;

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

	Vector2 nextThreatVelocity () {
		ThreatMap threatMap = new ThreatMap();
		return threatMap.getTarget(unit, enemyFlock) - (Vector2) unit.position();
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
		IEnumerable<Ant> neighbors = localNeighbors();
		foreach(Ant other in neighbors) {
			if (other != unit && shouldAlignWith(other)) {
				sum += (Vector2) other.velocity();
			}
		}
		return sum * (1.0f / NEIGHBOR_COUNT);
	}
	
	bool shouldAlignWith (Ant other) {
		float dist = distance (other);
		return MIN_NEIGHBOR_DISTANCE <= dist && MAX_NEIGHBOR_DISTANCE >= dist;
	}	

	Vector2 nextSeparationVelocity () {
		Vector2 sum = Vector2.zero;
		IEnumerable<Ant> neighbors = localNeighbors();
		foreach (Ant other in neighbors) {
			if (other != unit && shouldSeparateFrom(other)) {
				sum += (Vector2) (unit.velocity() + other.velocity()) / distance (other);
			}
		}
		return sum;
	}

	bool shouldSeparateFrom (Ant other) {
		return distance (other) <= MIN_NEIGHBOR_DISTANCE;
	}

	Vector2 nextCohesionVelocity () {
		Vector2 sum = Vector2.zero;
		IEnumerable<Ant> neighbors = localNeighbors();
		foreach (Ant other in neighbors) {
			if (other != unit && shouldAlignWith(other)) {
				sum += (Vector2) (unit.position() - other.position());
			}
		}
		return sum;
	}

	IEnumerable<Ant> localNeighbors() {
		return Enumerable.OrderBy<Ant, float>(this.allyFlock,
		                                      a => distance(a)).Take(NEIGHBOR_COUNT);
	}

	float distance(Ant other) {
		return Vector2.Distance (unit.position(), other.position());
	}
}

