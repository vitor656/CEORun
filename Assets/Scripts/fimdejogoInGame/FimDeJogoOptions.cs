using UnityEngine;
using System.Collections;

public class FimDeJogoOptions : MonoBehaviour {

	private string currentOption = "";
	private GameControl gameControlReference;
	private PlayerPrefsControl playerPrefsControlReference;
	public GameObject feedBackObject;

	void Start () {
		gameControlReference = FindObjectOfType<GameControl>();
		playerPrefsControlReference = FindObjectOfType<PlayerPrefsControl>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			switch(currentOption){
			case "salvarjogo":
				PlayerPrefsControl.updateHighMoney(PlayerMovement.money);
				feedBackObject.guiText.text = "Saved";
				break;
			case "recomecarjogo":
				Application.LoadLevel("Main Scene");
				feedBackObject.guiText.text = "";
				break;
			case "proximolevel":
				GameControl.currentGameState++;
				if(GameControl.currentGameState == GameControl.GameState.GameOver)
					Application.LoadLevel("NewMenu");
				PlayerPrefsControl.loadLevel();
				Application.LoadLevel("Main Scene");
				GameControl.showMessageInit = true;
				feedBackObject.guiText.text = "";
				
				break;
			}

		}
	}

	void OnMouseEnter(){
		currentOption = name;
		print (currentOption);
	}

	void OnMouseExit(){
		currentOption = "";
	}
}
