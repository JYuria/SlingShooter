using UnityEngine;
using System.Collections;
using UnityEngine.UI;

enum GameState {
	idle,
	playing,
	levelEnd
}

public class GameController : MonoBehaviour {
	public static GameController S;

	// Public Inspector Fields
	public GameObject[] castles;

	public Text gtLevel;
	public Text gtScore;

	public Vector3 castlePos;

	public Vector3 newDestination;

	// Private internal fields

	private int level;
	private int levelMax;
	private int shotsTaken;

	private GameObject castle;

	private GameState state;

	private string showing = "Slingshot";



	int cameratest;

	void Start (){
	
	
	
	
	}

	void Awake() {
		S = this;

		// Initialize stuff (e.g. level, level Max)

		StartLevel();

	}

	void Update () {
		// Update GUI texts

		// Check level end

		// Go to next level






		
		
//		GameObject Castle = GameObject.Find("Goal");
		//GameObject Slingshot = GameObject.Find("Slingshot");
	
			
		//private int cameratest;
//		//check if poi exist and set destination
//		if (FollowCam.S.poi != null) {
//			newDestination = FollowCam.S.poi.transform.position;
//
//			//check if poi moved
//			if (FollowCam.S.poi.transform.position != Vector3.zero) {
//
//				
//				}  if (cameratest == 2){
//					newDestination = Castle.transform.position;
//				}  if (cameratest == 3){
//				newDestination = (Slingshot.transform.position+Castle.transform.position)/2;
//				newDestination.y = newDestination.x/2;
//				}
//			}
//		}


	//check if poi is empty 
		//if not, follow poi
		if (FollowCam.S.poi != null) {
			newDestination = FollowCam.S.poi.transform.position;


			if (FollowCam.S.poi.transform.position != Vector3.zero) {
				//if poi moves, change color 
				this.changeButtons(Color.grey);

				if (cameratest == 1){

					newDestination = Vector3.zero;
				} else {
					newDestination = FollowCam.S.poi.transform.position;}

		}

		
		}

	//check if destination is zero -> change buttons (back) to white 	  
		if (newDestination == Vector3.zero){
			cameratest = 0;
			FollowCam.S.poi = null;
		this.changeButtons(Color.green);
		}

		print (cameratest);

}

	//function to change color from buttons 
	public void changeButtons (Color col){
	
			//find Buttons with tag
			GameObject[] Buttons = GameObject.FindGameObjectsWithTag ("Buttons");
			
			//change color from each button
			foreach (GameObject button in Buttons) {
				Image buttonImg = button.GetComponent<Image> ();
				Color buttonColor = buttonImg.color;
				buttonColor = col;
				buttonImg.color = buttonColor;
				}
	
		}





	void StartLevel(){

		// If there is a castle, destroy it

		// Destroy all remaining projectiles

		// Instantiate new castle and reset shotsTaken


		// Reset Camera
		//SwitchView("Both");

	
	}

	public void SwitchView(string view) {




		// Switch over all possible view "Both", "Castle", "Slingshot"

			// Set the poi of the FollowCam to according value

			////find FollowCam and poi

			//if "Slingshot" pressed switch to Slingshot -> poi = null

	

		GameObject Castle = GameObject.Find("Goal");
		GameObject Slingshot = GameObject.Find("Slingshot");
	




		if (view == "SlingShot") {

			//newDestination = FollowCam.S.poi.transform.position;
			newDestination = Vector3.zero;

			cameratest = 1;
		}
		
		
		
		if (view == "Castle") {
			
			newDestination = Castle.transform.position;

			//cameratest = 2;
		} 
		
		if (view == "Both") {
			
			
			newDestination = (Slingshot.transform.position+Castle.transform.position)/2;
			newDestination.y = newDestination.x/2;

			//cameratest = 3;
		}



	}



}
