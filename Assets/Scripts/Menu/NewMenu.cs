using UnityEngine;
using System.Collections;

public class NewMenu : MonoBehaviour {

	public static string currentHoverButton = "";


	public GameObject newGameObject;
	public GameObject loadObject;
	public GameObject playObject;
	public GameObject menuObject;
	public GameObject creditsObject;
	public GameObject frame;
	public GameObject tutorialbg;
	public GameObject buttonPlayGame;
	public GameObject creditosTop;
	public GameObject logoObject;
	public GameObject controlesObject;
	public GameObject infoObject;
	public GameObject creditsContent;
	public GameObject tutorialContent;


	private int indexChangerToPlay = 0;

	void Start () {
		//DontDestroyOnLoad(GameObject.Find ("Menu mid"));

	}

	void Update () {
		if(!currentHoverButton.Equals("")){
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				switch(currentHoverButton){
				case MenuUtil.buttonPlay:
					newGameObject.gameObject.SetActive(true);
					//loadObject.gameObject.SetActive(true);
					playObject.gameObject.SetActive(false);
					break;
				case MenuUtil.buttonCredits:
					creditsObject.gameObject.SetActive(false);
					menuObject.gameObject.SetActive(true);
					playObject.gameObject.SetActive(false);
					logoObject.gameObject.SetActive(false);
					creditosTop.gameObject.SetActive(true);
					newGameObject.gameObject.SetActive(false);
					loadObject.gameObject.SetActive(false);
					creditsContent.gameObject.SetActive(true);
					break;
				case MenuUtil.buttonNewGame:
					creditsObject.gameObject.SetActive(false);
					newGameObject.gameObject.SetActive(false);
					loadObject.gameObject.SetActive(false);
					buttonPlayGame.gameObject.SetActive(true);
					tutorialbg.gameObject.SetActive(true);
					controlesObject.gameObject.SetActive(true);
					break;
				case MenuUtil.buttonPlayGame:
					if(indexChangerToPlay == 0){
						controlesObject.gameObject.SetActive(false);
						tutorialContent.gameObject.SetActive(true);
						indexChangerToPlay++;
					}else{
						PlayerPrefsControl.setHighMoney(0);
						Time.timeScale = 1;
						PlayerMovement.money = 0;
						GameControl.isFirstTime = true;
						Application.LoadLevel("Main Scene");
					}
					break;
				case MenuUtil.buttonMenu:
					Application.LoadLevel("NewMenu");
					break;
				case MenuUtil.buttonFacebook:
					Application.OpenURL("https://www.facebook.com/pages/CEO-Run/454175878048462");
					break;
				case MenuUtil.buttonTwitter:
					Application.OpenURL("https://twitter.com/CEORunGame");
					break;
				case MenuUtil.buttonHelp:
					infoObject.gameObject.SetActive(true);
					menuObject.gameObject.SetActive(true);
					creditsObject.gameObject.SetActive(false);
					playObject.gameObject.SetActive(false);
					logoObject.gameObject.SetActive(false);
					newGameObject.gameObject.SetActive(false);
					break;
				case "i":
					Application.LoadLevel("Info");
					break;
				case "load-game":
					PlayerPrefsControl.loadLevel();
					Application.LoadLevel("Main Scene");
					break;
				}
				currentHoverButton = "";
			}
		}
	}
	
	void OnMouseEnter(){
		currentHoverButton = name;
	}

	void OnMouseExit(){
		currentHoverButton = "";
	}
	
}
