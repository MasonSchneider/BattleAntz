using UnityEngine;
using System.Collections;

public class GuiButton : MonoBehaviour {

	//Use debug to get console printouts for which button is pressed
	//Use hitBox to display the size of the hitbox on screen

	private static GUIStyle emptyStyle = new GUIStyle();
	private static bool hitBox = false;
	private static bool debug = false;

	//Displays a textured button with position r.x and r.y and size of texture
	//r.width and r.height is used for hitbox increase/decrease
	public static bool textureButton(Rect r, Texture t){
		Rect rect = new Rect(r.x, r.y, t.width, t.height);
		GUI.DrawTexture(rect, t);
		if(debug){
			bool status;
			if(!hitBox)
				status = GUI.Button(new Rect(r.x-r.width, r.y-r.height, t.width+r.width*2, t.height+r.height*2), "", emptyStyle);
			else 
				status = GUI.Button(new Rect(r.x-r.width, r.y-r.height, t.width+r.width*2, t.height+r.height*2), "");
			if(status)
				Debug.Log("pressed button: " + rect + " with texture: "+ t);
			return status;
		}
		else if(!hitBox)
			return GUI.Button(new Rect(r.x-r.width, r.y-r.height, t.width+r.width*2, t.height+r.height*2), "", emptyStyle);
		else 
			return GUI.Button(new Rect(r.x-r.width, r.y-r.height, t.width+r.width*2, t.height+r.height*2), "");
	}
	
	//Display a text button with position r.x and r.y and size of the text
	//r.width and r.height is used for hitbox increase/decrease
	public static bool textButton(Rect r, string t, GUIStyle s){
		if(s == null)
			s = new GUIStyle();
		Vector2 size = s.CalcSize(new GUIContent(t));
		if(s == null)
			GUI.Label(new Rect(r.x-size.x/2, r.y-size.y/2, size.x, size.y), t);
		else 
			GUI.Label(new Rect(r.x-size.x/2, r.y-size.y/2, size.x, size.y), t, s);
		
		if(!hitBox)
			return GUI.Button(new Rect(r.x-size.x/2-r.width, r.y-size.y/2-r.height, size.x+r.width*2, size.y+r.height*2), "", s);
		else
			return GUI.Button(new Rect(r.x-size.x/2-r.width, r.y-size.y/2-r.height, size.x+r.width*2, size.y+r.height*2), "");
	}
}

