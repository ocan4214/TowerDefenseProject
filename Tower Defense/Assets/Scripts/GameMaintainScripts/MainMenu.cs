using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad ;

	
	//FadeOut olarak yeni leveli başlatıcak
	public void Play()
	{
		//Bunun ile önce SceneFader tipindeki compenentı bulup editörden ordan methodu çalıştırıyor Bunun yerine direk referans yapıp editörden sürükle bırak ile kullanabiliriz
		FindObjectOfType<SceneFader>().FadeTo(levelToLoad);

	}


	public void Quit()
	{
		Debug.Log("Exiting...");
		Application.Quit();

	}


}
