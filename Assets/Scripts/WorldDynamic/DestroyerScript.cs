using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Collectable")
		{
			Destroy (collider.gameObject);
		}

		if(collider.gameObject.tag == "Obstacle")
		{
			Destroy(collider.gameObject);
		}

		if(collider.gameObject.tag == "Obstacle")
		{
			Destroy(collider.gameObject);
		}
	}

}
