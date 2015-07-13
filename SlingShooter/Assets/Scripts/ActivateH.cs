using UnityEngine;
using System.Collections;

public class ActivateH : MonoBehaviour {

	public static bool activeH = false;

	private Vector3 position;

	void OnTriggerEnter(Collider other) {
		// Check if the object entering the trigger is a projectile
		if(other.gameObject.tag == "Projectile") {
			//activate H (-> activate Projectile H)
			activeH = true;

			Goal.score += 200;

			Instantiate(Resources.Load ("Particle Test"), position,Quaternion.identity);

			Destroy(this.gameObject);

		}
		
	}

}
