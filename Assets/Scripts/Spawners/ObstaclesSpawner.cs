using UnityEngine;
using System.Collections;

public class ObstaclesSpawner : MonoBehaviour {

	public GameObject[] phase01Obstacles;	
	public GameObject[] phase02Obstacles;
	public GameObject[]	phase03Obstacles;
	public GameObject[]	phase04Obstacles;

	public GameObject[] currentObstacles;

	public float timeToSpawn = 1;
	public int probabilityToSpawn = 1;

	private float time;

	private GameControl gameControlReference;

	void Start(){
		gameControlReference = FindObjectOfType(typeof(GameControl)) as GameControl;
		checkCurrentObstacles();
	}

	void Update () {
		if(!GameControl.isPaused)
		{
			time -= Time.deltaTime;
			if(time <= 0)
			{
				//spawn();
			}
		}
	}

	public void checkCurrentObstacles(){
		switch(gameControlReference.gameState){
		case GameControl.GameState.Phase01:
			currentObstacles = phase01Obstacles;
			break;
		case GameControl.GameState.Phase02:
			currentObstacles = phase02Obstacles;
			break;
		case GameControl.GameState.Phase03:
			currentObstacles = phase03Obstacles;
			break;
		case GameControl.GameState.Phase04:
			currentObstacles = phase04Obstacles;
			break;
		}
	}

	public void spawn(){
		if(currentObstacles.Length > 0){
			int num = Random.Range(0, probabilityToSpawn);
			if(num == 0){
				int obstacleIndex = Random.Range(0, currentObstacles.Length);
				GameObject newObject = Instantiate(currentObstacles[obstacleIndex]) as GameObject;
				newObject.transform.position = new Vector3(transform.position.x, newObject.transform.position.y, 0);
				
				time = timeToSpawn;
			}
		}
	}

}
