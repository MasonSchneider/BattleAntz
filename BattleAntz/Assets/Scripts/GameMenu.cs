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
		pauseRect = new Rect(300, 20, 30, 30);
		antRect = new Rect(0, 0, 10, 10);
		antController = GameObject.Find("Ant Controller").GetComponent("AntController") as AntController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI () {
		if (GuiButton.textureButton(pauseRect, pauseTexture)) {
			Application.LoadLevel("MainMenu");
		}

		if (GuiButton.textureButton(antRect, antTexture)) {
			antController.spawnAnt();
		}
	}
}
