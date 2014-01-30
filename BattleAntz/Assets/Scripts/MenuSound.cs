using UnityEngine;
using System.Collections;

public class MenuSound : MonoBehaviour
{
	private static MenuSound menuSound = null;
		void Awake(){

		if (MenuSound.menuSound != null && MenuSound.menuSound != this) {
				Destroy (this.gameObject);
			} else {
			MenuSound.menuSound = this;
			}
		
		DontDestroyOnLoad (MenuSound.menuSound.gameObject);

		}

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
		DontDestroyOnLoad (MenuSound.menuSound.gameObject);
		}
}

