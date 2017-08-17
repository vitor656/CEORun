using UnityEngine;
using System.Collections;

public class PlayerPrefsControl : MonoBehaviour {

	public static string currentLoginUser = "";
	public static string currentEmailUser = "";

	public static int canLoadLevel = -1;

	private bool canRegister = true;

	void Awake () {
//		if(!PlayerPrefs.HasKey("HighMoney")){
//			PlayerPrefs.SetInt("HighMoney", 0);
//			PlayerPrefs.Save();
//		}

	}

	public static void updateHighMoney(int highMoney){
		if(PlayerPrefs.HasKey(currentLoginUser + ";HighMoney")){
			if(PlayerPrefs.GetInt(currentLoginUser + ";HighMoney") < highMoney){
				PlayerPrefs.SetInt(currentLoginUser + ";HighMoney", highMoney);
				PlayerPrefs.Save();
			}
		}
	}

	public static void setHighMoney(int highMoney){
		if(PlayerPrefs.HasKey(currentLoginUser + ";HighMoney")){
			 
			PlayerPrefs.SetInt(currentLoginUser + ";HighMoney", highMoney);
			PlayerPrefs.Save();
			
		}
	}

	public static int getHighMoney(){
		if(PlayerPrefs.HasKey(currentLoginUser + ";HighMoney")){
			return PlayerPrefs.GetInt(currentLoginUser + ";HighMoney");
		}
		return 0;
	}

	public static void loadLevel(){
		if(PlayerPrefs.HasKey(currentLoginUser + ";HighMoney")){
			if(PlayerPrefs.GetInt(currentLoginUser + ";HighMoney") >= 1000){
				canLoadLevel = 3;
			}else if(PlayerPrefs.GetInt(currentLoginUser + ";HighMoney") > 500){
				canLoadLevel = 3;
			}else if(PlayerPrefs.GetInt(currentLoginUser + ";HighMoney") > 360){
				canLoadLevel = 2;
			}else if(PlayerPrefs.GetInt(currentLoginUser + ";HighMoney") > 60){
				canLoadLevel = 1;
			}

		}
	}
	
	void Update () {
		if(canRegister && (currentEmailUser != "" && currentLoginUser != "")){
			if(!PlayerPrefs.HasKey(currentLoginUser + ";HighMoney")){
				PlayerPrefs.SetInt(currentLoginUser + ";HighMoney", 0);
				PlayerPrefs.SetString(currentLoginUser + ";email", currentEmailUser);
				PlayerPrefs.Save();
				canRegister = false;
			}else{
				getHighMoney();
			}
		}
	}
}
