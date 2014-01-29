using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	private string gameResult;
	private GUIStyle style = new GUIStyle();
//	private Hive playerHive;


	// Use this for initialization
	void Start () {
		enabled = false;
		style.fontSize = 30;
//		playerHive = gameObject.GetComponent<GameMenu>().playerHive;
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
		GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-200,400,400), "");
		GUI.TextField(new Rect(Screen.width/2-60,Screen.height/2-195,300,50), gameResult, style);

		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-120,300,50), "Total Sugar Collected: ");
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-95,300,50), "Workers: ");
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-70,300,50), "Army Ants: ");
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-45,300,50), "Bull Ants: ");
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2-15,300,50), "Fire Ants: ");
		GUI.Label(new Rect(Screen.width/2-150,Screen.height/2+10,300,50), "Units Killed: ");

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
