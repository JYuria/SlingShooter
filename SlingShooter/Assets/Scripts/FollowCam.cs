using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	
	public static FollowCam S; // Singleton instance of this class
	
	public float easing = 0.05f;
	
	Vector2 minXY;
	
	public GameObject poi;
	private float camZ;



	
	void Awake() {
		S = this;
		camZ = transform.position.z;
		
	}
	
	void FixedUpdate() {
		Vector3 destination;
		
		// Check if the poi is empty
		if(poi == null) {
			// Set the destination to the Zero-Vector
			destination = Vector3.zero;
			destination = GameController.S.newDestination;
		} else {
			// the poi exists
			// Get its position
			//destination = poi.transform.position;
			destination = GameController.S.newDestination;
			// Check if the poi is a projectile
			if (poi.tag == "Projectile") {
				
				// CHECK IF IT IS RESTING (Sleeping)
				if(poi.GetComponent<Rigidbody>().IsSleeping()){
					
					// set it to "null" as default value in next update
					poi = null;
					GameController.S.newDestination = Vector3.zero;
					return;
					
				}
				
				
			}
		}


	


		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);
		
		destination = Vector3.Lerp(transform.position, destination, easing);
		destination.z = camZ;

		transform.position = destination;
		
		this.GetComponent<Camera>().orthographicSize = 10 + destination.y;
		
	}
	
}









