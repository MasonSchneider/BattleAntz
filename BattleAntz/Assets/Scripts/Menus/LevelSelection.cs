using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {
	private int maxlevels = 9;
	private int spacingY = 150;
	private int spacingX = 300;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
//	int row = 0;

	void OnGUI () {
		for(int i=0; i<maxlevels; i++){
			if (GUI.Button(new Rect(100+spacingX*(i%3), 100+spacingY*(i/3), 200, 50), "Level " + (i+1))) {
				Application.LoadLevel("GameScene");
				Constants.level = i;
			}
		}

		//This level will load an AI to react to the user instead of a scheduled order of what units the AI builds
		if (GUI.Button (new Rect (400, 550, 200, 50), "Final Level")) {
			Application.LoadLevel ("GameScene");
			Constants.level = 10;
		}

		//Back button
		if (GUI.Button(new Rect(800, 700, 150, 50), "Back")){
			Application.LoadLevel("MainMenu");
		}
	}
}
