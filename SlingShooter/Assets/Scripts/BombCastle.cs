using UnityEngine;
using System.Collections;

public class BombCastle : MonoBehaviour {

	private bool explosion = false ;

	void OnCollisionEnter(Collision collision){
		//if Collision and if not exploded yet
		if (collision.gameObject.tag == "Castle"){

			if (explosion == false){
					
			//find position when destroyed
			Vector3 position = this.gameObject.transform.position;
			
			//define and instatiate particle effect <3
			//			Instantiate(Resources.Load ("explosion_particle"), position,Quaternion.identity);
			Instantiate(Resources.Load ("explosion_particle"), position,Quaternion.identity);
			
			explosion = true;

			Destroy(collision.gameObject);

			}
		}
		
	}

}

