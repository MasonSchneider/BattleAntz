using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {

	public string type;
	private int typeInt = 0;
	private int upgrade = 0;
	private bool showingInfo;

	// Use this for initialization
	void Start () {
		showingInfo = true;
	}

	public void OnGUI() {
		GUI.Box(new Rect(Screen.width-400,90,400,200), "Upgrades");
		if(GUI.Button(new Rect(Screen.width-30,95,25,25), "X")) {
			showingInfo = true;
			this.enabled = false;
		}

		Debug.Log(type);

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

		Debug.Log(typeInt.ToString());

		if(showingInfo)
			showInfo();
		else
			showUpgrade();

		if(GUI.Button(new Rect(Screen.width-375,120,100,30),"Speed")) {
			showingInfo = false;
			upgrade = 0;
		}
		if(GUI.Button(new Rect(Screen.width-375,160,100,30),"Health")) {
			showingInfo = false;
			upgrade = 1;
		}
		if(GUI.Button(new Rect(Screen.width-375,200,100,30),"Strength")) {
			showingInfo = false;
			upgrade = 2;
		}
		if(GUI.Button(new Rect(Screen.width-375,240,100,30),"Special")) {
			showingInfo = false;
			upgrade =3;
		}


	}

	private void showUpgrade() {
		string desc = "";

		switch(upgrade) {
		case 0:
			desc = "This upgrade causes the " + type + " ant to move towards the enemy faster. This gives the ability to rush the enemy before they know what hit them.\n\n     Cost: 500 Sugar";
			break;
		case 1:
			desc = "This upgrade causes the " + type + " ant to spawn with more health. This allows it to leave longer in fights and even helps it beat its counter.\n\n\n     Cost: 500 Sugar";
			break;
		case 2:
			desc = "This upgrade causes the " + type + " ant to have stronger attacks. This gives the ant the power to crush his enemies and carry his team to success.\n\n     Cost: 500 Sugar";;
			break;
		case 3:
			switch(type) {
			case "army":				
				desc = "This upgrade causes the " + type + " ant to \n\n     Cost: 500 Sugar";
				break;
			case "fire":
				desc = "This upgrade causes the " + type + " ant to \n\n     Cost: 500 Sugar";
				break;
			case "bull":
				desc = "This upgrade causes the " + type + " ant to \n\n     Cost: 500 Sugar";
				break;
			default:
				desc = "This upgrade causes the worker ant to \n\n     Cost: 500 Sugar";
				break;
			}
			break;
		default:
			break;
		}
		GUI.Label(new Rect(Screen.width-250,130,200,150), desc);
		if(GUI.Button(new Rect(Screen.width-200,250,100,30),"Purchase")) {
			Debug.Log("Purchased" + typeInt.ToString() + type + upgrade.ToString());
			int[] upgradeParam = new int[]{typeInt,upgrade};
			Debug.Log(upgradeParam[0].ToString() + upgradeParam[1].ToString());
			gameObject.GetComponent<GameMenu>().playerHive.upgrade(upgradeParam);
		}
	}

	private void showInfo() {
		string desc = "";
		switch(type) {
		case "army":
			desc = "Army ants are standard fighters used to wage war against the rival colony. These ants move at a normal speed and have normal health. Army ants are highly effective against  Bull Ants because they can swarm and overpower them.\nCost: 50 Sugar";
			break;
		case "fire":
			desc = "Fire ants are small insects with a very strong attack. What they lack in health they make up for in damage. These ants are very effective against Army Ants due to their range and ability to bring the pain.\nCost: 150 Sugar";
			break;
		case "bull":
			desc = "Bull ants are massive insects that can withstand a large amount of damage but struggle to deal much damage of their own. These ants are very effective against Fire Ants because they can crush those puny punks and live through the pain.\nCost: 100 Sugar";
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
