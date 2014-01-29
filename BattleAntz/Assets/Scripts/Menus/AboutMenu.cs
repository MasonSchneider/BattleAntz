﻿using UnityEngine;
using System.Collections;

public class AboutMenu : MonoBehaviour {

	private string section;
	private Constants constants;
	// Use this for initialization
	void Start() {
		constants = gameObject.GetComponent<Constants>();
		section = "Background";
	}

	void OnGUI() {
		GUI.skin.box.fontSize = 28;
		GUI.skin.label.fontSize = 22;

		GUI.Box(new Rect(300, 50, Screen.width-350, Screen.height-100),section);

		if (GUI.Button(new Rect(50,50,200,50), "Background")) {
			section = "Background";
		} if (GUI.Button(new Rect(50,150,200,50), "Worker Ants")) {
			section = "Worker Ants";
		} if (GUI.Button(new Rect(50,250,200,50), "Army Ants")) {
			section = "Army Ants";
		} if (GUI.Button(new Rect(50,350,200,50), "Bull Ants")) {
			section = "Bull Ants";
		} if (GUI.Button(new Rect(50,450,200,50), "Fire Ants")) {
			section = "Fire Ants";
		} if (GUI.Button(new Rect(50,550,200,50), "Credits")) {
			section = "Credits";
		} if (GUI.Button(new Rect(50,650,200,50), "Back")) {
			Application.LoadLevel("MainMenu");
		}

		string infoText = "";

		switch(section) {
		case "Background":
			infoText = "You and your colony have settled in a family’s backyard with dreams of conquering the neighborhood. Once you’ve finally gotten comfortable, word spreads that your colony has hit the sweet spot for all things sweet. A jealous queen with no home hears about your colony and  decides she deserves to rule your colony and plans a takeover. And so, the invasion begins...\n\nTo conquer the queen you must tell your hive when to make sugar or when to fight back. Sugar is what makes your hive tick so be sure to collect as much as possible in order to make the biggest army this backyard has ever seen!";
			break;
		case "Worker Ants":
			infoText = "From your first breath you’ve been working for the weekend. It will never come. You know it but you still endlessly go out into the unknown toiling day after day for your colony’s supplies.\n\nStrategy: Small drones that collect sugar for the colony. These ants move at a normal speed and cannot attack. Produces +10 sugar every 5 seconds.\n\nCost: "+constants.WORKER_COST+"\nDamage: 0\nLife: 1\nSpeed: 1\nAttack Speed: 1";
			break;
		case "Army Ants":
			infoText = "You were born for this, for the short 3 days of your life you have trained fighting rocks in the garden to strengthen yourself in order for the opportunity to lay down your life for your colony, your queen, and glory in battle.  On your off days you enjoy long walks along the sidewalk after the rain.\n\nStrategy: Standard fighters to wage war against the rival colony. These ants move at a normal speed and have normal health. Army ants are highly effective against  Bull Ants because they can swarm and overpower them.\n\nCost: "+constants.ARMY_ANT_COST+"\nDamage: 10\nLife: 50\nSpeed: 1\nAttack Speed: 1";
			break;
		case "Bull Ants":
			infoText = "Let’s be honest. You work out. You have perfected your body and can squat a whole leaf. You question whether your enemies even lift, bro. Your only problem on the battlefield is movement, since you skipped leg day too many times.\n\nStrategy: Massive insects that can withstand a large amount of damage, but deals less overall damage. These ants are very effective against Fire Ants.\n\nCost: "+constants.BULL_ANT_COST+"\nDamage: 30\nLife: 100\nSpeed: .5\nAttack Speed: .5";
			break;
		case "Fire Ants":
			infoText = "You realized you were special when you accidentally killed your family. Since that day, all you have practiced is the art of killing. Your venom is deadly. Your favorite music is Metallica.\n\nStrategy: Weak insects with a very strong attack. These ants are very effective against Army Ants.\n\nCost: "+constants.FIRE_ANT_COST+"\nDamage: 50\nLife: 50\nSpeed: .5\nAttack Speed: .5";
			break;
		case "Credits":
			infoText = "Battle Antz was created as a final project for the Game Development course at Rose-Hulman Institute of Technology. David Jangdal created the idea for this game and Mason Schneider, Mark Hein, Josh Wright, and Luke Mader joined him in the development.\n\nPoject Leader and AI: David Jangdal\nInterface Developer: Mason Schneider\nBackend Developer: Mark Hein\nGraphics and Sound: Josh Wright\nLevel Interface: Luke Mader\n\nInstructor: Cary Laxer";
			break;
		default:
			infoText = "You and your colony have settled in a family’s backyard with dreams of conquering the neighborhood. Once you’ve finally gotten comfortable, word spreads that your colony has hit the sweet spot for all things sweet. A jealous queen with no home hears about your colony and  decides she deserves to rule your colony and plans a takeover. And so, the invasion begins...\n\nTo conquer the queen you must tell your hive when to make sugar or when to fight back. Sugar is what makes your hive tick so be sure to collect as much as possible in order to make the biggest army this backyard has ever seen!";
			break;
		}

		GUI.Label(new Rect(350, 100, Screen.width-450, Screen.height-150),infoText);
	}

}
