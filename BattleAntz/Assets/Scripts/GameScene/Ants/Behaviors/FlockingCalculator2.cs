using UnityEngine;
using System.Collections;

public class FlockingCalculator2 : object {
	public float spreadness = 1f;
	public float separationDist = 1f;
	
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
		Vector2 v1, v2, v3, v4, v5;
		v1 = Cohesion ();
		v2 = Separation ();
		v3 = Alignment ();
		v4 = nextDesiredPosition ();
		v5 = nextThreatVelocity();
		
		return unit.velocity() + v1 + v2 + v3 + v4 +v5;
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

}
