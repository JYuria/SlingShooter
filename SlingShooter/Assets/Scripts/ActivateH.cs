using UnityEngine;
using System.Collections;

public class ActivateH : MonoBehaviour {

	public static bool activeH = false;


	void OnTriggerEnter(Collider other) {
		// Check if the object entering the trigger is a projectile
		if(other.gameObject.tag == "Projectile" || other.gameObject.tag == "SuperPug") {
			//activate H (-> activate Projectile H)
			activeH = true;

			Vector3 position = this.transform.position;

			Goal.score += 200;

			Instantiate(Resources.Load ("Particle_Heart"), position,Quaternion.identity);

			Destroy(this.gameObject);

		}
		
	}


	void Update(){

		transform.Rotate (new Vector3(0,Time.deltaTime*25,0));

	}

}
