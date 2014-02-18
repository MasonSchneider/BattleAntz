using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	private string gameResult;
	private GUIStyle style = new GUIStyle();
	private NetworkManager networkManager;

	public int workers;
	public int armyants;
	public int bullants;
	public int fireants;
	public int sugar;
	public int killed;
	
	// Use this for initialization
	void Start () {
		enabled = false;
		style.fontSize = 30;
		if(Constants.multiplayer)
			networkManager = GameObject.Find("Network Manager").GetComponent("NetworkManager") as NetworkManager;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gameOver(string result, int workersCreated, int armyantsCreated, int bullantsCreated, int fireantsCreated, int sugarProduced, int antsKilled){
		Constants.paused = true;
		workers = workersCreated;
		sugar = sugarProduced;
		armyants = armyantsCreated;
		bullants = bullantsCreated;
		fireants = fireantsCreated;
		killed = antsKilled;
		gameResult = result;
		enabled = true;
		Time.timeScale = 0;
	}
	
	void OnGUI () {
		//Resize the box to accomodate the continue button (or not)
		Rect menuBox;
		if(gameResult.Equals("You win!") && !networkManager && Constants.level != 10)
			menuBox = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 465);
		else 
			menuBox = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400);
		GUI.Box(menuBox, "");
		GUI.TextField(new Rect(Screen.width/2-60,Screen.height/2-195,300,50), gameResult, style);


		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-120,300,50), "Total Sugar Collected: "+sugar);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-95,300,50), "Workers Created: "+workers);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-70,300,50), "Army Ants Created: "+armyants);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-45,300,50), "Bull Ants Created: "+bullants);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-15,300,50), "Fire Ants Created: "+fireants);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2+10,300,50), "Units Killed: "+killed);

		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2+60,300,50),"Main Menu")) {
			if(networkManager)
				networkManager.surrender();
			Application.LoadLevel("MainMenu");
			Constants.paused = false;
			Time.timeScale = 1;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2+125,300,50),"Restart")) {
			if(networkManager)
				networkManager.restart();
			Constants.paused = false;
			Application.LoadLevel("GameScene");
			Time.timeScale = 1;
		}

		
		if(gameResult.Equals("You win!") && !networkManager && Constants.level != 10)
		{
			if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2+190,300,50),"Continue")) {
				if(networkManager)
					networkManager.restart();
				Constants.paused = false;

				if(Constants.level == 8)
					Constants.level = 10;
				else
					Constants.level++;
				Application.LoadLevel("GameScene");
				Time.timeScale = 1;
			}
		}
	}
}
