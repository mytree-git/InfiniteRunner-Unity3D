using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score; // to store score value
	public Text time; //to store time elapsed
	public Text playAgain; //to display game over text
	public Text restartGame;

	private float timer;
	private float minutes;
	private float seconds;

	private int scoreCounter; //to increment score

	void Start () {
		
		scoreCounter = 0;
	}


	//collects coins and increment score
	public void IncrementScore(int newScore) {
		
		scoreCounter += newScore;
		if (score != null) {
			score.text = " YOUR SCORE: " + scoreCounter.ToString ();
		}
			
	}

	public void ScoreManagerUpdate() {
	
		//show time in seconds
		timer += Time.deltaTime;
		seconds =(timer % 60);
		time.text = "GAME TIME: " + seconds.ToString(); 
	}

	// Update is called once per frame
	void Update(){

		ScoreManagerUpdate (); 
	}
}
