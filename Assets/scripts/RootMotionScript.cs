using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class RootMotionScript : MonoBehaviour {
	
	//to move player on the ground with a specific speed
	void OnAnimatorMove()
	{
		Animator animator = GetComponent<Animator>(); 

		if (animator)
		{
			Vector3 newPosition = transform.position;
			newPosition.z += animator.GetFloat("speed") * Time.deltaTime; 
			transform.position = newPosition;
		}
	}
}
