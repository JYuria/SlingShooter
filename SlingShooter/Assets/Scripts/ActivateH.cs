using UnityEngine;
using System.Collections;

public class ActivateH : MonoBehaviour {

	public static bool activeH = false;

	private Vector3 position;

	void OnTriggerEnter(Collider other) {
		// Check if the object entering the trigger is a projectile
		if(other.gameObject.tag == "Projectile") {

			activeH = true;

			Instantiate(Resources.Load ("Particle Test"), position,Quaternion.identity);

			Destroy(this.gameObject);

		}
		
	}

}
