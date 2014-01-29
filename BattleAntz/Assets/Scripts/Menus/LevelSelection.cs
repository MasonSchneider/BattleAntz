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
		//TODO Maybe do this with for loop and space out the buttons. 
		for(int i=0; i<maxlevels; i++){
			if (GUI.Button(new Rect(100+spacingX*(i%3), 100+spacingY*(i/3), 200, 50), "Level " + (i+1))) {
				Application.LoadLevel("GameScene");
				Publics.level = i;
			}
		}
//		if (GUI.Button(new Rect(100, 100, 200, 50), "Level 1")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(400, 100, 200, 50), "Level 2")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(700, 100, 200, 50), "Level 3")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(100, 250, 200, 50), "Level 4")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(400, 250, 200, 50), "Level 5")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(700, 250, 200, 50), "Level 6")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(100, 400, 200, 50), "Level 7")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(400, 400, 200, 50), "Level 8")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(700, 400, 200, 50), "Level 9")) {
//			Application.LoadLevel("GameScene");
//		}
//		if (GUI.Button(new Rect(400, 550, 200, 50), "Final Level")) {
//			Application.LoadLevel("GameScene");
//		}

		//Back button
		if (GUI.Button(new Rect(800, 700, 150, 50), "Back")){
			Application.LoadLevel("MainMenu");
		}
	}
}
