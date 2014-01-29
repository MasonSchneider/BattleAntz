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
			{1, 	Constants.ARMYANT, 	1},
			{0.5f, 	Constants.ARMYANT, 	4},
			{2f, 	Constants.WORKER, 	2},
			{2, 	Constants.BULLANT, 	1},
			{2, 	Constants.FIREANT, 	1}};
		levels[0] = level0;
		
		// Level 1 info
		float[,] level1 = {
			{5, 	Constants.ARMYANT, 1}};
		levels[1] = level1;
	}

}