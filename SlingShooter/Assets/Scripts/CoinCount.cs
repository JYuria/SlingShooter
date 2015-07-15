using UnityEngine;
using System.Collections;

public class CoinCount : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		Goal.score += 50;

		Instantiate(Resources.Load ("Particle_Hearts"), GameObject.Find ("Treat").transform.position,Quaternion.identity);

		Destroy(this.gameObject);
	}
}
