using UnityEngine;
using System.Collections;

public class LevelAI : MonoBehaviour {
	public static float[][,] levels;
//	private static int[][] buildScheme;

	public static float[][,] getLevels(){
		if(levels == null){
			levels = new float[30][,];
			setup();
		}
		return levels;
	}


	public static float[,] getLevel(int level){
		return getLevels()[level];
	}

	// Each level is built up by {delay from last spawn in seconds, type of ant from Publics, how many to spawn}
	private static void setup(){
		// Level 0 info
		float[,] level0 = {
			{1, 	Publics.ARMYANT, 	1}};
		levels[0] = level0;


		// Level 1 info
		float[,] level1 = {
			{1f, 	Publics.WORKER, 	1},
			{1f, 	Publics.ARMYANT, 	2}};
		levels[1] = level1;


		// Level 2 info
		float[,] level2 = {
			{0.5f, 	Publics.WORKER, 	1},
			{1, 	Publics.BULLANT, 	1},
			{1, 	Publics.ARMYANT, 	2}};
		levels[2] = level2;


		// Level 3 info
		float[,] level3 = {
			{1, 	Publics.WORKER, 	2},
			{1, 	Publics.BULLANT, 	1},
			{1, 	Publics.ARMYANT, 	2},
			{1, 	Publics.FIREANT, 	1}};
		levels[3] = level3;


		// Level 4 info
		float[,] level4 = {
			{1, 	Publics.WORKER, 	2},
			{1, 	Publics.FIREANT, 	1},
			{0.5f, 	Publics.ARMYANT, 	2},
			{1, 	Publics.WORKER, 	1},
			{2, 	Publics.BULLANT, 	1},
			{0.5f, 	Publics.FIREANT, 	1},
			{0.5f, 	Publics.ARMYANT, 	2}};
		levels[4] = level4;
	}

}