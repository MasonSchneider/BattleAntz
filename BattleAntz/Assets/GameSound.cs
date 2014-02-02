using UnityEngine;
using System.Collections;

public class GameSound : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
		if (MenuSound.menuSound != null) {
			Destroy (MenuSound.menuSound.gameObject);
		}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}

