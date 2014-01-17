using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {

	public string type;

	// Use this for initialization
	void Start () {
		type = "army";
	}

	void OnGUI() {
		GUI.Box(new Rect(Screen.width-400,90,400,200), "Upgrades");
		if(GUI.Button(new Rect(Screen.width-30,95,25,25), "X")) {
			this.enabled = false;
		}
		int typeInt = 0;
		int upgrade = 0;
		switch(type) {
		case "army":
			typeInt = 1;
			break;
		case "fire":
			typeInt = 2;
			break;
		case "bull":
			typeInt = 3;
			break;
		default:
			typeInt = 0;
			break;
		}

		showInfo();

		if(GUI.Button(new Rect(Screen.width-375,120,100,30),"Speed")) {
			upgrade = 0;
		}
		if(GUI.Button(new Rect(Screen.width-375,160,100,30),"Health")) {
			upgrade = 1;
		}
		if(GUI.Button(new Rect(Screen.width-375,200,100,30),"Strength")) {
			upgrade = 2;
		}
		if(GUI.Button(new Rect(Screen.width-375,240,100,30),"Special")) {
			upgrade =3;
		}


	}

	private void showInfo() {
		string desc = "";
		switch(type) {
		case "army":
			desc = "Army ants are standard fighters used to wage war against the rival colony. These ants move at a normal speed and have normal health. Army ants are highly effective against  Bull Ants because they can swarm and overpower them.";
			break;
		case "fire":
			desc = "Fire ants are small insects with a very strong attack. What they lack in health they make up for in damage. These ants are very effective against Army Ants due to their range and ability to bring the pain.";
			break;
		case "bull":
			desc = "Bull ants are massive insects that can withstand a large amount of damage but struggle to deal much damage of their own. These ants are very effective against Fire Ants because they can crush those puny punks and live through the pain.";
			break;
		default:
			desc = "";
			break;
		}
		GUI.Label(new Rect(Screen.width-250,130,200,150), desc);
	}

	private void showSpeed() {

	}
}
