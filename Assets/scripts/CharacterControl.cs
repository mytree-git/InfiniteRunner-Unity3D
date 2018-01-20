using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour {

	
	private Animator anim;

	void Start () {

		anim = this.gameObject.GetComponent<Animator> ();
	}

	public void CharacterControlUpdate() {

		//player presses 'J' to Jump
		if (Input.GetButtonDown ("Jump") == true) {

			if (anim != null) {
				anim.SetTrigger ("Jump");
				CollisionDetection cd = new CollisionDetection ();
				cd.playCoinCollect ("jumpsound");
			}
		}

		//player presses 'S' to slide
		if (Input.GetButtonDown ("Fire1") == true) {

			if (anim != null) {
				anim.SetTrigger ("Slide");
				CollisionDetection cd = new CollisionDetection ();
				cd.playCoinCollect ("slidesound");

			}
		}

		//Game restarts, when player presses 'R'
		if (Input.GetKeyDown (KeyCode.R)) {
			Time.timeScale = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	// Update is called once per frame
	void Update () {

		CharacterControlUpdate ();
	}
}
