using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {


	public GameObject[] phase01Platforms;	
	public GameObject[] phase02Platforms;
	public GameObject[]	phase03Platforms;
	public GameObject[]	phase04Platforms;

	public GameObject[] currentPlatforms; 
	public float MAX = 4;
	public float MIN = 2;

	private bool up = true;

	public int problabilitySpawn = 300;
	private float timeToSpawn = 1;
	private float time;

	private GameControl gameControlReference;

	void Start () {
		gameControlReference = FindObjectOfType(typeof(GameControl)) as GameControl;
		time = timeToSpawn;
		checkCurrentPlatforms();
	}

	void Update () {
		if(!GameControl.isPaused)
		{
			time -= Time.deltaTime;
			if(time <= 0)
			{


				if(up)
				{
					if(transform.position.y <= MAX)
						transform.position += new Vector3(0f, 0.03f, 0f);
					else
						up = false;
				}
				else if(!up)
				{
					if(transform.position.y >= MIN)
						transform.position -= new Vector3(0f, 0.03f, 0f);
					else
						up = true;
				}
				//spawn();
			}
		}
	}

	public void checkCurrentPlatforms(){
		switch(gameControlReference.gameState){
		case GameControl.GameState.Phase01:
			currentPlatforms = phase01Platforms;
			break;
		case GameControl.GameState.Phase02:
			currentPlatforms = phase02Platforms;
			break;
		case GameControl.GameState.Phase03:
			currentPlatforms = phase03Platforms;
			break;
		case GameControl.GameState.Phase04:
			currentPlatforms = phase04Platforms;
			break;
		}
	}

	public void spawn(){
		if(currentPlatforms.Length > 0){
			int indexGenerator = Random.Range(0, problabilitySpawn);
			if(indexGenerator == 0)
			{
				int platformIndex = Random.Range(0, currentPlatforms.Length);
				Instantiate(currentPlatforms[platformIndex], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
				time = timeToSpawn;
			}
		}
	}
}
