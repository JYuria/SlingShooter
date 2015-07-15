using UnityEngine;
using System.Collections;

public class CoinCount : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		Goal.score += 50;

		Destroy(this.gameObject);
	}
}
