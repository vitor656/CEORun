using UnityEngine;
using System.Collections;

public class IngameButtons : MonoBehaviour {

	private string current = "";

	public GameObject areYouSureElement;

	void Start () {
	
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			switch(current){
			case "ingamemenu":
				if(!GameControl.isPaused){
					areYouSureElement.gameObject.SetActive(true);
					GameControl.isPaused = true;
				}
				break;
			case "ingamepause":
				GameControl.mouseClicked = true;
				break;
			case "nao":
				areYouSureElement.gameObject.SetActive(false);
				GameControl.isPaused = false;
				break;
			case "sim":
				GameControl.isPaused = false;
				Application.LoadLevel("NewMenu");
				break;
			}
		}
	}

	void OnMouseEnter(){
		current = name;
	}

	void OnMouseExit(){
		current = "";
	}
}
