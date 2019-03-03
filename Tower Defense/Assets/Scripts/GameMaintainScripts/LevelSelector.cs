
using UnityEngine;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour {
		
		public SceneFader fader;
		
		//Level butonlarını toplayıp interaktif çalışmasını sağlıyoruz
		public Button [] levelButtons;


		void Start()
		{		
				
				
				//levelReached datasına ulaşıcak default olarak 1 olacak
				int levelReached = PlayerPrefs.GetInt("levelReached",1);
				


				for	(int i=0; i< levelButtons.Length;i++)
				{
					//Eğer level indexi  ulaşılan levelden büyükse o levelin indexi kapalı olacak
					if( i > levelReached)
					{
					levelButtons[i].interactable = false;
					}	
				}

		}


		//Butona on click için level
		public void Select(string levelName)
		{

				fader.FadeTo(levelName);


		}


}
