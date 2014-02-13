using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public Texture pauseTexture;
	public Texture fireAntTexture;
	public Texture armyAntTexture;
	public Texture bullAntTexture;

	private Rect pauseRect;

	public Hive playerHive;
	public Hive enemyHive;
	private NetworkManager networkManager;
	private UpgradeMenu upgrades;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		gameObject.GetComponent<PauseMenu>().enabled = false;
		upgrades = gameObject.GetComponent<UpgradeMenu>();
		upgrades.enabled = false;
		pauseRect = new Rect(Screen.width/2 - 30, 24, 0, 0);

		if(Constants.multiplayer)
			networkManager = GameObject.Find("Network Manager").GetComponent("NetworkManager") as NetworkManager;
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
		if ((GuiButton.textureButton(pauseRect, pauseTexture) || ((Event.current.type == EventType.KeyUp) && Event.current.keyCode == KeyCode.P))) {
			Time.timeScale = 0;
			if(networkManager)
				networkManager.pause();
			Constants.paused = true;
			gameObject.GetComponent<PauseMenu>().enabled = true;
		}

		// Manage Workers
		if((GUI.Button(new Rect(220,55,43,20),"Buy") || ((Event.current.type == EventType.KeyUp) && Event.current.keyCode == KeyCode.Q)) && !Constants.paused) {
			if(Constants.EXPERIMENTAL){
				enemyHive.buyWorker();
				playerHive.buyWorker();
			}
			else if(Constants.multiplayer && Network.isClient)
				networkManager.sendWorker();
			else 
				playerHive.buyWorker();
		}
		
		if((GUI.Button(new Rect(265,55,43,20),"Sell") || ((Event.current.type == EventType.KeyUp) && Event.current.keyCode == KeyCode.A)) && !Constants.paused) {
			if(Constants.EXPERIMENTAL){
				enemyHive.sellWorker();
				playerHive.sellWorker();
			}
			else if(Constants.multiplayer && Network.isClient)
				networkManager.sendSellWorker();
			else 
				playerHive.sellWorker();
		}
		// --------------

		// Manage Army Ants
		if ((GUI.Button(new Rect(Screen.width - 350, 35, 50, 50), new GUIContent("Army","Damage: "+Constants.ARMY_ANT_DAMAGE*(1.0f + playerHive.upgrades[1][2]*Constants.UPGRADE_FRACTION)+"\nLife: "+Constants.ARMY_ANT_LIFE*(1.0f + playerHive.upgrades[1][1]*Constants.UPGRADE_FRACTION)+"\nSpeed: "+Constants.ARMY_ANT_SPEED*(1.0f + playerHive.upgrades[1][0]*Constants.UPGRADE_FRACTION)+"\nCost: "+Constants.ARMY_ANT_COST)) || ((Event.current.type == EventType.KeyUp) && Event.current.keyCode == KeyCode.W)) && !Constants.paused) {
			if(Constants.EXPERIMENTAL){
				enemyHive.buyArmyAnt();
				playerHive.buyArmyAnt();
			}
			else if(Constants.multiplayer && Network.isClient)
				networkManager.sendArmyAnt();
			else 
				playerHive.buyArmyAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 338, 10, 25, 25), "+") && !Constants.paused) {
			upgrades.enabled = true;
			upgrades.type = "army";
		}

		GUI.Label(new Rect(Screen.width - 350, 100, 100, 100),GUI.tooltip);
		GUI.tooltip = null;
		
		// Manage Bull Ant
		if ((GUI.Button(new Rect(Screen.width - 250, 35, 50, 50), new GUIContent("Bull","Damage: "+Constants.BULL_ANT_DAMAGE*(1.0f + playerHive.upgrades[2][2]*Constants.UPGRADE_FRACTION)+"\nLife: "+Constants.BULL_ANT_LIFE*(1.0f + playerHive.upgrades[2][1]*Constants.UPGRADE_FRACTION)+"\nSpeed: "+Constants.BULL_ANT_SPEED*(1.0f + playerHive.upgrades[2][3])*(1.0f + playerHive.upgrades[2][0]*Constants.UPGRADE_FRACTION)+"\nCost: "+Constants.BULL_ANT_COST)) || ((Event.current.type == EventType.KeyUp) && Event.current.keyCode == KeyCode.E)) && !Constants.paused) {
			if(Constants.EXPERIMENTAL){
				enemyHive.buyBullAnt();
				playerHive.buyBullAnt();
			}
			else if(Constants.multiplayer && Network.isClient)
				networkManager.sendBullAnt();
			else 
				playerHive.buyBullAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 238, 10, 25, 25), "+") && !Constants.paused) {
			upgrades.enabled = true;
			upgrades.type = "bull";
		}

		GUI.Label(new Rect(Screen.width - 250, 100, 100, 100),GUI.tooltip);
		GUI.tooltip = null;

		// Manage Fire Ant
		if ((GUI.Button(new Rect(Screen.width - 150, 35, 50, 50), new GUIContent("Fire","Damage: "+Constants.FIRE_ANT_DAMAGE*(1.0f + playerHive.upgrades[3][2]*Constants.UPGRADE_FRACTION)+"\nLife: "+Constants.FIRE_ANT_LIFE*(1.0f + playerHive.upgrades[3][1]*Constants.UPGRADE_FRACTION)+"\nSpeed: "+Constants.FIRE_ANT_SPEED*(1.0f + playerHive.upgrades[3][0]*Constants.UPGRADE_FRACTION)+"\nCost: "+Constants.FIRE_ANT_COST)) || ((Event.current.type == EventType.KeyUp) && Event.current.keyCode == KeyCode.R)) && !Constants.paused) {
			if(Constants.EXPERIMENTAL){
				playerHive.buyFireAnt();
				enemyHive.buyFireAnt();
			}
			else if(Constants.multiplayer && Network.isClient)
				networkManager.sendFireAnt();
			else 
				playerHive.buyFireAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 138, 10, 25, 25), "+") && !Constants.paused) {
			upgrades.enabled = true;
			upgrades.type = "fire";
		}

		GUI.Label(new Rect(Screen.width - 150, 100, 100, 100),GUI.tooltip);
		GUI.tooltip = null;
	}
}
