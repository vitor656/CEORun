using UnityEngine;
using System.Collections;

public class FloorSpawner : MonoBehaviour {

	public float time = 0.5f;

	public GameObject prefab_floor;
	public GameObject prefab_floorTeste;

	void Start () {
	
	}

	void Update () {
		time -= Time.deltaTime;

		if(time <= 0)
		{
			Instantiate(prefab_floor, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			time = 0.5f;
		}


	}
}
