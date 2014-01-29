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
		if (GUI.Button(new Rect(400, 200, 200, 50), "Single Player")) {
			Application.LoadLevel("LevelSelection");
		}
		if (GUI.Button(new Rect(400, 300, 200, 50), "Multi Player")) {
			Application.LoadLevel("MultiPlayer");
		}
		if (GUI.Button(new Rect(400, 400, 200, 50), "About")) {
			Application.LoadLevel("About");
		}
	}
}
