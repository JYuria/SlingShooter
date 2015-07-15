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

	private int setCamera;

	public static bool activateChangeButton = true;
	

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


		//Find "Shots" Text and add countdown
		Text countShots = GameObject.Find ("Shots").GetComponent<Text> ();
		countShots.text = "Shots left " + (10 - Slingshot.counter);


	

	//check if poi is empty 
		//if not, follow poi
		if (FollowCam.S.poi != null) {
			newDestination = FollowCam.S.poi.transform.position;

			if (FollowCam.S.poi.transform.position != Vector3.zero) {
				//if poi moves, make buttons clear 
				this.changeButtons(Color.clear);
				//
				activateChangeButton = false;

			 
				//if Button exists
				if (GameObject.Find ("Change") != null){
					Button change = GameObject.Find ("Change").GetComponent<Button>();

					//and if button is interactable 
				if (change.interactable == true){
						//make Button not interactable
					change.interactable = false;
					} 
				}

				//if Button pressed (-> setCamera = 1) set destination to zero; else still follow poi
				if (setCamera == 1){
					newDestination = Vector3.zero;
					} else {
					newDestination = FollowCam.S.poi.transform.position;}
				}
		}


	//check if camero is to zero  	  
		if (newDestination == Vector3.zero){
			//reset setCamera
			setCamera = 0;
			FollowCam.S.poi = null;
	//change buttons (back) to white
		this.changeButtons(Color.white);
	//aktivate Change Button
			GameObject.Find ("Change").GetComponent<Button>().interactable = true;
		}



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

	
		//define Castle and Slingshot
		GameObject Castle = GameObject.Find("Goal");
		GameObject Slingshot = GameObject.Find("Slingshot");
	
		//if Projectile didn't enter the Goal yet
		if (Goal.goalMet != true) {


			//check if button pressed
			if (view == "SlingShot") {
				//set camera to zero
				newDestination = Vector3.zero;

				//set setCamera to 1 to check if the button is pressed
				setCamera = 1;
			}
		
			if (view == "Castle") {
				//set camera position to Goal in the Castle
				newDestination = Castle.transform.position;
			} 
		
			if (view == "Both") {
				//find the center between slingshot and Castle and zoom out
				newDestination = (Slingshot.transform.position + Castle.transform.position) / 2;
				newDestination.y = newDestination.x / 2;
			}

			if (view == "Change") {
				// Make the second button.
				activateChangeButton = true;

			}
		}

	}






}
