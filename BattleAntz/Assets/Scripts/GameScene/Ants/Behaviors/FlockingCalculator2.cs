using UnityEngine;
using System.Collections;

public class FlockingCalculator2 : object {

	
	
	public Vector2 objectToFlyAround = Vector2.zero;
	public float spreadness = 1f;
	public float separationDist = 1f;
	public float maxFlyDistance = 10;
	public float maxSpeed = 1;
	public float maxFlySpeed = 1;
	public float panicMagnitude = 5;
	public int firefliesPerScene = 20;
	public float minScale = 0.5f;
	public float maxScale = 2f;
	public Vector3 vind = Vector3.zero;
	
	private Vector3 boidsMassCenter;

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
		Vector2 v1, v2, v3, v4;
		v1 = Cohesion ();
		v2 = Separation ();
		v3 = Alignment ();
		v4 = nextDesiredPosition ();

		return unit.velocity() + v1 + v2 + v3 + v4;
	}

	Vector2 nextDesiredPosition(){
		Vector2 desiredPosition;
		if(enemyFlock.Length == 0){
			Vector2 center = flockCenter(allyFlock);
			desiredPosition = new Vector2(center.x + 1.3f, center.y);
		}
		else{
			Vector2 center = flockCenter(enemyFlock);
			float distance = Vector2.Distance(center, flockCenter(allyFlock));
			if( distance < 15 )
				desiredPosition = flockCenter(enemyFlock).normalized;
			else{
				center = flockCenter(allyFlock);
				desiredPosition = new Vector2(center.x + 1.3f, center.y);
			}
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

	private Vector3 Cohesion () {
		boidsMassCenter = Vector3.zero;
		
		foreach (Ant other in allyFlock) {
			if (unit != other) {
				boidsMassCenter = boidsMassCenter + unit.transform.localPosition;	
			}
		}
		
		boidsMassCenter = boidsMassCenter / (allyFlock.Length - 1);
		return (boidsMassCenter - unit.transform.localPosition) / 100;
	}
	
	private Vector3 Separation () {
		Vector3 c = Vector3.zero;
		
		foreach (Ant other in allyFlock) {
			if (unit != other) {
				if (Vector3.Distance (other.transform.localPosition, unit.transform.localPosition) < separationDist) {
					c = c - (other.transform.localPosition - unit.transform.localPosition);
				}
			}
		}
		return c * spreadness;
	}
	
	private Vector2 Alignment () {
		Vector2 pv = Vector3.zero;
		
		foreach (Ant other in allyFlock) {
			if (unit != other) {
				pv = pv + other.velocity();	
			}
		}
		
		pv = pv / (allyFlock.Length - 1);
		return (pv - unit.velocity()) / 32;
	}
	
	private Vector2 tendToPlace () {
		return (objectToFlyAround - (Vector2) unit.transform.localPosition) / maxFlyDistance;
	}

//	private void rush () {
//		if (Mathf.Abs (firefly.transform.localScale.magnitude) > 1f) {
//			foreach (Firefly ff in fireflies){
//				ff.transform.localScale = Vector3.Lerp(ff.transform.localScale, Vector3.zero, Time.deltaTime * 2);
//			}
//			LeanTween.delayedCall(gameObject, Time.deltaTime, "rush");
//		} else {
//			foreach (Firefly ff in fireflies){
//				ff.transform.localScale = Vector3.zero;
//			} 
//			relax ();
//		}
//	}
	
//	private void relax () {
//		if (Mathf.Abs (maxFlySpeed - firefly.maxSpeed) > 0.5f) {
//			spreadness = defaultSpreadness;
//			separationDist = defaultSeparationDist;
//			foreach (Firefly ff in fireflies){
//				ff.maxSpeed = Mathf.Lerp (ff.maxSpeed, maxFlySpeed, Time.deltaTime);
//				ff.transform.localScale = Vector3.Lerp (ff.transform.localScale, ff.scale, Time.deltaTime * 2);
//			}
//			LeanTween.delayedCall(gameObject, Time.deltaTime, "relax");
//		} else {
//			foreach (Firefly ff in fireflies){
//				ff.maxSpeed = maxFlySpeed;
//				ff.transform.localScale = ff.scale;
//			} 
//			spreadness = defaultSpreadness;
//			separationDist = defaultSeparationDist;
//		}
//	}
	
//	void OnTriggerEnter (Collider other) {
//		if (other.tag != "Player") {return;}
//		rush ();
//		spreadness = defaultSpreadness * panicMagnitude;
//		separationDist = defaultSeparationDist * panicMagnitude;
//		foreach (Firefly ff in fireflies){
//			ff.maxSpeed = maxFlySpeed * panicMagnitude;
//		}
//	}
//	
//	void OnTriggerExit (Collider other) {
//		//LeanTween.delayedCall(gameObject, 3, "relax");
//	}
}


/*

// AntFlockingBehavior Algorithm object
// by Isaac Sanders, Winter 2014
using UnityEngine;


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

	public FlockingCalculator (Ant unit, Ant[] allyFlock) {
		this.unit = unit;
		this.allyFlock = allyFlock;
	}

	public void setFlocks(Ant[] allyFlock, Ant[] enemyFlock){
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
			desiredPosition = new Vector2(center.x + 0.1f, center.y);
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
		return MIN_DISTANCE <= distance(other) && MAX_DISTANCE >= distance(other);
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
		return (unit.position() - other.position()).sqrMagnitude;
	}
}

*/