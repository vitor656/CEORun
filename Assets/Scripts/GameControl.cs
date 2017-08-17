using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public GameState gameState;
	public static GameState currentGameState;

	private Persistence persistenceReference;

	private PlayerMovement playerReference;

	public GameObject[] playersObject;

	public GUIText gameOverText;
	public GUIText pausedText;
	public GUIText winText;
	public GUIText yourScore;

	public GUITexture[] messageInitPhase;
	private GUITexture currentMessageInitPhase;
	public GameObject espacoIniciar;

	public GameObject fimDeJogoElements;

	public GameObject pauseElements;

	public GameObject parabensElements;
	public GameObject guiTextsParabens;

	public GUIText[] gameOverOptions;
	public GUIText[] pauseOptions;
	public GUIText[] winOptions;
	private int selectedOption;
	private int pauseSelectedOption = 0;
	private int winSelectedOption = 0;

	public GameObject[] songs;

	
	public GUIText endGameItensCont;
	public GUIText endGameEsquadroCont;
	public GUIText endGameEngrenagemCont;
	public GUIText endGameCalculadoraCont;
	public GUIText endGamePlantaCont;
	public GUIText endGameMoedasCont;


	public static bool isPaused = false;
	public static bool isFirstTime = true;

	private bool doOneTime = true;


	public int[] moneyGoal;
	public Goals[] goals;

	private PlatformSpawner platformSpawnerReference;
	private ObstaclesSpawner obstaclesSpawnerReference;

	public float timeToSpawn = 1;
	private float timer;
		
	public static bool showMessageInit = true;
	private int currentLevel = 0;

	public static bool mouseClicked = false;

	public enum GameState{
		Phase01 = 0,
		Phase02 = 1,
		Phase03 = 2,
		Phase04 = 3,
		End = 4,
		GameOver = 5
	}

	[System.Serializable]
	public class Goals{
		public int goalItem_1;
		public int goalItem_2;
		public int goalItem_3;
		public int goalItem_4;
	}

	void Start () {
		if(isFirstTime){
			currentGameState = GameState.Phase01;

			isFirstTime = false;

		}

//		if(PlayerPrefsControl.canLoadLevel != -1){
//
//			switch(PlayerPrefsControl.canLoadLevel){
//			case 0:
//				currentGameState = GameState.Phase01;
//				break;
//			case 1:
//				currentGameState = GameState.Phase02;
//				break;
//			case 2:
//				currentGameState = GameState.Phase03;
//				break;
//			case 3:
//				currentGameState = GameState.Phase04;
//				break;
//			}
//		}


		persistenceReference = FindObjectOfType<Persistence>();
		//PlayerMovement.money = PlayerPrefsControl.getHighMoney();
		//print (PlayerPrefsControl.getHighMoney());
		gameState = currentGameState;
		if(gameState == GameState.End)
			Application.LoadLevel("NewMenu");
		spawnPlayer();
		playerReference = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
		platformSpawnerReference = FindObjectOfType (typeof(PlatformSpawner)) as PlatformSpawner;
		obstaclesSpawnerReference = FindObjectOfType (typeof(ObstaclesSpawner)) as ObstaclesSpawner;
		timer = timeToSpawn;


		currentMessageInitPhase.gameObject.SetActive(true);




	}

	void Update () {

		if(showMessageInit){
			currentMessageInitPhase.gameObject.SetActive(true);
			espacoIniciar.gameObject.SetActive(true);
			if(Input.GetKeyDown(KeyCode.Space)){
				Application.LoadLevel("Main Scene");
				showMessageInit = false;
			}

		}else{
			currentMessageInitPhase.gameObject.SetActive(false);
			espacoIniciar.gameObject.SetActive(false);
		}


		if(playerReference.isAlive){

			if(!isPaused && mouseClicked)
			{
				mouseClicked = false;
				isPaused = !isPaused;
				if(isPaused)
				{
					pauseElements.gameObject.SetActive(true);


					Time.timeScale = 0;

				}else{
					pauseElements.gameObject.SetActive(false);


					Time.timeScale = 1;
				}
			}
			countTimerToSpawnBlocks();
			if(isPaused)
			{
		
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
				{
			

					isPaused = false;
					Time.timeScale = 1;
					pauseElements.gameObject.SetActive(false);
				}
			}




			gameOverText.guiText.enabled = false;
			verifyGoals ();
		}else{
			if(doOneTime)
			{
				gameState = GameState.GameOver;
				bool s = PlayerMovement.money > moneyGoal[currentLevel]? true : false;
				if(s){
					parabensElements.gameObject.SetActive(true);
					guiTextsParabens.gameObject.SetActive(true);
					//PlayerPrefsControl.canLoadLevel++;
				}else{
					fimDeJogoElements.gameObject.SetActive(true);
					guiTextsParabens.gameObject.SetActive(true);
				}


				endGameItensCont.guiText.text = "" + playerReference.countItens_total;
				endGameEsquadroCont.guiText.text = "" + playerReference.countCollectableItem_1_total;
				endGameEngrenagemCont.guiText.text = "" + playerReference.countCollectableItem_2_total;
				endGameCalculadoraCont.guiText.text = "" + playerReference.countCollectableItem_3_total;
				endGamePlantaCont.guiText.text = "" + playerReference.countCollectableItem_4_total;
				endGameMoedasCont.guiText.text = "" + PlayerMovement.money;

//				gameOverText.guiText.enabled = true;
//				for(int i = 0; i < gameOverOptions.Length; i++)
//				{
//					gameOverOptions[i].guiText.enabled = true;
//				}
				doOneTime = false;

//				if(PlayerPrefsControl.getHighMoney() < PlayerMovement.money){
//					PlayerPrefsControl.updateHighMoney(PlayerMovement.money);
//				}
			}

		}


	}

	public void verifyGoals(){



		switch (gameState) {
		case GameState.Phase01:
			currentLevel = 0;
			break;
		case GameState.Phase02:
			currentLevel = 1;
			break;
		case GameState.Phase03:
			currentLevel = 2;
			break;
		case GameState.Phase04:
			currentLevel = 3;
			break;
		}

	}

	//Contador de tempo unico para spawnar obstaculos e plataformas
	//em intervalos de tempo diferentes, a fim de evitar as estruturas
	//de nascerem com um valor Y e X muito proximos.
	public void countTimerToSpawnBlocks(){
		timer -= Time.deltaTime;

		if (timer <= 0) {
			int num = Random.Range(0, 2);
			if(num == 0){
				platformSpawnerReference.spawn();
			}else{
				obstaclesSpawnerReference.spawn();
			}
			timer = timeToSpawn;
		}

	}

	public void spawnPlayer(){
		switch (gameState) {
		case GameState.Phase01:
			playersObject[0].SetActive(true);
			currentMessageInitPhase = messageInitPhase[0];
			songs[0].GetComponent<AudioSource>().Play();
			break;
		case GameState.Phase02:
			playersObject[1].SetActive(true);
			currentMessageInitPhase = messageInitPhase[1];
			songs[1].GetComponent<AudioSource>().Play();
			break;
		case GameState.Phase03:
			playersObject[2].SetActive(true);
			currentMessageInitPhase = messageInitPhase[2];
			songs[2].GetComponent<AudioSource>().Play();
			break;
		case GameState.Phase04:
			playersObject[3].SetActive(true);
			currentMessageInitPhase = messageInitPhase[3];
			songs[3].GetComponent<AudioSource>().Play();
			break;
		}
	}

	
}
