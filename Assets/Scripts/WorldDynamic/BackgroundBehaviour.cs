using UnityEngine;
using System.Collections;

public class BackgroundBehaviour : MonoBehaviour {

	public GameObject[] bg;
	private int indexToModify;

	public Sprite Phase01_bg;
	public Sprite Phase02_bg;
	public Sprite Phase03_bg;
	public Sprite Phase04_bg;

	private Sprite currentBg;

	private GameControl gameControlReference;

	void Start () {
		indexToModify = 0;
		gameControlReference = FindObjectOfType(typeof(GameControl)) as GameControl;
		checkCurrentBG();
	}

	void Update () {
		if(indexToModify == 0)
		{
			if(bg[1].transform.position.x <= Camera.main.transform.position.x)
			{
				if(name == "BgControl") bg[0].GetComponent<SpriteRenderer>().sprite = currentBg;
				bg[0].transform.position = new Vector3(transform.position.x, bg[0].transform.position.y, bg[0].transform.position.z);
				indexToModify = 1;
			}
		}
		else
		{
			if(bg[0].transform.position.x <= Camera.main.transform.position.x)
			{
				if(name == "BgControl") bg[1].GetComponent<SpriteRenderer>().sprite = currentBg;
				bg[1].transform.position = new Vector3(transform.position.x, bg[1].transform.position.y, bg[1].transform.position.z);
				indexToModify = 0;
			}
		}


	}

	public void checkCurrentBG(){
		switch(gameControlReference.gameState){
		case GameControl.GameState.Phase01:
			currentBg = Phase01_bg;
			break;
		case GameControl.GameState.Phase02:
			currentBg = Phase02_bg;
			break;
		case GameControl.GameState.Phase03:
			currentBg = Phase03_bg;
			break;
		case GameControl.GameState.Phase04:
			currentBg = Phase04_bg;
			break;
		}
		bg[0].GetComponent<SpriteRenderer>().sprite = currentBg;
		bg[1].GetComponent<SpriteRenderer>().sprite = currentBg;
	}
}
