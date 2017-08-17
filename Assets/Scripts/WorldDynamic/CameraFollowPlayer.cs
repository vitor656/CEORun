using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	private float startingY = 1.150561f;
	public Transform player;

	public static Vector3 stageDimensions; 

	public GameControl gameControlReference;


	void Awake () {
		startingY = transform.position.y;
		gameControlReference = FindObjectOfType(typeof(GameControl)) as GameControl;

	}

	void Update () {
		if(!GameControl.isPaused/* && (gameControlReference.gameState != GameControl.GameState.Win)*/)
		{
			stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
			transform.position += new Vector3(0.15f, 0f, 0f);

			//print(stageDimensions.x);
		}
	}
}
