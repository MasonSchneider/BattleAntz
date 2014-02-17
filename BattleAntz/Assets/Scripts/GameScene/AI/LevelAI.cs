using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelAI : MonoBehaviour {
	public static float[][,] levels;
	//private static int[][] buildScheme;

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
			{2f, 	Constants.ARMYANT, 	4}};
		levels[0] = level0;

		// Level 1 info
		float[,] level1 = {
			{1f, 	Constants.WORKER, 	2},
			{1f, 	Constants.ARMYANT, 	2}};
		levels[1] = level1;


		// Level 2 info
		float[,] level2 = {
			{0.5f, 	Constants.WORKER, 	3},
			{1f, 	Constants.BULLANT, 	3},
			{1f, 	Constants.ARMYANT, 	6}};
		levels[2] = level2;


		// Level 3 info
		float[,] level3 = {
			{1f, 	Constants.WORKER, 	6},
			{1f, 	Constants.FIREANT, 	4},
			{1f, 	Constants.ARMYANT, 	4}};
		levels[3] = level3;


		// Level 4 info
		float[,] level4 = {
			{1f, 	Constants.WORKER, 	10},
			{1f, 	Constants.FIREANT, 	6},
			{0.5f, 	Constants.ARMYANT, 	4},
			{1f, 	Constants.WORKER, 	6},
			{1f, 	Constants.BULLANT, 	2},
			{0.5f, 	Constants.FIREANT, 	2},
			{0.5f, 	Constants.ARMYANT, 	4}};
		levels[4] = level4;

		// Level 5 info
		float[,] level5 = {
			{1f, 	Constants.WORKER, 	12},
			{1f, 	Constants.FIREANT, 	6},
			{1f, 	Constants.BULLANT, 	2},
			{0.5f, 	Constants.ARMYANT, 	4}};
		levels[5] = level5;

		// Level 6 info
		float[,] level6 = {
			{0.5f, 	Constants.WORKER, 	12},
			{1f, 	Constants.BULLANT, 	4},
			{1f, 	Constants.BULLANT, 	2},
			{0.5f, 	Constants.ARMYANT, 	2}};
		levels[6] = level6;

		// Level 7 info
		float[,] level7 = {
			{0.5f, 	Constants.WORKER, 	20},
			{0.5f, 	Constants.BULLANT, 	14},
			{0.5f, 	Constants.ARMYANT, 	7},
			{0.5f, 	Constants.WORKER, 	10},
			{0.5f, 	Constants.BULLANT, 	8},
			{0.5f, 	Constants.FIREANT, 	10}};
		levels[7] = level7;

		
		// Level 8 info
		float[,] level8 = {
			{0.5f, 	Constants.WORKER, 	20},
			{0.5f, 	Constants.BULLANT, 	14},
			{0.5f, 	Constants.ARMYANT, 	7},
			{0.5f, 	Constants.WORKER, 	10},
			{0.5f, 	Constants.BULLANT, 	8},
			{0.5f, 	Constants.FIREANT, 	10}};
		levels[8] = level8;
	}

}