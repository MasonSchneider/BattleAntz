using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-200,400,300), "Paused");
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-150,300,50),"Resume Game")) {
			Time.timeScale = 1;
			gameObject.GetComponent<PauseMenu>().enabled = false;
		}
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2-75,300,50),"Surrender")) {
			Application.LoadLevel("MainMenu");
			Time.timeScale = 1;
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2,300,50),"Restart")) {
			Application.LoadLevel("GameScene");
			Time.timeScale = 1;
		}
	}

}
