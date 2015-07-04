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

	// Private internal fields

	private int level;
	private int levelMax;
	private int shotsTaken;

	private GameObject castle;

	private GameState state;

	private string showing = "Slingshot";


	void Awake() {
		S = this;

		// Initialize stuff (e.g. level, level Max)

		StartLevel();

	}

	void Update () {
		// Update GUI texts

		// Check level end

			// Go to next level
		
	}

	void StartLevel(){

		// If there is a castle, destroy it

		// Destroy all remaining projectiles

		// Instantiate new castle and reset shotsTaken


		// Reset Camera
		SwitchView("Both");

	
	}

	public void SwitchView(string view) {


		// Switch over all possible view "Both", "Castle", "Slingshot"

			// Set the poi of the FollowCam to according value


	}



}
