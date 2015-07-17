using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision){
		//if collisoin with Projectile start counter
		if (collision.gameObject.tag == "Projectile"){
			Goal.score -= 300;
			StartCoroutine ("wait");

		}


		//if (collision.gameObject.name == "SuperPug"){
		if (collision.gameObject.name == "SuperPug(Clone)"){
			Goal.score += 100;

			StartCoroutine ("superWait");

			Vector3 position = this.transform.position;
			
			//define and instatiate particle effect <3
			Instantiate(Resources.Load ("CollisionEnemy"), position,Quaternion.identity);


		}
	}
	
	
	
	
	IEnumerator wait(){
	
		//set destination to 0 after 1.5f
		yield return new WaitForSeconds (1.5f);
		GameController.S.newDestination = Vector3.zero;
		}

	IEnumerator superWait(){
		
		//set destination to 0 after 1.5f
		yield return new WaitForSeconds (0.5f);
		Destroy(this.gameObject);
	}
	
}

