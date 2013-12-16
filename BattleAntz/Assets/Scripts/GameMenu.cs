using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public Texture pauseTexture;
	
	private Rect pauseRect;
	
	// Use this for initialization
	void Start () {
		pauseRect = new Rect(100, 20, 30, 30);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI () {
		if (GuiButton.textureButton(pauseRect, pauseTexture)) {
			Application.LoadLevel("MainMenu");
		}
	}
}
