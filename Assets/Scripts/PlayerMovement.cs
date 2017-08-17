using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float jumpForce = 0f;
	public float runningForce = 0.8f;
	public float distToGround = 1;
	public float turboForce = 0;
	public float turboTime = 1;
	
	public float floorY = -3.2f;

	[HideInInspector]
	public bool grounded = false;
	[HideInInspector]
	public bool jump = false;
	[HideInInspector]
	public bool isAlive = true;
	[HideInInspector]
	public bool isTurbed = false;

	[HideInInspector]
	public static float score = 0;
	public static int money = 0;
	[HideInInspector]
	public int countCollectableItem_1 = 0;
	public int countCollectableItem_1_total = 0;
	[HideInInspector]
	public int countCollectableItem_2 = 0;
	public int countCollectableItem_2_total = 0;
	[HideInInspector]
	public int countCollectableItem_3 = 0;
	public int countCollectableItem_3_total = 0;
	[HideInInspector]
	public int countCollectableItem_4 = 0;
	public int countCollectableItem_4_total = 0;

	public int countItens_total = 0;

	public int quantNeededToBonus = 5;
	public int bonusCollectableItem_1 = 10;
	public int bonusCollectableItem_2 = 20;
	public int bonusCollectableItem_3 = 30;
	public int bonusCollectableItem_4 = 40;

	public GUIText guiTextScore;
	public GUIText guiTextMoney;
	public GUIText guiTextCollectable_1;
	public GUIText guiTextCollectable_2;
	public GUIText guiTextCollectable_3;
	public GUIText guiTextCollectable_4;


	public GameObject deathReference;
	private GameControl gameControlReference;

	private Transform groundCheck;

	private bool activeRunAnimation = true;

	public AudioClip moneyAudio;
	public AudioClip itemAudio;

	void Start () {
		groundCheck = transform.Find("GroundCheck");
		gameControlReference = FindObjectOfType(typeof(GameControl)) as GameControl;
	}



	void Update () {
		if(isAlive && !GameControl.isPaused){
			//if(gameControlReference.gameState != GameControl.GameState.Win)
			score += Time.deltaTime;
			guiTextScore.text = "Score: " + Mathf.Floor((score*100));
			guiTextMoney.text = "" + money + " z";
			guiTextCollectable_1.text = "x " + countCollectableItem_1;
			guiTextCollectable_2.text = "x " + countCollectableItem_2;
			guiTextCollectable_3.text = "x " + countCollectableItem_3;
			guiTextCollectable_4.text = "x " + countCollectableItem_4;

			transform.position += new Vector3(runningForce + turboForce, 0f, 0f);

			if(isTurbed)
			{
				if(turboForce < 2)
					turboForce += 0.001f;
				turboTime -= Time.deltaTime;
				if(turboTime <= 0){
					turboForce = 0;
					isTurbed = false;
					turboTime = 1;
				}
			}else{
				if(turboForce > 0)
					turboForce = 0;
			}

			if(Input.GetKeyDown(KeyCode.Space) && grounded)
			{
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
				GetComponent<AudioSource>().Play ();
				grounded = false;
				if(!grounded){
					switch(name){
					case "Player":
						gameObject.GetComponent<Animator>().Play("jump");
						break;
					case "Player02":
						gameObject.GetComponent<Animator>().Play("jump2");
						break;
					case "Player03":
						gameObject.GetComponent<Animator>().Play("jump3");
						break;
					case "Player04":
						gameObject.GetComponent<Animator>().Play("jump4");
						break;
					}

					activeRunAnimation = true;
				}
				//rigidbody2D.velocity = new Vector2(0f, jumpForce * Time.deltaTime);
			}
			if(grounded && activeRunAnimation)
			{

				switch(name){
				case "Player":
					gameObject.GetComponent<Animator>().Play("run");
					break;
				case "Player02":
					gameObject.GetComponent<Animator>().Play("run02");
					break;
				case "Player03":
					gameObject.GetComponent<Animator>().Play("run03");
					break;
				case "Player04":
					gameObject.GetComponent<Animator>().Play("run04");
					break;
				}

				activeRunAnimation = false;
			}

		
			if(transform.position.x < deathReference.transform.position.x)
				isAlive = false;
		}

		checkCollectables();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Collectable")
		{
			Destroy(collider.gameObject);
			if(collider.gameObject.name.Equals("Item_booster(Clone)") || collider.gameObject.name.Equals("Item_energy(Clone)"))
				isTurbed = true;

			switch(collider.name){
				case "CollectableItem_1(Clone)":
					countCollectableItem_1++;
					countCollectableItem_1_total++;
					countItens_total++;
					gameObject.audio.PlayOneShot(itemAudio);
					break;
				case "CollectableItem_2(Clone)":
					countCollectableItem_2++;
					countCollectableItem_2_total++;
					countItens_total++;
					gameObject.audio.PlayOneShot(itemAudio);
					break;
				case "CollectableItem_3(Clone)":
					countCollectableItem_3++;
					countCollectableItem_3_total++;
					countItens_total++;
					gameObject.audio.PlayOneShot(itemAudio);
					break;
				case "CollectableItem_4(Clone)":
					countCollectableItem_4++;
					countCollectableItem_4_total++;
					countItens_total++;
					gameObject.audio.PlayOneShot(itemAudio);
					break;
				case "Item_money(Clone)":
					money += 5;
					gameObject.audio.PlayOneShot(moneyAudio);
					break;

			}

		}else if(collider.gameObject.tag == "Enemy"){
			gameObject.gameObject.SetActive(false);
			isAlive = false;
			gameControlReference.gameState = GameControl.GameState.GameOver;
		}
	}

	public void checkCollectables(){
		if(countCollectableItem_1 >= quantNeededToBonus){
			money += bonusCollectableItem_1;
			countCollectableItem_1 = 0;
		}
		if(countCollectableItem_2 >= quantNeededToBonus){
			money += bonusCollectableItem_2;
			countCollectableItem_2 = 0;
		}
		if(countCollectableItem_3 >= quantNeededToBonus){
			money += bonusCollectableItem_3;
			countCollectableItem_3 = 0;
		}
		if(countCollectableItem_4 >= quantNeededToBonus){
			money += bonusCollectableItem_4;
			countCollectableItem_4 = 0;
		}
	}

	public void resetPointCollectables(){
		countCollectableItem_1 = 0;
		countCollectableItem_2 = 0;
		countCollectableItem_3 = 0;
		countCollectableItem_4 = 0;
	}
}
