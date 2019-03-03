using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

			//Bu kodun gelişini gamemanager halledicek ui 'ı aktif etmek için  ui aktif olunca bu script çalışacak ve butonları işe yarayacak
		public SceneFader sceneFader;

		public string sceneMenuName="MainMenu";

		

		


		public void Menu()
		{
			sceneFader.FadeTo(sceneMenuName);

		}


		public void Continue(string _nextLevel)
		{
			
			//TODO her continue çalıştığında bir sonraki level açılacak
			
			//string önemli
			
			SaveLoadManager.instance.SaveLevelInfo(SceneManager.GetActiveScene().buildIndex);
			
			SaveLoadManager.instance.Save();
			sceneFader.FadeTo(_nextLevel); 

			
			
		}



}
