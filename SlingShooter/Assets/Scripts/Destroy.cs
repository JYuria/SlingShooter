using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	private Vector3 position;


	void OnCollisionEnter(Collision collision){
		//if Collision destroy Projectile
		if (collision.gameObject.tag == "Enemy"){

			Destroy(this.gameObject);

			//find position when destroyed
			position = this.transform.position;

			//define and instatiate particle effect <3
			Instantiate(Resources.Load ("explosion_particle"), position,Quaternion.identity);

			}

		}

}