using UnityEngine;
using System.Collections;

public class TestScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	[RPC]
	private void recieveMessage(){
		Debug.Log("recieved message: ");
	}
	
	void OnGUI() {
		//The name of the game label
		GUI.Label(new Rect(100, 50, 100, 50), "Now playing!");

		if (GUI.Button(new Rect(100, 100, 250, 100), "Send message"))
			networkView.RPC("recieveMessage", RPCMode.Others);
	}

}
