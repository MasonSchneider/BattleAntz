using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	private string gameResult;
	private GUIStyle style = new GUIStyle();

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
//		playerHive = gameObject.GetComponent<GameMenu>().playerHive;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gameOver(string result, int workersCreated, int armyantsCreated, int bullantsCreated, int fireantsCreated, int sugarProduced, int antsKilled){
		gameObject.GetComponent<GameMenu> ().paused = true;
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
		GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-200,400,400), "");
		GUI.TextField(new Rect(Screen.width/2-60,Screen.height/2-195,300,50), gameResult, style);

		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-120,300,50), "Total Sugar Collected: "+sugar);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-95,300,50), "Workers Created: "+workers);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-70,300,50), "Army Ants Created: "+armyants);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-45,300,50), "Bull Ants Created: "+bullants);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-15,300,50), "Fire Ants Created: "+fireants);
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2+10,300,50), "Units Killed: "+killed);

		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2+60,300,50),"Main Menu")) {
			Application.LoadLevel("MainMenu");
			Time.timeScale = 1;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2+125,300,50),"Restart")) {
			Application.LoadLevel("GameScene");
			Time.timeScale = 1;
		}
	}
}
