using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public static FollowCam S; //single instance if this class

	//point of interest
	public GameObject poi;
	private float camZ;

	public float easing = 0.05f;

	void Awake() {
		S = this;
		camZ = transform.position.z;
	}

	void FixedUpdate (){
		//Check if poi is empty

	if (poi == null){
			return;
		}

		Vector3 destination = poi.transform.position;
		destination = Vector3.Lerp(transform.position, destination, easing);
		destination.z = camZ;

	transform.position = destination;

	}




	//public static function Lerp(from: Vector3, to: Vector3, t: float): Vector3; 


}
