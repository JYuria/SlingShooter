using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	private Vector3 position;


	void OnCollisionEnter(Collision collision){
		//if Collision destroy Projectile
		if (collision.gameObject.tag == "Enemy"){

			StartCoroutine ("wait");

			//find position when destroyed
			position = GameObject.Find("Enemy").transform.position;

			//define and instatiate particle effect <3
//			Instantiate(Resources.Load ("explosion_particle"), position,Quaternion.identity);
			Instantiate(Resources.Load ("CollisionEnemy"), position,Quaternion.identity);

			}

		}

	IEnumerator wait(){
		
		//destroy Projectile after 0.5f
		yield return new WaitForSeconds (0.5f);
		Destroy(this.gameObject);
	}


}