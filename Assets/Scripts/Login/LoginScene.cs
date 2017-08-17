using UnityEngine;
using System.Collections;

public class LoginScene : MonoBehaviour {

	public string loginContent = "";
	public string emailContent = "";

	public GameObject loginText;
	public GameObject emailText;

	private PlayerPrefsControl playPrefsControlReference;

	void Start () {
		playPrefsControlReference = FindObjectOfType<PlayerPrefsControl>();
		PlayerPrefsControl.currentEmailUser = "";
		PlayerPrefsControl.currentLoginUser = "";
	
	}

	void Update () {
	
	}

	void OnGUI(){
		loginContent = GUI.TextField(new Rect(Screen.width/2 - 75, Screen.height/2 - 60, 250, 26), loginContent);
		//emailContent = GUI.TextField(new Rect(Screen.width/2 - 75, Screen.height/2 - 10, 250, 26), emailContent);

		if(GUI.Button(new Rect(Screen.width/2, Screen.height/2 + 20, 80, 26), "Submit")){
			if(loginContent != "" /*&& emailContent != ""*/){
				PlayerPrefsControl.currentLoginUser = loginContent;
				PlayerPrefsControl.currentEmailUser = emailContent;

				Application.LoadLevel("NewMenu");
			}
		}
	}
}
