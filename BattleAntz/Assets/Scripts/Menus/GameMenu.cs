using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public Texture pauseTexture;
	public Texture fireAntTexture;
	public Texture armyAntTexture;
	public Texture bullAntTexture;

	private Rect pauseRect;

	public Hive playerHive;
	private NetworkManager netMan;
	public bool paused = false;
	private UpgradeMenu upgrades;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		gameObject.GetComponent<PauseMenu>().enabled = false;
		upgrades = gameObject.GetComponent<UpgradeMenu>();
		upgrades.enabled = false;
		pauseRect = new Rect(Screen.width/2 - 24, 24, 0, 0);

		if(Constants.multiplayer)
			netMan = GameObject.Find("Network Manager").GetComponent("NetworkManager") as NetworkManager;
	}

	void OnGUI () {
		// Create the menu area
		GUI.Box(new Rect(0,0,Screen.width,90), "Battle Antz");

		// Display hive stats
		GUI.Label(new Rect(16,15,100,40), "Sugar: " + playerHive.sugar);
		GUI.Label(new Rect(15,55,100,40), "Health: " + playerHive.health + "/100");
		GUI.Label(new Rect(140,15,100,40), "Sugar/Sec: " + playerHive.income);
		GUI.Label(new Rect(140,55,100,40), "Workers: " + playerHive.workers);

		// Pause Game
		if (GuiButton.textureButton(pauseRect, pauseTexture)) {
			Time.timeScale = 0;
			paused = true;
			gameObject.GetComponent<PauseMenu>().enabled = true;
		}

		// Manage Workers
		if(GUI.Button(new Rect(215,55,43,20),"Buy") && !paused) {
			if(Constants.multiplayer)
				netMan.sendWorker();
			playerHive.buyWorker();
		}

		if(GUI.Button(new Rect(260,55,43,20),"Sell") && !paused) {
			if(Constants.multiplayer)
				netMan.sendSellWorker();
			playerHive.sellWorker();
		}
		// --------------

		// Manage Army Ants
		if (GUI.Button(new Rect(Screen.width - 350, 35, 50, 50), new GUIContent("Army","Damage: "+Constants.ARMY_ANT_DAMAGE*(1.0f + playerHive.upgrades[1][2]*Constants.UPGRADE_FRACTION)+"\nLife: "+Constants.ARMY_ANT_LIFE*(1.0f + playerHive.upgrades[1][1]*Constants.UPGRADE_FRACTION)+"\nSpeed: "+Constants.ARMY_ANT_SPEED*(1.0f + playerHive.upgrades[1][0]*Constants.UPGRADE_FRACTION)+"\nCost: "+Constants.ARMY_ANT_COST)) && !paused) {
			if(Constants.multiplayer)
				netMan.sendArmyAnt();
			playerHive.buyArmyAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 338, 10, 25, 25), "+") && !paused) {
			upgrades.enabled = true;
			upgrades.type = "army";
		}

		GUI.Label(new Rect(Screen.width - 350, 100, 100, 100),GUI.tooltip);
		GUI.tooltip = null;
		
		// Manage Bull Ant
		if (GUI.Button(new Rect(Screen.width - 250, 35, 50, 50), new GUIContent("Bull","Damage: "+Constants.BULL_ANT_DAMAGE*(1.0f + playerHive.upgrades[2][2]*Constants.UPGRADE_FRACTION)+"\nLife: "+Constants.BULL_ANT_LIFE*(1.0f + playerHive.upgrades[2][1]*Constants.UPGRADE_FRACTION)+"\nSpeed: "+Constants.BULL_ANT_SPEED*(1.0f + playerHive.upgrades[2][3])*(1.0f + playerHive.upgrades[2][0]*Constants.UPGRADE_FRACTION)+"\nCost: "+Constants.BULL_ANT_COST)) && !paused) {
			if(Constants.multiplayer)
				netMan.sendBullAnt();
			playerHive.buyBullAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 238, 10, 25, 25), "+") && !paused) {
			upgrades.enabled = true;
			upgrades.type = "bull";
		}

		GUI.Label(new Rect(Screen.width - 250, 100, 100, 100),GUI.tooltip);
		GUI.tooltip = null;

		// Manage Fire Ant
		if (GUI.Button(new Rect(Screen.width - 150, 35, 50, 50), new GUIContent("Fire","Damage: "+Constants.FIRE_ANT_DAMAGE*(1.0f + playerHive.upgrades[3][2]*Constants.UPGRADE_FRACTION)+"\nLife: "+Constants.FIRE_ANT_LIFE*(1.0f + playerHive.upgrades[3][1]*Constants.UPGRADE_FRACTION)+"\nSpeed: "+Constants.FIRE_ANT_SPEED*(1.0f + playerHive.upgrades[3][0]*Constants.UPGRADE_FRACTION)+"\nCost: "+Constants.FIRE_ANT_COST)) && !paused) {
			if(Constants.multiplayer)
				netMan.sendFireAnt();
			playerHive.buyFireAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 138, 10, 25, 25), "+") && !paused) {
			upgrades.enabled = true;
			upgrades.type = "fire";
		}

		GUI.Label(new Rect(Screen.width - 150, 100, 100, 100),GUI.tooltip);
		GUI.tooltip = null;

	}
}
