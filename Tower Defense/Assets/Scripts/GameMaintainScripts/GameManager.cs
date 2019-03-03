using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public static bool gameIsOver ;
	
	public GameObject gameOverUI;

	public GameObject completeLevelUI;

	public Player mainPlayer;

	
	
	void Start()
	{
		//GameOver'ın Retry tuşu için kullaıyoruz
		mainPlayer=Player.instance;
		//başlangıçta bir önceki leveli eşitleyecek 
		mainPlayer.SetLastLevelExperience();
		//Böylece bir kere oyun biterye yeni levelde oyunu oynayabilecez
		gameIsOver = false;
		Debug.Log(Time.timeScale);
		//Bulunduğu levelin bilgisini yükleyecek
		SaveLoadManager.InitializeLevelChecker();
		SaveLoadManager.instance.LoadLevelInfo();	
		Debug.Log("Level numarası"+LevelChecker.instance.Levels[2].levelindex);
			
		
	}

	void Update () {
		if(gameIsOver)
			return;

		if(Input.GetKeyDown("e"))
		{
			
			WinLevel();
		}
		
		if(LevelVariables.Lives <= 0)
		{
			mainPlayer.SetLastLevelExperience(mainPlayer.GetLastLevelExperience());
			EndGame();
		}

		Debug.Log(" Multiplier  "+ Player.instance.skillTreeVariables.bulletDamMult);
	}

	public void  WinLevel()
	{
		//level bitince kamera durmasını sağlayacak
		gameIsOver=true;
	
		completeLevelUI.SetActive(true);
	}

	


	void EndGame()
	{
		
		gameIsOver=true;
		Debug.Log("Game Over");
		//Oyun bittiğinde gameOverUI aktifleşecek sonra UI üzerindeki butonlar ise GameOver scripti ile çalıştırılabilr halde olacak
		gameOverUI.SetActive(true);	
	}

}
