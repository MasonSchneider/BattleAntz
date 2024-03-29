// AntFlockingBehavior Algorithm object
// by Isaac Sanders, Winter 2014
using UnityEngine;


public class AntFlockingBehavior
{
	public static float ALIGNMENT_WEIGHT = 1.0f / 3.0f;
	public static float SEPARATION_WEIGHT = 1.0f / 3.0f;
	public static float COHESION_WEIGHT = 1.0f / 3.0f;
	public static int NEIGHBOR_COUNT = 4;
	public static float MIN_DISTANCE = 0.0f;
	public static float MAX_DISTANCE = 5.0f;

//	private Ant unit;
//	private Ant[] flock;

	public AntFlockingBehavior (Ant unit, Ant[] flock)
	{
//		this.unit = unit;
//		this.flock = flock;
	}

	public Vector2 nextVelocity()
	{
		return Vector2.zero;
//		return ALIGNMENT_WEIGHT * nextAlignmentVelocity () + SEPARATION_WEIGHT * nextSeparationVelocity () + COHESION_WEIGHT * nextCohesionVelocity ();
	}

	public Vector2 nextAlignmentVelocity()
	{
//		Vector2 sum = Vector2.zero;
//		foreach(Ant other in flock)
//		{
//			if (shouldAlignWith(other))
//			{
//				sum += other.velocity();
//			}
//		}
//		return (1.0 / NEIGHBOR_COUNT) * sum;
		return Vector2.zero;
	}
	
	bool shouldAlignWith (Ant other)
	{
		return MIN_DISTANCE <= distance(other) && MAX_DISTANCE >= distance(other);
	}	

	float nextSeparationVelocity ()
	{
//		Vector2 sum = Vector2.zero;
//		foreach (Ant other in flock)
//		{
//			if (shouldSeparateFrom(other))
//			{
//				sum += (unit.velocity() + other.velocity()) / distance (other);
//			}
//		}
//		return sum;
		return 0;
	}

	bool shouldSeparateFrom (Ant other)
	{
		return distance (other) <= MIN_DISTANCE;
	}

	float nextCohesionVelocity ()
	{
//		Vector2 sum = Vector2.zero;
//		foreach (Ant other in flock)
//		{
//			if (shouldAlignWith(other))
//			{
//				sum += (unit.position() - other.position());
//			}
//		}
//		return sum;
		return 0;
	}

	float distance(Ant other)
	{
//		return (unit.position() - other.position()).sqrMagnitude;
		return 0;
	}
}

