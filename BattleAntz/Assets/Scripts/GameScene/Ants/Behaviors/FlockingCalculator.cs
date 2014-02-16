// AntFlockingBehavior Algorithm object
// by Isaac Sanders, Winter 2014
using UnityEngine;


public class FlockingCalculator : object {
	public static float ALIGNMENT_WEIGHT = 1.0f / 3.0f;
	public static float SEPARATION_WEIGHT = 1.0f / 3.0f;
	public static float COHESION_WEIGHT = 1.0f / 3.0f;
	public static int NEIGHBOR_COUNT = 4;
	public static float MIN_DISTANCE = 0.0f;
	public static float MAX_DISTANCE = 5.0f;

	private Ant unit;
	private Ant[] flock;

	public FlockingCalculator (Ant unit, Ant[] flock) {
		this.unit = unit;
		this.flock = flock;
	}

	public Vector2 nextVelocity() {
		return nextAlignmentVelocity () * ALIGNMENT_WEIGHT + nextSeparationVelocity () * SEPARATION_WEIGHT + nextCohesionVelocity () * COHESION_WEIGHT;
	}

	Vector2 nextAlignmentVelocity() {
		Vector2 sum = Vector2.zero;
		foreach(Ant other in flock) {
			if (shouldAlignWith(other)) {
				sum += (Vector2) other.velocity();
			}
		}
		return sum * (1.0f / NEIGHBOR_COUNT);
	}
	
	bool shouldAlignWith (Ant other) {
		return MIN_DISTANCE <= distance(other) && MAX_DISTANCE >= distance(other);
	}	

	Vector2 nextSeparationVelocity () {
		Vector2 sum = Vector2.zero;
		foreach (Ant other in flock) {
			if (shouldSeparateFrom(other)) {
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
		foreach (Ant other in flock) {
			if (shouldAlignWith(other)) {
				sum += (Vector2) (unit.position() - other.position());
			}
		}
		return sum;
	}

	float distance(Ant other) {
		return (unit.position() - other.position()).sqrMagnitude;
	}
}

