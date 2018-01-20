using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	private int scoreCounter; 

	// Use this for initialization
	void Start () {
		
	}

	//play sound collecting coins
	public void playCoinCollect(string gameObjectName){
		GameObject gm = GameObject.Find(gameObjectName);
		if (gm != null)
		{
			AudioSource asource = gm.GetComponent<AudioSource> ();
			if (asource == null) {
				asource = gm.AddComponent<AudioSource> ();
			}
			
			asource.Play ();
		}
	}


	//stop sound after player is dead
	void stopAudioOnEvent(string gameObjectName){
		GameObject gm = GameObject.Find(gameObjectName);
		if (gm != null) {
		    
			AudioSource asource = gm.GetComponent<AudioSource> ();
			if (asource == null) {
				
				asource = gm.AddComponent<AudioSource> ();
			}

			asource.Stop();
		}
	}


	//player collides into the wall and game stops
	public void OnCollisionEnter(Collision collision) {
		
		GameObject gm = GameObject.Find("character");
		ScoreManager smgr = gm.GetComponent<ScoreManager> ();


		if (collision.gameObject.tag == "obstacle") {

			playCoinCollect ("character");
			stopAudioOnEvent ("floor");
			smgr.playAgain.text = "PLAY AGAIN :(";
			smgr.restartGame.text = "PRESS 'R' to RESTART :)";

			Time.timeScale = 0; //ends the game
	    }

		//player collides with red coins
		if (collision.gameObject.tag == "red") {

			playCoinCollect ("RedCoins");
			smgr.IncrementScore (5); //increases score by 5
		    Destroy (collision.gameObject); //destroys when collision is detected by player

		}

		//player collides with blue coins
		if (collision.gameObject.tag == "blue") {
				
			playCoinCollect ("BlueCoins");
			smgr.IncrementScore (3); //increases score by 3
		    Destroy (collision.gameObject); //destroys when collision is detected by player 

		}
	}

}
