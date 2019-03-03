using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

		public string sceneMainMenuName="MainMenu";
		public SceneFader sceneFader;
		
	
		
		//GameOver menusünün Retry tuşu
		public void Retry()
		{

			
			//Şu anki bulunduğu scene'in index numarasını yükleyecek yani restart
			sceneFader.FadeTo(SceneManager.GetActiveScene().name);
			
		}

		public void CallMenu()
		{
				sceneFader.FadeTo(sceneMainMenuName);
		}

}
