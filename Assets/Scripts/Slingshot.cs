using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public GameObject Launchpoint;

	void Awake(){
		Transform LaunchpointTrans = transform.Find ("Launchpoint");
		Launchpoint = LaunchpointTrans.gameObject;
		Launchpoint.SetActive(false);
	}

	void OnMouseEnter(){
		Launchpoint.SetActive(true);
	}

	void OnMouseExit(){
		Launchpoint.SetActive(false);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
