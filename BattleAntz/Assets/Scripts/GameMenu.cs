using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public Texture pauseTexture;
	public Texture antTexture;

	private Rect pauseRect;
	private Rect antRect;

	private AntController antController;
	
	// Use this for initialization
	void Start () {
		pauseRect = new Rect(Screen.width/2 - 24, 24, 52, 55);
		antRect = new Rect(Screen.width - 78*4, 20, 78, 58);
		antController = GameObject.Find("Ant Controller").GetComponent("AntController") as AntController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI () {
		GUI.Box(new Rect(0,0,Screen.width,90), "Battle Antz");
		if (GuiButton.textureButton(pauseRect, pauseTexture)) {
			Application.LoadLevel("MainMenu");
		}

		if (GuiButton.textureButton(antRect, antTexture)) {
			antController.spawnAnt();
		}
	}
}
