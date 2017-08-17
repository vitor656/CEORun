using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	public PlayerMovement playerReference;

	void Start(){
		playerReference = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "ground" || other.gameObject.tag == "Obstacle"){
			playerReference.grounded = true;
		}
	}
	
}
