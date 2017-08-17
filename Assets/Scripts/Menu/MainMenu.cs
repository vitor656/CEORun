using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUIText[] options;

	private int optionSelected = 0;
	private int maxOptions;


	void Start () {

		maxOptions = options.Length;
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			optionSelected = 1;
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			optionSelected = 0;
		}

		options[optionSelected].guiText.color = Color.red;

		for(int i = 0; i < maxOptions; i++){
			if(i != optionSelected)
				options[i].guiText.color = Color.gray;
		}


		if(optionSelected == 0 && Input.GetKeyDown(KeyCode.Space))
			Application.LoadLevel("Main Scene");
	}
}
