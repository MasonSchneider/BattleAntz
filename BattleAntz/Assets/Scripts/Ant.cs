using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	private float delta_x = 0.3f;
	private float delta_y = 0.1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(delta_x*Random.Range(-1.0f,1.0f), delta_y*Random.Range(-1.0f,1.0f), 0);
	}
}
