using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

	public static bool activateChangeButton = true;


	public GameObject Panel;


	// Private internal fields

	private int level;
	private int levelMax;
	private int shotsTaken;

	private GameObject castle;

	private GameState state;

	private string showing = "Slingshot";

	private int setCamera;

	private int i; 

	int newHighScore;









	void Awake() {
		S = this;

		// Initialize stuff (e.g. level, level Max)
	}

	void Start (){
	
		i = Application.loadedLevel;

	




	}
	

	void Update () {


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




	//Highscore for each level 
//
//		string iFloat = i.ToString();
//
//		string HighScore = "HighScore "+ iFloat;
//
//		if (Goal.goalMet == true){
//
//			for (int n = 1; n < 4; n++){
//
//			if (n == i){
////					print (HighScore);
//					if (Goal.score > PlayerPrefs.GetInt(HighScore)) {
//						PlayerPrefs.SetInt(HighScore,Goal.score);
//
//
//				}
//
//			}
//
//			}
//		}


		
		//Find "Shots" Text and add countdown
		Text countShots = GameObject.Find("Shots").GetComponent<Text> ();
		countShots.text = "Pugs left " + (10 - Slingshot.counter);
		


				




		//if goal met check which level and chcck if more than score
		if (Goal.goalMet == true) {

			if (i == 1) {
				if (Goal.score > PlayerPrefs.GetInt ("High Score 1")) {
					PlayerPrefs.SetInt ("High Score 1", Goal.score);
					newHighScore = PlayerPrefs.GetInt ("High Score 1");
				}
			}

			if (i == 2) {
				if (Goal.score > PlayerPrefs.GetInt ("High Score 2")) {
					PlayerPrefs.SetInt ("High Score 2", Goal.score);
					newHighScore = PlayerPrefs.GetInt ("High Score 2");
				}
			}

			if (i == 3) {
				if (Goal.score > PlayerPrefs.GetInt ("High Score 3")) {
					PlayerPrefs.SetInt ("High Score 3", Goal.score);
					newHighScore = PlayerPrefs.GetInt ("High Score 3");
				}
			}
		}

//		print (HighScoreLevel);
//		print (PlayerPrefs.GetInt ("High Score 1"));
//		print (PlayerPrefs.GetInt ("High Score 2"));
//		print (PlayerPrefs.GetInt ("High Score 3"));

		//RESET PLAYERPREFS
//		PlayerPrefs.DeleteAll();
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




	public void SwitchView(string view) {



		//if Projectile didn't enter the Goal yet and if Shots are left
		if (Goal.goalMet != true && Slingshot.counter != 10) {


			//check if button pressed
			if (view == "SlingShot") {
				//set camera to zero
				newDestination = Vector3.zero;

				//set setCamera to 1 to check if the button is pressed
				setCamera = 1;
			}
		
			if (view == "Castle") {
				//set camera position to Goal in the Castle
				newDestination = GameObject.Find ("Goal").transform.position;
			} 
		
			if (view == "Both") {
				//find the center between slingshot and Castle and zoom out
				newDestination = (GameObject.Find ("Slingshot").transform.position + GameObject.Find ("Goal").transform.position) / 2;
				newDestination.y = newDestination.x / 2;
			}

			if (view == "Change") {
				// Make the second button.
				activateChangeButton = true;

			}

			//Option

			if (view == "Menu") {
				Application.LoadLevel (0);
				Goal.goalMet = false;
				Slingshot.counter = 0;
				Goal.score = 1000;

			}

			if (view == "Again") {
				Application.LoadLevel (i);
				Goal.goalMet = false;
				Slingshot.counter = 0;
				Goal.score = 1000;
				
			}

				
			}


		}



	//hide Option Panel
	public void HideOptions(){
	
		Panel.SetActive (false);
	
	}


	//show Option Panel
	public void ShowOptions(){
		
		Panel.SetActive(true);



		//show highscroe for each level !better: for-loop :( 
		Text highScoreText = GameObject.Find ("Highscore").GetComponent<Text> ();
		if (i == 1) {
			highScoreText.text = "Highscore: " + (PlayerPrefs.GetInt ("High Score 1"));
		}
		if (i == 2) {
			highScoreText.text = "Highscore: " + (PlayerPrefs.GetInt ("High Score 2"));
		}
		if (i == 3) {
			highScoreText.text = "Highscore: " + (PlayerPrefs.GetInt ("High Score 3"));
		}
		
		//show score
		Text ScoreText = GameObject.Find ("Score").GetComponent<Text> ();
		ScoreText.text = "Score: " + (Goal.score);


	


//		if (Slingshot.counter == 10) {
//			
//			Goal.score = 0;
//
//			PanelGO.SetActive(true);
//		}


	}









	//Text if no Projectiles are left
	void OnGUI () {

		//if won

		if (Goal.goalMet == true) {
			
					
					
					GUI.Box (new Rect (Screen.width / 2 - (Screen.width / 4), Screen.height / 2 - (Screen.width / 6), Screen.width / 2, Screen.width / 3), ("You win!"));
					
					if (GUI.Button (new Rect (Screen.width / 2 - (Screen.width / 4), Screen.height / 2 + (Screen.width / 14), Screen.width / 6, Screen.height / 6), "Menu")) {
						Application.LoadLevel (0);
						Goal.goalMet = false;
						Slingshot.counter = 0;
						Goal.score = 1000;
					}
					if (GUI.Button (new Rect (Screen.width / 2 - (Screen.width / 4) + Screen.width / 6, Screen.height / 2 + (Screen.width / 14), Screen.width / 6, Screen.height / 6), "Again")) {
						Application.LoadLevel (i);
						Goal.goalMet = false;
						Slingshot.counter = 0;
						Goal.score = 1000;
					
			
					}
					if (GUI.Button (new Rect (Screen.width/2-(Screen.width/4)+(Screen.width/6*2), Screen.height/2+(Screen.width/14), Screen.width/6, Screen.height/6), "Next")) {
						Application.LoadLevel(i+1);
						Goal.goalMet = false;
						Slingshot.counter = 0;
						Goal.score = 1000;
						

			}
				}
				
			



		//if lost

		if (Slingshot.counter == 10) {

			Goal.score = 0;

			if (FollowCam.S.poi != null) {
				if (FollowCam.S.poi.GetComponent<Rigidbody> ().IsSleeping ()) {
			

					GUI.Box (new Rect (Screen.width / 2 - (Screen.width / 4), Screen.height / 2 - (Screen.width / 6), Screen.width / 2, Screen.width / 3), ("Game over :("));
		
					if (GUI.Button (new Rect (Screen.width / 2 - (Screen.width / 4), Screen.height / 2 + (Screen.width / 14), Screen.width / 6, Screen.height / 6), "Menu")) {
						Application.LoadLevel (0);
						Slingshot.counter = 1000;
					}
					if (GUI.Button (new Rect (Screen.width / 2 - (Screen.width / 4) + Screen.width / 6, Screen.height / 2 + (Screen.width / 14), Screen.width / 6, Screen.height / 6), "Again")) {
						Application.LoadLevel (i);
						Goal.goalMet = false;
						Slingshot.counter = 1000;
					}
		
				}

			}
		}
	}






}
