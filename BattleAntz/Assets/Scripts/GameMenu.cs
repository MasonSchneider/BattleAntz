using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public Texture pauseTexture;
	public Texture fireAntTexture;
	public Texture armyAntTexture;
	public Texture bullAntTexture;

	private Rect pauseRect;

	public Hive playerHive;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<PauseMenu>().enabled = false;
		pauseRect = new Rect(Screen.width/2 - 24, 24, 0, 0);
	}

	void OnGUI () {
		GUI.Box(new Rect(0,0,Screen.width,90), "Battle Antz");
		GUI.Label(new Rect(16,15,100,40), "Sugar: " + playerHive.sugar);
		GUI.Label(new Rect(15,55,100,40), "Health: " + playerHive.health + "/100");
		GUI.Label(new Rect(140,15,100,40), "Sugar/Sec: " + playerHive.income);
		GUI.Label(new Rect(140,55,100,40), "Workers: " + playerHive.workers);
		if (GuiButton.textureButton(pauseRect, pauseTexture)) {
			Time.timeScale = 0;
			gameObject.GetComponent<PauseMenu>().enabled = true;
		}

		if(GUI.Button(new Rect(215,55,43,20),"Buy")) {
			playerHive.buyWorker();
		}

		if(GUI.Button(new Rect(260,55,43,20),"Sell")) {
			playerHive.sellWorker();
		}
		
		if (GuiButton.textureButton(new Rect(Screen.width - 100*3 - 100, 10, 0, 0), armyAntTexture)) {
			playerHive.buyArmyAnt();
		}
		
		if (GuiButton.textureButton(new Rect(Screen.width - 100*2 - 50, 10, 0, 0), fireAntTexture)) {
			playerHive.buyFireAnt();
		}
		
		if (GuiButton.textureButton(new Rect(Screen.width - 100*1, 10, 0, 0), bullAntTexture)) {
			playerHive.buyBullAnt();
		}
	}
}
