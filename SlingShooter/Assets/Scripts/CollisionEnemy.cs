using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision){
		//if collisoin with Projectile start counter
		if (collision.gameObject.tag == "Projectile"){
			Goal.score -= 300;
			StartCoroutine ("wait");

		}
	}
	
	
	
	
	IEnumerator wait(){
	
		//set destination to 0 after 1.5f
		yield return new WaitForSeconds (1.5f);
		GameController.S.newDestination = Vector3.zero;
		}
	
}

