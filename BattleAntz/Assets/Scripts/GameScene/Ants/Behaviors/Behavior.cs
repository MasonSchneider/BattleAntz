using UnityEngine;
using System.Collections;

public abstract class Behavior : object {
	protected Ant ant;

	//Return the direction to move in
	public abstract Vector2 nextDirection();
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public abstract Ant antToAttack();

	protected Ant[] getAllyAnts() {
		Ant[] ants = ant.allyFactory.GetComponentsInChildren<Ant>();
//		ArrayList list = new ArrayList(ants);
//		list.Remove(ant);
//		ants = (Ant[])list.ToArray(typeof(Ant)) as Ant[];
		return ants;

	}

	protected Ant[] getEnemyAnts() {
		Ant[] ants = ant.enemyFactory.GetComponentsInChildren<Ant>();
//		ArrayList list = new ArrayList(ants);
//		list.Remove(ant);
//		ants = (Ant[])list.ToArray()as Ant[];
		return ants;
	}
	
	// Find the nearest enemy ant
	protected Ant getNearestAnt(){
		Ant[] ants = ant.enemyFactory.GetComponentsInChildren<Ant>();
		Ant target = null;
		float nearest = -1;
		foreach(Ant a in ants){
			Vector2 diff = a.gameObject.transform.position-ant.transform.position;
			if(diff.sqrMagnitude < nearest || nearest < 0 ){
				target = a;
				nearest = diff.sqrMagnitude;
			}
		}
		return target;
	}
	
	// Find the enemy ant with lowest health
	protected Ant getLowestAnt(){
		Ant[] ants = ant.enemyFactory.GetComponentsInChildren<Ant>();
		Ant target = null;
		float lowest = -1;
		foreach(Ant a in ants){
			if(a.life < lowest || lowest < 0 ){
				target = a;
				lowest = a.life;
			}
		}
		return target;
	}


}
