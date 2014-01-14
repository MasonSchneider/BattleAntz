using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	private string gameResult;
	private GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		enabled = false;
		style.fontSize = 30;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gameOver(string result){
		gameResult = result;
		enabled = true;
		Time.timeScale = 0;
	}
	
	void OnGUI () {
		GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-200,400,300), "Game Ended");
		GUI.TextField(new Rect(Screen.width/2-60,Screen.height/2-150,300,50), gameResult, style);

		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-75,300,50),"Main Menu")) {
			Application.LoadLevel("MainMenu");
			Time.timeScale = 1;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2,300,50),"Restart")) {
			Application.LoadLevel("GameScene");
			Time.timeScale = 1;
		}
	}
}
