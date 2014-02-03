using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {
	public static int WORKER = 0;
	public static int ARMYANT = 1;
	public static int BULLANT = 2;
	public static int FIREANT = 3;

	public static int SUGAR_RATE = 1;
	public static int WORKER_COST = 50;
	public static int WORKER_PRODUCTION = 5;

	public static int ARMY_ANT_COST = 50;
	public static int BULL_ANT_COST = 100;
	public static int FIRE_ANT_COST = 250;

	public static int ARMY_ANT_DAMAGE = 10;
	public static int BULL_ANT_DAMAGE = 30;
	public static int FIRE_ANT_DAMAGE = 50;

	public static float ARMY_ANT_SPEED = .2f;
	public static float BULL_ANT_SPEED = .05f;
	public static float FIRE_ANT_SPEED = .1f;

	public static int ARMY_ANT_LIFE = 50;
	public static int BULL_ANT_LIFE = 100;
	public static int FIRE_ANT_LIFE = 50;

	public static float ARMY_ANT_RANGE = 1f;
	public static float BULL_ANT_RANGE = 1.5f;
	public static float FIRE_ANT_RANGE = 2.5f;

	public static int RETURN_VALUE = 2;
	public static float UPGRADE_FRACTION = .3f;
	
	public static int UPGRADE_COST = 300;
	
	public static int U_WORKER = 0;
	public static int U_ARMYANT = 1;
	public static int U_BULLANT = 2;
	public static int U_FIREANT = 3;
	
	public static int U_SPEED = 0;
	public static int U_HEALTH = 1;
	public static int U_STRENGTH = 2;
	public static int U_SPECIAL = 3;

	public static int BANELING_DAMAGE = 15;
	public static int BANELING_RADIUS = 250;

	public static int level = 0;
	public static bool multiplayer;

	public static bool EXPERIMENTAL = true;
}
