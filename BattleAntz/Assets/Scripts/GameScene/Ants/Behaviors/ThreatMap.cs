// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;


public class ThreatMap : object {
	IEnumerable<Ant> allies;
	IEnumerable<Ant> enemies;
	RoadController roadController;

	public static int NUMBER_OF_ROWS = 5;
	public static int NUMBER_OF_COLUMNS = 25;

	public ThreatMap (IEnumerable<Ant> allies, IEnumerable<Ant> enemies) {
		this.allies = allies;
		this.enemies = enemies;
		this.roadController = GameObject.Find ("Road Controller").GetComponent ("RoadController") as RoadController;
	}

	public float getThreatLevel(Vector2 position) {
		float threat = 0;
		foreach (Ant ally in allies) {
			if (inThreatRange(ally, position)) {
				threat -= ally.damage;
			}
		}
		foreach (Ant enemy in enemies) {
			if (inThreatRange(enemy, position)) {
				threat += enemy.damage;
			}
		}
		return threat;
	}

	public bool inThreatRange(Ant ant, Vector2 position) {
		float xMax = ant.position().x + ant.range;
		float xMin = ant.position().x - ant.range;
		float yMax = ant.position().y + ant.range;
		float yMin = ant.position().y - ant.range;
		return (xMin < position.x && position.x < xMax) && (yMin < position.y && position.y < yMax);
	}

	public IEnumerable<IEnumerable<Vector2>> threatCellCenters() {
		return Enumerable.Range (0, NUMBER_OF_ROWS)
			.Select (x => (cellWidth () * x) + (cellWidth () / 2))
			.Select (xCenter => 
			        Enumerable.Range (0, NUMBER_OF_COLUMNS)
				        .Select (y => (cellWidth () * y) + (cellHeight () / 2))
				        .Select (yCenter => new Vector2 (xCenter, yCenter)));
	}

	public float cellWidth() {
		return roadController.width() / NUMBER_OF_COLUMNS;
	}

	public float cellHeight() {
		return roadController.height () / NUMBER_OF_ROWS;
	}
}