using UnityEngine;
using System.Collections;

public class FloorBehaviour : MonoBehaviour {
	
	public GameObject[] floor;
	private int indexToModify;
	
	public Sprite Phase01_floor;
	public Sprite Phase02_floor;
	public Sprite Phase03_floor;
	public Sprite Phase04_floor;
	
	private Sprite currentFloor;
	
	private GameControl gameControlReference;
	
	void Start () {
		indexToModify = 0;
		gameControlReference = FindObjectOfType(typeof(GameControl)) as GameControl;
		checkCurrentFloor();
	}
	
	void Update () {
		if(indexToModify == 0)
		{
			if(floor[1].transform.position.x <= Camera.main.transform.position.x)
			{
				if(name == "BgControl") floor[0].GetComponent<SpriteRenderer>().sprite = currentFloor;
				floor[0].transform.position = new Vector3(transform.position.x, floor[0].transform.position.y, floor[0].transform.position.z);
				indexToModify = 1;
			}
		}
		else
		{
			if(floor[0].transform.position.x <= Camera.main.transform.position.x)
			{
				if(name == "BgControl") floor[1].GetComponent<SpriteRenderer>().sprite = currentFloor;
				floor[1].transform.position = new Vector3(transform.position.x, floor[1].transform.position.y, floor[1].transform.position.z);
				indexToModify = 0;
			}
		}
		
		
	}
	
	public void checkCurrentFloor(){
		switch(gameControlReference.gameState){
		case GameControl.GameState.Phase01:
			currentFloor = Phase01_floor;
			break;
		case GameControl.GameState.Phase02:
			currentFloor = Phase02_floor;
			break;
		case GameControl.GameState.Phase03:
			currentFloor = Phase03_floor;
			break;
		case GameControl.GameState.Phase04:
			currentFloor = Phase04_floor;
			break;
		}
		applyCurrentFloor(currentFloor);
	}

	public void applyCurrentFloor(Sprite current){
		for(int j = 0; j < 2; j++)
		{
			int childrenCount = floor[j].transform.childCount;
			for(int i = 0; i < childrenCount; i++){
				floor[j].transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = current;
			}
		}
	}
}
