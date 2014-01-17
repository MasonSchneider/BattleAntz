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
			{1, 	Publics.ARMYANT, 	1},
			{0.5f, 	Publics.ARMYANT, 	4},
			{2f, 	Publics.WORKER, 	2},
			{2, 	Publics.BULLANT, 	1},
			{2, 	Publics.FIREANT, 	1}};
		levels[0] = level0;
	}

}