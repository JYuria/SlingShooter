using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	// Static field accessible from anywhere
	// Storing if the goal was met
	public static bool goalMet = false;

	public static int score = 1000;
	
	void Update (){
	
		if (goalMet == true) {
			if (score < 0){
				score = 0;
			}
		}

	}


	// Trigger got entered
	void OnTriggerEnter(Collider other) {
		// Check if the object entering the trigger is a projectile
		if(other.gameObject.tag == "Projectile"|| other.gameObject.tag == "SuperPug") {
			// Set the staic field to true
			goalMet = true;
			// Set the alpha of the color to a higher opacity
			
			Color c = this.gameObject.GetComponent<Renderer>().material.color;
			
			c.a = 1;
			
			this.gameObject.GetComponent<Renderer>().material.color = c;


		

		}
		
	}
	
	void OnGUI () {

		if (goalMet == true) {
			GUI.Box (new Rect (Screen.width/2-(Screen.width/4), Screen.height/2-(Screen.width/6), Screen.width/2, Screen.width/3), ("Score "+score));

			if (GUI.Button (new Rect (Screen.width/2-(Screen.width/4), Screen.height/2+(Screen.width/14), Screen.width/6, Screen.height/6), "Menu")) {
				Application.LoadLevel("Menu");
				Slingshot.counter = 0;
			}
			if (GUI.Button (new Rect (Screen.width/2-(Screen.width/4)+Screen.width/6, Screen.height/2+(Screen.width/14), Screen.width/6, Screen.height/6), "Again")) {
				Application.LoadLevel("Game");
				goalMet = false;
				ActivateH.activeH = false;
				Slingshot.counter = 0;
			}
			if (GUI.Button (new Rect (Screen.width/2-(Screen.width/4)+(Screen.width/6*2), Screen.height/2+(Screen.width/14), Screen.width/6, Screen.height/6), "Next")) {
				Application.LoadLevel("Level2");
				Slingshot.counter = 0;
			}


		}

	}
}
