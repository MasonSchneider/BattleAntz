using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public Texture pauseTexture;
	public Texture fireAntTexture;
	public Texture armyAntTexture;
	public Texture bullAntTexture;

	private Rect pauseRect;

	public Hive playerHive;

	private UpgradeMenu upgrades;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<PauseMenu>().enabled = false;
		upgrades = gameObject.GetComponent<UpgradeMenu>();
		upgrades.enabled = false;
		pauseRect = new Rect(Screen.width/2 - 24, 24, 0, 0);
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
			gameObject.GetComponent<PauseMenu>().enabled = true;
		}

		// Manage Workers
		if(GUI.Button(new Rect(215,55,43,20),"Buy")) {
			playerHive.buyWorker();
		}

		if(GUI.Button(new Rect(260,55,43,20),"Sell")) {
			playerHive.sellWorker();
		}
		// --------------

		// Manage Army Ants
		if (GUI.Button(new Rect(Screen.width - 350, 35, 50, 50), "Army")) {
			playerHive.buyArmyAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 338, 10, 25, 25), "+")) {
			upgrades.type = "army";
			upgrades.enabled = true;
		}

		// Manage Fire Ant
		if (GUI.Button(new Rect(Screen.width - 250, 35, 50, 50), "Fire")) {
			playerHive.buyFireAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 238, 10, 25, 25), "+")) {
			upgrades.type = "fire";
			upgrades.enabled = true;
		}

		// Manage Bull Ant
		if (GUI.Button(new Rect(Screen.width - 150, 35, 50, 50), "Bull")) {
			playerHive.buyBullAnt();
		}
		if (GUI.Button(new Rect(Screen.width - 138, 10, 25, 25), "+")) {
			upgrades.type = "bull";
			upgrades.enabled = true;
		}
	}
}
