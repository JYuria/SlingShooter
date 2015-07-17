using UnityEngine;
using System.Collections;

public class ActivateS : MonoBehaviour {

	public static bool activeS = false;
	
	 
	
	void OnTriggerEnter(Collider other) {
		// Check if the object entering the trigger is a projectile
		if(other.gameObject.tag == "Projectile" || other.gameObject.tag == "SuperPug") {
			//activate S (-> activate Projectile S)
			activeS = true;

			Vector3 position = this.gameObject.transform.position;

			Goal.score += 200;
			
			Instantiate(Resources.Load ("Particle_Heart"), position,Quaternion.identity);
			
			Destroy(this.gameObject);
			
		}
		
	}
	
	
	void Update(){
		
		transform.Rotate (new Vector3(0,0,-Time.deltaTime*40));
		
	}
	
}

