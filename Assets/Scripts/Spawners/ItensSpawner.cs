using UnityEngine;
using System.Collections;

public class ItensSpawner : MonoBehaviour {

	public GameObject[] itens; 
	private float MAX = 3.8f;
	private float MIN = -2.9f;

	private bool up = true;

	private GameObject playerObject;

	private bool canSpawn = false;
	public float timeToSpawn = 1;
	private float timer;

	void Start(){
		playerObject = GameObject.FindGameObjectWithTag("Player");
		timer = timeToSpawn;
	}

	void Update () {
		MIN = playerObject.transform.position.y;
		MAX = MIN + 2.5f;

		if(!GameControl.isPaused)
		{
			if(up)
			{
				if(transform.position.y <= MAX)
					transform.position += new Vector3(0f, 0.01f, 0f);
				else
					up = false;
			}
			else if(!up)
			{
				if(transform.position.y >= MIN)
					transform.position -= new Vector3(0f, 0.01f, 0f);
				else
					up = true;
			}

			timer -= Time.deltaTime;
			if(timer <= 0){
				int indexGenerator = Random.Range(0, 100);
				if(indexGenerator == 0)
				{
					int itemIndex = Random.Range(0, itens.Length);
					Instantiate(itens[itemIndex], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
					timer = timeToSpawn;
				}
			}
		}
	}
}
