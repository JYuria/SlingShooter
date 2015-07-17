using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	// Static field accessible from anywhere
	// Storing if the goal was met
	public static bool goalMet = false;

	public static int score = 1000;

	public static int finalScore;

	private int i;
	

	void Start(){
	
		 i = Application.loadedLevel;

	}


	void Update (){
	
		if (goalMet == true) {
			finalScore = score;
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
	


}
