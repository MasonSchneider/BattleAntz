using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture newGameTexture;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		if (GuiButton.textureButton(new Rect(400, 100, 30, 30), newGameTexture)) {
			Application.LoadLevel("GameScene");
		}
		if (GUI.Button(new Rect(400, 200, 200, 50), "Single Player")) {
			Application.LoadLevel("SinglePlayer");
		}
		if (GUI.Button(new Rect(400, 300, 200, 50), "Multi Player")) {
			Application.LoadLevel("MultiPlayer");
		}
	}
}
