using UnityEngine;
using System.Collections;

public class EndGameStats : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-300,400,600),"Game Over!");

		//TODO: Display end game stats

		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2+100,300,50),"Main Menu")) {
			Application.LoadLevel("MainMenu");
			Time.timeScale = 1;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2+200,300,50),"Play Again")) {
			Application.LoadLevel("GameScene");
			Time.timeScale = 1;
		}
	}
}
