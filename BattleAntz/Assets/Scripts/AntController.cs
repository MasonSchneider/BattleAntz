using UnityEngine;
using System.Collections;

public class AntController : MonoBehaviour {
	public Ant ant;

	private int amount = 1; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnAnt(){
		for(int i=0; i<amount; i++) 
			Instantiate (this.ant);
	}
}
