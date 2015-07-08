using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public float speedFactor = 1;

	private Vector3 velocity;

	private Vector3 oldPosition;

	private Vector3 standardPosition;




	void Start(){
		GameObject cameraPosition = GameObject.Find("Camera");
		//oldPosition is first camera position
		oldPosition = cameraPosition.transform.position;

		standardPosition = this.transform.position;

	}


	void Update () {
	
		GameObject cameraPosition = GameObject.Find("Camera");


		//check if old and new position are not the same
		if (oldPosition != cameraPosition.transform.position){
			//check if destination moved
			if (GameController.S.newDestination != Vector3.zero){

				//if camera moves to the right (= old position < actual position)
				if (oldPosition.x < cameraPosition.transform.position.x ){
					//then change position of backgoround to cameraPosition * speedFactor
					velocity.x = (cameraPosition.transform.position.x-oldPosition.x) * speedFactor;
					transform.Translate (velocity * Time.deltaTime);
				}
			
				//f camera moves to the left (= old position > actual position)
				if (oldPosition.x > cameraPosition.transform.position.x ){
					//then change position of backgoround to cameraPosition * speedFactor
					velocity.x = (cameraPosition.transform.position.x-oldPosition.x) * speedFactor;
					transform.Translate (velocity * Time.deltaTime);
				}
			}
		

			//if destination = 0, back to standart position 
			if (GameController.S.newDestination == Vector3.zero){
				transform.position = Vector3.Lerp(this.transform.position, standardPosition, Time.deltaTime);
			}
		}


		//update oldPosition
		oldPosition = cameraPosition.transform.position;


			
	}
}
