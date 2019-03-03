using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Bu kodun amacı Buttonlar için methodlar yazmak
public class PauseMenu : MonoBehaviour {

		public SceneFader sceneFader;

		public string menuSceneName="MainMenu";
		
		public GameObject PauseUI;

		public Player mainPlayer;

	

		void Start()
		{
			mainPlayer=Player.instance;
			mainPlayer.SetLastLevelExperience();
		}

	void Update() {
		
		
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) )
		{

			Toggle();


		}
	}

			public void Toggle()
			{
				//Eğer UI açıksa kapatıcak kapalıysa açacak Toggle yani
				PauseUI.SetActive(!PauseUI.activeSelf);

				if(PauseUI.activeSelf)
				{
					//Zaman büyüsü zamanı durduruyor
					Time.timeScale=0f;
				}

				else
				{
					//Zaman yeniden akıyor
					Time.timeScale=1f;

				}

			}

			public void Retry()
			{
				mainPlayer.SetLastLevelExperience(mainPlayer.GetLastLevelExperience());
				//Bunu zamanı yeniden başlatmak için yapmak zorundayız


				Toggle();
				//Şuanki bulunduğumuz levele gidecek efekt ile
				sceneFader.FadeTo(SceneManager.GetActiveScene().name);
				
				
			}

			public void Menu()
			{
				Toggle();
				mainPlayer.SetLastLevelExperience(mainPlayer.GetLastLevelExperience());
				sceneFader.FadeTo(menuSceneName);
			}


}
