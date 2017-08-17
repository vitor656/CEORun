using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Persistence : MonoBehaviour {

	private GameControl gameControlReference;
	public int savedMoney;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		gameControlReference = FindObjectOfType<GameControl>();
		load();
	}

	void Update () {
		
	}

	public void save(int money){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/arquivo.dat");

		Data data = new Data();
		data.money = money;

		bf.Serialize(file, data);
		file.Close();
	}

	public void load(){
		if(File.Exists(Application.persistentDataPath + "/arquivo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/arquivo.dat", FileMode.Open);

			Data data = (Data)bf.Deserialize(file);
			savedMoney = data.money;

			print (data.money);

			file.Close();
		}
	}

	public void write(){
		if(File.Exists(Application.persistentDataPath + "/arquivo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/arquivo.dat", FileMode.Append);

			Data newData = new Data();


			bf.Serialize(file, newData);
			file.Close();
		}
	}

	public void getAllContent(){
		if(File.Exists(Application.persistentDataPath + "/arquivo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/arquivo.dat", FileMode.Open);

			file.Close();
		}
	}

}

[System.Serializable]
class Data{
	public int money;
}
