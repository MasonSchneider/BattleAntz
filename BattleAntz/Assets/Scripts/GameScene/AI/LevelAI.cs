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

	// Each level is built up by {delay from last spawn in seconds, type of ant from Constants, how many to spawn}
	private static void setup(){
		// Level 0 info
		float[,] level0 = {
			{2f, 	Constants.ARMYANT, 	1}};
		levels[0] = level0;


		// Level 1 info
		float[,] level1 = {
			{1f, 	Constants.WORKER, 	1},
			{1f, 	Constants.ARMYANT, 	2}};
		levels[1] = level1;


		// Level 2 info
		float[,] level2 = {
			{0.5f, 	Constants.WORKER, 	1},
			{1, 	Constants.BULLANT, 	1},
			{1, 	Constants.ARMYANT, 	2}};
		levels[2] = level2;


		// Level 3 info
		float[,] level3 = {
			{1, 	Constants.WORKER, 	2},
			{1, 	Constants.BULLANT, 	1},
			{1, 	Constants.ARMYANT, 	2},
			{1, 	Constants.FIREANT, 	1}};
		levels[3] = level3;


		// Level 4 info
		float[,] level4 = {
			{1, 	Constants.WORKER, 	2},
			{1, 	Constants.FIREANT, 	1},
			{0.5f, 	Constants.ARMYANT, 	2},
			{1, 	Constants.WORKER, 	1},
			{2, 	Constants.BULLANT, 	1},
			{0.5f, 	Constants.FIREANT, 	1},
			{0.5f, 	Constants.ARMYANT, 	2}};
		levels[4] = level4;

		// Level 5 info
		float[,] level5 = {
			{1, 	Constants.WORKER, 	2},
			{2, 	Constants.BULLANT, 	1},
			{1, 	Constants.FIREANT, 	1},
			{0.5f, 	Constants.ARMYANT, 	2},
			{1, 	Constants.WORKER, 	2},
			{1, 	Constants.BULLANT, 	1},
			{0.5f, 	Constants.FIREANT, 	1},
			{0.5f, 	Constants.ARMYANT, 	1}};
		levels[5] = level5;

		// Level 6 info
		float[,] level6 = {
			{0.5f, 	Constants.WORKER, 	2},
			{0.5f, 	Constants.ARMYANT, 	2},
			{0.5f, 	Constants.WORKER, 	1},
			{0.5f, 	Constants.ARMYANT, 	2},
			{1, 	Constants.BULLANT, 	1},
			{1, 	Constants.FIREANT, 	1},
			{0.5f, 	Constants.ARMYANT, 	2}};
		levels[6] = level6;

		// Level 7 info
		float[,] level7 = {
			{0.5f, 	Constants.WORKER, 	4},
			{0.5f, 	Constants.ARMYANT, 	2},
			{0.5f, 	Constants.WORKER, 	2},
			{1, 	Constants.BULLANT, 	2},
			{0.5f, 	Constants.FIREANT, 	2},
			{0.5f, 	Constants.ARMYANT, 	2}};
		levels[7] = level7;

		
		// Level 8 info
		float[,] level8 = {
			{0.5f, 	Constants.WORKER, 	3},
			{0.5f, 	Constants.ARMYANT, 	4},
			{1, 	Constants.WORKER, 	2},
			{1, 	Constants.ARMYANT, 	4},
			{1, 	Constants.BULLANT, 	2},
			{0.5f, 	Constants.FIREANT, 	2},
			{0.5f, 	Constants.ARMYANT, 	3}};
		levels[8] = level8;
	}

}