using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private NetworkManager networkManager;

	// Use this for initialization
	void Start () {
		if(Constants.multiplayer)
			networkManager = GameObject.Find("Network Manager").GetComponent("NetworkManager") as NetworkManager;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-200,400,300), "Paused");
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-150,300,50),"Resume Game")) {
			networkManager.pause();
			gameObject.GetComponent<GameMenu>().paused = false;
			Time.timeScale = 1;
			gameObject.GetComponent<PauseMenu>().enabled = false;
		}
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-75,300,50),"Surrender")) {
			gameObject.GetComponent<GameMenu>().paused = false;
			networkManager.surrender();
			Application.LoadLevel("MainMenu");
			Time.timeScale = 1;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2,300,50),"Restart")) {
			gameObject.GetComponent<GameMenu>().paused = false;
			networkManager.restart();
			Application.LoadLevel("GameScene");
			Time.timeScale = 1;
		}
	}

}
