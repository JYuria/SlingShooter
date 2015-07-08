using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision){
		//if collisoin with Projectile start conter
		if (collision.gameObject.tag == "Projectile"){
			
			StartCoroutine ("wait");

		}
	}
	
	
	
	
	IEnumerator wait(){
	
		//set destination to 0 after 1.5f
		yield return new WaitForSeconds (1.5f);
		GameController.S.newDestination = Vector3.zero;
		}
	
}

