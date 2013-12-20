using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public Texture pauseTexture;
	public Texture antTexture;

	private Rect pauseRect;
	private Rect antRect;

	private Hive homeHive;
	
	// Use this for initialization
	void Start () {
		homeHive = GameObject.Find("Hive").GetComponent("Hive") as Hive;
		pauseRect = new Rect(Screen.width/2 - 24, 24, 52, 55);
		antRect = new Rect(Screen.width - 78*4, 20, 78, 58);
	}

	void OnGUI () {
		GUI.Box(new Rect(0,0,Screen.width,90), "Battle Antz");
		GUI.Label(new Rect(16,15,100,40), "Sugar: " + homeHive.sugar);
		GUI.Label(new Rect(15,55,100,40), "Health: " + homeHive.health + "/100");
		GUI.Label(new Rect(160,15,100,40), "Sugar/Sec: " + homeHive.income);
		GUI.Label(new Rect(160,55,100,40), "Workers: " + homeHive.workers);
		if (GuiButton.textureButton(pauseRect, pauseTexture)) {
			Application.LoadLevel("MainMenu");
		}

		if(GUI.Button(new Rect(240,55,85,20),"Buy Worker")) {
			homeHive.buyWorker();
		}

		if (GuiButton.textureButton(antRect, antTexture)) {
			homeHive.buyArmyAnt();
		}
	}
}
