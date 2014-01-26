using UnityEngine;
using System.Collections;

public class AboutMenu : MonoBehaviour {

	private string section;

	// Use this for initialization
	void Start() {
		section = "Background";
	}

	void OnGUI() {
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
		}

		GUI.Label(new Rect(350, 100, Screen.width-450, Screen.height-150),"This will be where information about the section goes.\n\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sed sem hendrerit, imperdiet turpis et, iaculis ligula. Etiam porttitor ipsum a lorem commodo luctus. Nulla ultrices euismod urna nec dictum. Etiam nec placerat dolor. Morbi rutrum eu lorem vel porttitor. Fusce felis nunc, aliquam vitae malesuada ac, faucibus in magna. Quisque aliquet nisi non arcu cursus, et ultrices dolor tincidunt. Proin tincidunt nisl eu dictum porttitor. Donec sollicitudin, sem ullamcorper interdum pulvinar, purus sem sagittis magna, ac sollicitudin mi quam vel ante.\n\nVestibulum non ullamcorper nisl, ut ultrices erat. Nam vitae viverra tellus, non iaculis ipsum. Duis mattis imperdiet ante imperdiet mattis. Nam quis tincidunt velit. Nullam tristique consectetur lacus, in aliquam augue consectetur nec. Etiam sit amet lorem in erat tempor scelerisque. Pellentesque eleifend iaculis sem, eget posuere velit euismod ut. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Fusce non quam congue tellus sodales porttitor. Cras eu lectus vitae magna tempus interdum. Aliquam at pretium diam. Mauris bibendum, urna eget tempor luctus, est tellus viverra ante, vitae rhoncus lectus lorem in arcu. Vestibulum et commodo tortor. Nullam ut nunc massa. Fusce feugiat nisl at lacus dapibus, elementum aliquet tortor placerat. Aliquam dui dui, tincidunt nec suscipit et, posuere id libero.\n\nAliquam ut mattis felis. Nulla bibendum facilisis nisl, id consectetur arcu mollis sed. Donec dictum viverra mi, aliquam tempus mi ornare ut. Nunc id nulla velit. In hac habitasse platea dictumst. Ut et elit at ante eleifend fermentum nec tempor enim. Curabitur hendrerit augue id dolor facilisis hendrerit. \n\nDonec sed sagittis leo. Cras adipiscing neque diam, et sollicitudin dolor euismod vel. Aliquam erat volutpat. Nam sit amet lectus a mi placerat bibendum vel ut metus. Nam nec facilisis nisl. Nullam egestas ante et diam tincidunt aliquam ac vel justo. Nullam viverra metus sed sodales commodo. \nDonec auctor blandit ultricies. Sed ante nibh, varius ut felis id, vestibulum tempor velit. Nullam vitae ullamcorper tortor, ornare interdum augue. Suspendisse potenti. Donec imperdiet aliquet leo, vel pretium dui lacinia ut. Morbi id mattis lorem. Suspendisse quam augue, feugiat sit amet laoreet sit amet, dignissim et felis. Ut vestibulum dolor in nulla gravida egestas. Morbi facilisis ornare dignissim.");

	}

}
