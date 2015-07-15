using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {


	//inspector fields
	public GameObject[] prefabProjectile;

	public float velocityMult = 10.0f;


	//internal fields
	private GameObject Launchpoint;
	private bool aimingMode;

	private Vector3 launchPos;
	public GameObject projectile;

	private bool hasBeenPressed = false;

	public static int counter;






	void Awake(){
		Transform LaunchpointTrans = transform.Find ("Launchpoint");
		Launchpoint = LaunchpointTrans.gameObject;
		Launchpoint.SetActive(false);
		launchPos = Launchpoint.transform.position;
		GameController.activateChangeButton = false;
	}

	void OnMouseEnter(){
		//print ("Slingshot:OnMouseEnter")
		Launchpoint.SetActive(true);
	}

	void OnMouseExit(){
		//print ("Slingshot:OnMouseExit")
		Launchpoint.SetActive(false);
	}

	void OnMouseDown(){

		//if Projectile didn't enter the Goal yet
		if (Goal.goalMet != true) {
			//if less than 10 projectiles, instatiate projectile
			if (counter < 10) {
				//set game to aiming mode
				aimingMode = true;


				//Instantiate a projectile
				projectile = Instantiate (prefabProjectile [0]) as GameObject;

				//count projectiles
				counter += 1;
				//substract 100 for each fired projectile
				Goal.score -= 100;
		

				//position the projectile at the launchpoint
				projectile.transform.position = launchPos;
				//disable kinematic physics for now
				projectile.GetComponent<Rigidbody> ().isKinematic = true;
			}
		}
	}

	// Use this for initialization
	void Start () {
		//Projectil is Projectile[1] at start
		prefabProjectile [0] = prefabProjectile [1];




	}
	
	// Update is called once per frame
	void Update () {
		//check aiming mode
		if (!aimingMode)
			return;

		//get mouse position in 3D space
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);


		//calculate the delta between mouse position and launch point
		Vector3 mouseDelta = mousePos3D - launchPos;

		//constrain the delat to radius of the sphere collider
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;
		mouseDelta = Vector3.ClampMagnitude (mouseDelta, maxMagnitude);

		//set the projectile to the new position
		Vector3 projPos = launchPos + mouseDelta;
		projectile.transform.position = projPos;

		//check mouse button released
		if (Input.GetMouseButtonUp (0)) {
			aimingMode = false;
			projectile.GetComponent<Rigidbody> ().isKinematic = false;

			projectile.GetComponent<Rigidbody> ().velocity = -mouseDelta * velocityMult;
			FollowCam.S.poi = projectile;
		}
		//fire it off


	//change velocity for each different Projectile
	if (prefabProjectile [0] == prefabProjectile [4]){
		velocityMult = 15;
	}

	if (prefabProjectile [0] == prefabProjectile [2] || prefabProjectile [0] == prefabProjectile [3]){
		velocityMult = 5;
	}

	}



	//Instantiate buttons to change Projectile
	void OnGUI () {
		

			//check if ChangeButton is pressed
			if (GameController.activateChangeButton == true) {
		
				// and if second button not pressed
				if (!hasBeenPressed) {
					// Make a background box
					GUI.Box (new Rect (0, 0, 100, 50), (""));
					
					//if Button pressed change Projectile 
					if (GUI.Button (new Rect (0, 0, 100, 50), "Normal")) {
			
						prefabProjectile [0] = prefabProjectile [1];
						hasBeenPressed = false;
						GameController.activateChangeButton = false;
					}
				//if H is activated instantiate Button
				if (ActivateH.activeH == true) {
						//if button pressed change Projectile
						if (GUI.Button (new Rect (50, 0, 100, 50), "Heavy")) {

							prefabProjectile [0] = prefabProjectile [2];
							hasBeenPressed = false;
							GameController.activateChangeButton = false;
							
						}
					}
				}
			}	
		}


}
