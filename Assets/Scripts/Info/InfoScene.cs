using UnityEngine;
using System.Collections;

public class InfoScene : MonoBehaviour {

	public string currentOption = "";

	public GameObject contentItens;
	public GameObject contentInimigos;
	public GameObject contentEmpresas1;
	public GameObject contentEmpresas2;
	public GameObject contentAbout;

	public GameObject arrow_continue;
	public GameObject arrow_back;

	void Start () {
	
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			switch(currentOption){
			case "menu":
				Application.LoadLevel("NewMenu");
				break;
			case "itens":
				activeContent(contentItens);
				arrow_continue.gameObject.SetActive(false);
				arrow_back.gameObject.SetActive(false);
				break;
			case "inimigos":
				activeContent(contentInimigos);
				arrow_continue.gameObject.SetActive(false);
				arrow_back.gameObject.SetActive(false);
				break;
			case "empresas":
				activeContent(contentEmpresas1);
				arrow_continue.gameObject.SetActive(true);
				break;
			case "tecnico":
				arrow_continue.gameObject.SetActive(false);
				arrow_back.gameObject.SetActive(false);
				activeContent(contentAbout);
				break;
			case "facebook":
				Application.OpenURL("https://www.facebook.com/pages/CEO-Run/454175878048462");
				break;
			case "twitter":
				Application.OpenURL("https://twitter.com/CEORunGame");
				break;
			case "arrow_continue":
				activeContent(contentEmpresas2);
				arrow_continue.gameObject.SetActive(false);
				arrow_back.gameObject.SetActive(true);
				break;
			case "arrow_back":
				activeContent(contentEmpresas1);
				arrow_continue.gameObject.SetActive(true);
				arrow_back.gameObject.SetActive(false);
				break;
			}
		}
	}

	public void activeContent(GameObject content){
		contentItens.gameObject.SetActive(false);
		contentInimigos.gameObject.SetActive(false);
		contentEmpresas1.gameObject.SetActive(false);
		contentEmpresas2.gameObject.SetActive(false);
		contentAbout.gameObject.SetActive(false);


		content.gameObject.SetActive(true);
	}

	void OnMouseEnter(){
		currentOption = name;
	}

	void OnMouseExit(){
		currentOption = "";
	}
}
