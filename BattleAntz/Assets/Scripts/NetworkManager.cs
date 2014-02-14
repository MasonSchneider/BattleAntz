using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	private const string typeName = "BattleAntzNetwork";

	private HostData[] hostList;
	private GUIStyle style = new GUIStyle();
	private string gameName = "New game";
	private Hive _enemyHive;
	private Hive _playerHive;

	private float delay;

	public Object armyPrefab;

	// Use this for initialization
	void Start () {
		style.fontSize = 30;
		style.normal.textColor = Color.white;
		DontDestroyOnLoad(this);
	}

	private void Update(){
		if(Network.isServer && Constants.multiplayer && Time.time > delay)
			sendState();
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
		Constants.multiplayer = false;
	}
	
	private void connect(HostData hostData) {
		Network.Connect(hostData);
	}

	private void refreshHostList() {
		MasterServer.RequestHostList(typeName);
	}
	
	public void pause(){
		networkView.RPC("receivePause", RPCMode.Others, true);
	}

	public void resume(){
		networkView.RPC("receivePause", RPCMode.Others, false);
	}
	
	public void surrender(){
		networkView.RPC("receiveSurrender", RPCMode.Others);
		stopServer();
		Destroy(this);
	}
	
	public void restart(){
		networkView.RPC("receiveRestart", RPCMode.Others);
	}

	public void sendArmyAnt(){
		if(Network.isClient)
			networkView.RPC("receiveArmyAnt", RPCMode.Others);
	}
	
	public void sendBullAnt(){
		if(Network.isClient)
			networkView.RPC("receiveBullAnt", RPCMode.Others);
	}
	
	public void sendFireAnt(){
		if(Network.isClient)
			networkView.RPC("receiveFireAnt", RPCMode.Others);
	}
	
	public void sendWorker(){
		if(Network.isClient)
			networkView.RPC("receiveWorker", RPCMode.Others);
	}
	
	public void sendSellWorker(){
		if(Network.isClient)
			networkView.RPC("receiveSellWorker", RPCMode.Others);
	}
	
	public void sendUpgrades(int[] upgradeParam){
		if(Network.isClient)
			networkView.RPC("receiveUpgrades", RPCMode.Others, upgradeParam);
	}

	private void sendState(){
		networkView.RPC("receiveHiveState", RPCMode.Others, new int[]{(int)enemyHive().health, enemyHive().workers, enemyHive().income, enemyHive().sugar});
	}

	[RPC]
	private void receiveHiveState(int[] values){
		playerHive().health = values[0];
		playerHive().workers = values[1];
		playerHive().income = values[2];
		playerHive().sugar = values[3];
	}

	[RPC]
	private void receivePause(bool pause){
		Constants.paused = pause;
		Time.timeScale = pause ? 0 : 1;
	}
	
	[RPC]
	private void receiveRestart(){
		Application.LoadLevel("GameScene");
		Constants.paused = false;
		Time.timeScale = 1;
	}
	
	[RPC]
	private void receiveSurrender(){
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
		Constants.paused = false;
		disconnect();
		Destroy(this);
	}

	[RPC]
	private void receiveArmyAnt(){
		enemyHive().buyArmyAnt();
	}
	
	[RPC]
	private void receiveBullAnt(){
		enemyHive().buyBullAnt();
	}
	
	[RPC]
	private void receiveFireAnt(){
		enemyHive().buyFireAnt();
	}
	
	[RPC]
	private void receiveWorker(){
		enemyHive().buyWorker();
	}
	
	[RPC]
	private void receiveSellWorker(){
		enemyHive().sellWorker();
	}
	
	[RPC]
	private void receiveUpgrades(int[] upgradeParam){
		enemyHive().upgrade(upgradeParam);
	}
	
	[RPC]
	private void startGame(){
		Constants.multiplayer = true;
		delay = Time.time + 0.5f;
		Application.LoadLevel("GameScene");
	}

	void OnServerInitialized() {
//		Debug.Log("Server Initializied");
	}
	
	void OnConnectedToServer() {
//		Debug.Log("Connected to server");
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
	
	private Hive playerHive(){
		if(_playerHive == null)
			_playerHive = GameObject.FindGameObjectWithTag("PlayerHive").GetComponent("Hive") as Hive;
		return _playerHive;
	}
}
