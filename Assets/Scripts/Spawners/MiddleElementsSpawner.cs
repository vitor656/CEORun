using UnityEngine;
using System.Collections;

public class MiddleElementsSpawner : MonoBehaviour {

	public GameObject[] phase01Elements;
	public GameObject[] phase02Elements;
	public GameObject[] phase03Elements;
	public GameObject[] phase04Elements;
	
	public GameObject[] currentElements;
	public float timeToSpawn = 1;
	
	private float time;

	private GameControl gameControlReference;

	void Start(){
		gameControlReference = FindObjectOfType(typeof(GameControl)) as GameControl;
		time = timeToSpawn;
		checkCurrentElements();
	}

	void Update () {
		time -= Time.deltaTime;
		if(time <= 0)
		{
			if(currentElements.Length > 0){
				int num = Random.Range(0, 50);
				if(num == 0){
					int elemIndex = Random.Range(0, currentElements.Length);
					GameObject newObject = Instantiate(currentElements[elemIndex]) as GameObject;
					newObject.transform.position = new Vector3(transform.position.x, newObject.transform.position.y, newObject.transform.position.z);
					
					time = timeToSpawn;
				}
			}
		}
	}

	public void checkCurrentElements(){
		switch(gameControlReference.gameState){
		case GameControl.GameState.Phase01:
			currentElements = phase01Elements;
			break;
		case GameControl.GameState.Phase02:
			currentElements = phase02Elements;
			break;
		case GameControl.GameState.Phase03:
			currentElements = phase03Elements;
			break;
		case GameControl.GameState.Phase04:
			currentElements = phase04Elements;
			break;
		}
	}
}
