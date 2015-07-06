using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	//inspector fields
	public GameObject prefabProjectile;

	public float velocityMult = 10.0f;


	//internal fields
	private GameObject Launchpoint;
	private bool aimingMode;

	private Vector3 launchPos;
	private GameObject projectile;








	void Awake(){
		Transform LaunchpointTrans = transform.Find ("Launchpoint");
		Launchpoint = LaunchpointTrans.gameObject;
		Launchpoint.SetActive(false);
		launchPos = Launchpoint.transform.position;
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
		//set game to aiming mode
		aimingMode = true;

		//Instantiate a projectile
		projectile = Instantiate (prefabProjectile) as GameObject;

		//position the projectile at the launchpoint
		projectile.transform.position = launchPos;
		//disable kinematic physics for now
		projectile.GetComponent<Rigidbody>().isKinematic = true;

	}

	// Use this for initialization
	void Start () {

	
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
	}


}
