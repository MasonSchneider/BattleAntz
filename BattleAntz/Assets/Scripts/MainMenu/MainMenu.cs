using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture newGameTexture;
	
	private Rect newGameRect;

	// Use this for initialization
	void Start () {
		newGameRect = new Rect(200, 200, 30, 30);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		if (GuiButton.textureButton(newGameRect, newGameTexture)) {
			Application.LoadLevel("GameScene");
		}
	}
}
