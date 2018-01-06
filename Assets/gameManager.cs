using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	private static int rightScore;
	private static int leftScore;
	public GUISkin layout;
	public GameObject rightRacket, leftRacket, Ball;
	private moveRacket RR, LR;
	private ballMovement BM;

	void Start() {

		rightScore = 0;
		leftScore = 0;
		LR = leftRacket.GetComponent <moveRacket>();
		RR = rightRacket.GetComponent<moveRacket>();
		BM = Ball.GetComponent<ballMovement> ();


	}

	public void AddOneToScore(string side){

		if (side == "rightWall") {
			leftScore += 1;
		}
		if (side == "leftWall") {
			rightScore += 1;
		}
	}

	public void resetGame(){
		rightScore = 0;
		leftScore = 0;
	}

	void OnGUI(){

		GUI.skin = layout;
		GUI.Label(new Rect(Screen.width / 2 - 300, 50, 500, 500), "" + leftScore);
		GUI.Label(new Rect(Screen.width / 2 + 250, 50, 500, 500), "" + rightScore);

		if (GUI.Button (new Rect (Screen.width / 2 - 200, 50, 400, 200), "Restart")) {
			resetGame ();
			RR.resetRackets ();
			LR.resetRackets ();
			BM.resetBall ();
			BM.Invoke ("initialDirection", 3);

		}

		if (leftScore == 7) {
			GUI.Label (new Rect (Screen.width / 2 - 500, Screen.height / 2, 1000, 2000), "Left Player Wins!");
			GUI.Label (new Rect (Screen.width / 2 - 750, Screen.height / 2 + 100, 2000, 2000), "Press 'Restart' to Play Again");
			BM.resetBall ();
		}

		if (rightScore == 7) {
			GUI.Label (new Rect (Screen.width / 2 - 500, Screen.height / 2, 1000, 2000), "Right Player Wins!");
			GUI.Label (new Rect (Screen.width / 2 - 750, Screen.height / 2 + 100, 2000, 2000), "Press 'Restart' to Play Again!");
			BM.resetBall ();
		}
	}
		
}