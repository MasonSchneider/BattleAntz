using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	private const string typeName = "BattleAntzNetwork";

	private HostData[] hostList;
	private GUIStyle style = new GUIStyle();
	private string gameName = "New game";

	// Use this for initialization
	void Start () {
		style.fontSize = 30;
	}
	
	private void startServer() {
		Network.InitializeServer(2, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}
	
	private void stopServer() {
		MasterServer.UnregisterHost();
		disconnect();
	}
	
	private void disconnect(){
		Network.Disconnect();
	}
	
	private void connect(HostData hostData) {
		Network.Connect(hostData);
	}

	private void refreshHostList() {
		MasterServer.RequestHostList(typeName);
	}

	[RPC]
	private void startGame(){
		Application.LoadLevel("GameScene");
		Debug.Log("Should start game");
	}

	void OnServerInitialized() {
		Debug.Log("Server Initializied");
	}
	
	void OnConnectedToServer() {
		Debug.Log("Connected to server");
	} 

	void OnMasterServerEvent(MasterServerEvent msEvent) {
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}

	void OnGUI() {
		//The name of the game label
		GUI.Label(new Rect(100, 50, 100, 50), "Name:", style);
		gameName = GUI.TextField(new Rect(200, 50, 200, 50), gameName, style);

		// If we are a server
		if(Network.isServer) {
			GUI.TextField(new Rect(400, 100, 200, 50), "Players connected:", style);
			if(Network.connections.Length > 0){
				GUI.TextArea(new Rect(400, 150, 200, 50),  Network.connections[0].ipAddress, style);
		
				if (GUI.Button(new Rect(400, 300, 250, 100), "Start game!")){
					networkView.RPC("startGame", RPCMode.Others);
					Application.LoadLevel("GameScene");
				}
			}

			if (GUI.Button(new Rect(100, 100, 250, 100), "Close Server"))
				stopServer();
		}

		// If we are a client
		else if(Network.isClient) {	
			GUI.Label(new Rect(100, 150, 100, 50), "Connected to: " + MasterServer.ipAddress, style);

			if (GUI.Button(new Rect(100, 300, 250, 100), "Disconnect"))
				disconnect();
		}

		// Else we are nothing yet
		else {
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				startServer();
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
				refreshHostList();
			
			if (hostList != null) {
				for (int i = 0; i < hostList.Length; i++) {
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						connect(hostList[i]);
				}
			}
		}

		//Back button
		if (GUI.Button(new Rect(100, 100, 250, 100), "Back"))
			Application.LoadLevel("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
