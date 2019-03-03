using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChecker : MonoBehaviour {

		public static LevelChecker instance;
		public List<LevelInfo> Levels = new List<LevelInfo>();
		public int LastLevelUnlocked;
		void Awake()
		{
			if(instance == null)
				{
					 instance = this;
					 DontDestroyOnLoad(gameObject);
				}
			else if(instance != this)
				{
					Destroy(gameObject);
				}

		}	


		void Start()
		{	
				
				Debug.Log("Birden fazla çalıştımı çalışmadı mı");

		}


		public void LevelDone(int Levelindex)
		{
				Debug.Log("Levels Done");
				Debug.Log("Levels  : "+ Levels);
				Levels[Levelindex].isLevelDone = true;

		}
		//Debug için
		public void DeleteLevelInfo()
		{
			PlayerPrefs.DeleteKey("SaveLevelInfo");
		}



}


[System.Serializable]
public class LevelInfo
{
	public int levelindex;
	public bool isLevelDone = false;
	




}