using UnityEngine;
using System.Collections;

public abstract class Behavior : object {
	protected Ant ant;

	//Return the direction to move in
	public abstract Vector2 nextDirection();
	
	//Return the ant to be attacked, null if no ant is to be attacked
	public abstract Ant antToAttack();

	private string allyFactoryTag() {
		if (ant.enemyFactory.tag == "PlayerFactory") {
			return "EnemyFactory";
		} else {
			return "PlayerFactory";
		}
	}

	private string enemyFactoryTag() {
		if (ant.enemyFactory.tag == "PlayerFactory") {
			return "PlayerFactory";
		} else {
			return "EnemyFactory";
		}
	}

	protected Ant[] getAllyAnts() {
		return GameObject.FindGameObjectWithTag(allyFactoryTag()).GetComponentsInChildren<Ant>();

	}

	protected Ant[] getEnemyAnts() {
		return GameObject.FindGameObjectWithTag(enemyFactoryTag()).GetComponentsInChildren<Ant>();
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
