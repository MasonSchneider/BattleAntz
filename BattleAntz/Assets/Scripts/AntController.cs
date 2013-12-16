using UnityEngine;
using System.Collections;

public class AntController : MonoBehaviour {
	public Ant ant;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnAnt(){
		Debug.Log("spawn an ant");
		
		Ant a = (Ant) Instantiate (this.ant);
		a.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
	}
}
