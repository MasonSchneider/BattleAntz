using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	private const string typeName = "BattleAntzNetwork";

	private HostData[] hostList;
	private GUIStyle style = new GUIStyle();
	private string gameName = "New game";
	private Hive _enemyHive;

	// Use this for initialization
	void Start () {
		style.fontSize = 30;
		style.normal.textColor = Color.white;
		DontDestroyOnLoad(this);
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
	
	public void sendArmyAnt(){
		networkView.RPC("recieveArmyAnt", RPCMode.Others);
	}
	
	public void sendBullAnt(){
		networkView.RPC("recieveBullAnt", RPCMode.Others);
	}
	
	public void sendFireAnt(){
		networkView.RPC("recieveFireAnt", RPCMode.Others);
	}
	
	public void sendWorker(){
		networkView.RPC("recieveWorker", RPCMode.Others);
	}
	
	public void sendSellWorker(){
		networkView.RPC("recieveSellWorker", RPCMode.Others);
	}
	
	public void sendUpgrades(int[] upgradeParam){
		networkView.RPC("recieveUpgrades", RPCMode.Others, upgradeParam);
	}
	
	[RPC]
	private void recieveArmyAnt(){
		enemyHive().buyArmyAnt();
	}
	
	[RPC]
	private void recieveBullAnt(){
		enemyHive().buyBullAnt();
	}
	
	[RPC]
	private void recieveFireAnt(){
		enemyHive().buyFireAnt();
	}
	
	[RPC]
	private void recieveWorker(){
		enemyHive().buyWorker();
	}
	
	[RPC]
	private void recieveSellWorker(){
		enemyHive().buyWorker();
	}
	
	[RPC]
	private void recieveUpgrades(int[] upgradeParam){
		enemyHive().upgrade(upgradeParam);
	}
	
	[RPC]
	private void startGame(){
		Constants.multiplayer = true;
		Application.LoadLevel("GameScene");
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
		if(Constants.multiplayer) return;

		//The name of the game label
		GUI.Label(new Rect(100, 50, 100, 50), "Name:", style);
		gameName = GUI.TextField (new Rect (200, 50, 200, 50), gameName, style);

		// If we are a server
		if(Network.isServer) {
			GUI.TextField(new Rect(400, 100, 200, 50), "Players connected:", style);
			if(Network.connections.Length > 0){
				GUI.TextArea(new Rect(400, 150, 200, 50),  Network.connections[0].ipAddress, style);
		
				if (GUI.Button(new Rect(400, 300, 250, 100), "Start game!")){
					networkView.RPC("startGame", RPCMode.Others);
					startGame();
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
		if (GUI.Button(new Rect(800, 700, 150, 50), "Back")){
			stopServer();
			Application.LoadLevel("MainMenu");
			Destroy(this);
		}
	}

	private Hive enemyHive(){
		if(_enemyHive == null)
			_enemyHive = GameObject.FindGameObjectWithTag("EnemyHive").GetComponent("Hive") as Hive;
		return _enemyHive;
	}
}
