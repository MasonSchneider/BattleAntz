using UnityEngine;
using System.Collections;

public class AboutMenu : MonoBehaviour {

	private string section;
	// Use this for initialization
	void Start() {
		section = "Controls";
	}

	void OnGUI() {
		GUI.skin.box.fontSize = 28;
		GUI.skin.label.fontSize = 22;

		GUI.Box(new Rect(300, 50, Screen.width-350, Screen.height-100),section);
		if (GUI.Button(new Rect(50,50,200,50), "Controls")) {
			section = "Controls";
		} if (GUI.Button(new Rect(50,135,200,50), "Background")) {
			section = "Background";
		} if (GUI.Button(new Rect(50,220,200,50), "Worker Ants")) {
			section = "Worker Ants";
		} if (GUI.Button(new Rect(50,305,200,50), "Army Ants")) {
			section = "Army Ants";
		} if (GUI.Button(new Rect(50,390,200,50), "Bull Ants")) {
			section = "Bull Ants";
		} if (GUI.Button(new Rect(50,475,200,50), "Fire Ants")) {
			section = "Fire Ants";
		} if (GUI.Button(new Rect(50,560,200,50), "Credits")) {
			section = "Credits";
		} if (GUI.Button(new Rect(50,Screen.height-100,200,50), "Back")) {
			Application.LoadLevel("MainMenu");
		}

		string infoText = "";

		switch(section) {
		case "Controls":
			infoText = "Top Left: Here you'll see your current sugar (resources), which are used to spawn new ants, as well as buttons for buying and selling workers. More workers = faster sugar generation.\n\nTop Middle: The pause button lets you pause the game.\n\nTop Right: Here are the buttons to spawn each type of ant, as well as the small + button above each ant button, which will open an upgrade menu for that ant type. Purchasing these upgrades will improve your ants, making them more effective in combat.\n\n\nHotkeys: \n\nQ = Buy Worker\nA = Sell Worker\nW = Buy Army Ant\nE = Buy Bull Ant\nR = Buy Fire Ant\nP = Pause Game";
			break;
		case "Background":
			infoText = "You and your colony have settled in a family’s backyard with dreams of conquering the neighborhood. Once you’ve finally gotten comfortable, word spreads that your colony has hit the sweet spot for all things sweet. A jealous queen with no home hears about your colony and  decides she deserves to rule your colony and plans a takeover. And so, the invasion begins...\n\nTo conquer the queen you must tell your hive when to make sugar or when to fight back. Sugar is what makes your hive tick so be sure to collect as much as possible in order to make the biggest army this backyard has ever seen!";
			break;
		case "Worker Ants":
			infoText = "From your first breath you’ve been working for the weekend. It will never come. You know it but you still endlessly go out into the unknown toiling day after day for your colony’s supplies.\n\nStrategy: Small drones that collect sugar for the colony. These ants move at a normal speed and cannot attack. Produces +"+Constants.WORKER_PRODUCTION+" sugar every 5 seconds.\n\nCost: "+Constants.WORKER_COST+"\nDamage: N/A\nLife: N/A\nSpeed: N/A";
			break;
		case "Army Ants":
			infoText = "You were born for this, for the short 3 days of your life you have trained fighting rocks in the garden to strengthen yourself in order for the opportunity to lay down your life for your colony, your queen, and glory in battle.  On your off days you enjoy long walks along the sidewalk after the rain.\n\nStrategy: Standard fighters to wage war against the rival colony. These ants move at a fast speed and have normal health. Army ants are highly effective against  Bull Ants because they can swarm and overpower them.\n\nCost: "+Constants.ARMY_ANT_COST+"\nDamage: "+Constants.ARMY_ANT_DAMAGE+"\nLife: "+Constants.ARMY_ANT_LIFE+"\nSpeed: "+Constants.ARMY_ANT_SPEED;
			break;
		case "Bull Ants":
			infoText = "Let’s be honest. You work out. You have perfected your body and can squat a whole leaf. You question whether your enemies even lift, bro. Your only problem on the battlefield is movement, since you skipped leg day too many times.\n\nStrategy: Massive insects that can withstand a large amount of damage, but deals less overall damage. These ants are very effective against Fire Ants.\n\nCost: "+Constants.BULL_ANT_COST+"\nDamage: "+Constants.BULL_ANT_DAMAGE+"\nLife: "+Constants.BULL_ANT_LIFE+"\nSpeed: "+Constants.BULL_ANT_SPEED;
			break;
		case "Fire Ants":
			infoText = "You realized you were special when you accidentally killed your family. Since that day, all you have practiced is the art of killing. Your venom is deadly. Your favorite music is Metallica.\n\nStrategy: Weak insects with a very strong attack. These ants are very effective against Army Ants.\n\nCost: "+Constants.FIRE_ANT_COST+"\nDamage: "+Constants.FIRE_ANT_DAMAGE+"\nLife: "+Constants.FIRE_ANT_LIFE+"\nSpeed: "+Constants.FIRE_ANT_SPEED;
			break;
		case "Credits":
			infoText = "Battle Antz was created as a final project for the Game Development course at Rose-Hulman Institute of Technology. David Jangdal created the idea for this game and Mason Schneider, Mark Hein, Josh Wright, and Luke Mader joined him in the development.\n\nProject Leader and AI: David Jangdal\nInterface Developer: Mason Schneider\nBackend Developer: Mark Hein\nGraphics and Sound: Josh Wright\nLevel Interface and Balancing: Luke Mader\n\nInstructor: Cary Laxer";
			break;
		default:
			infoText = "Top Left: Here you'll see your current sugar (resources), which are used to spawn new ants, as well as buttons for buying and selling workers. More workers = faster sugar generation.\n\nTop Middle: The pause button lets you pause the game.\n\nTop Right: Here are the buttons to spawn each type of ant, as well as the small + button above each ant button, which will open an upgrade menu for that ant type. Purchasing these upgrades will improve your ants, making them more effective in combat.\n\n\nHotkeys: \n\nQ = Buy Worker\nA = Sell Worker\nW = Buy Army Ant\nE = Buy Bull Ant\nR = Buy Fire Ant\nP = Pause Game";
			break;
		}

		GUI.Label(new Rect(350, 100, Screen.width-450, Screen.height-150),infoText);
		GUI.skin.box.fontSize = 12;
		GUI.skin.label.fontSize = 12;
	}

}
