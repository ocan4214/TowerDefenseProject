using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveLoadManager : MonoBehaviour  {

		public static SaveLoadManager instance ;
		

		void Awake()
		{
			
			if(instance == null)
			{
				
				instance = this;
				DontDestroyOnLoad(gameObject);

			}
			else if(instance != this )
			{

					Destroy(gameObject);
					Debug.Log("Another instance deleted");

			}
			Debug.Log(PlayerPrefs.GetString("Save"));
			instance.Load();

		}
		
		public void Save()
		{
				string jsonSave = JsonUtility.ToJson(Player.instance.playerData);
				PlayerPrefs.SetString("Save",jsonSave);

		}

		public void Load()
		{
			//PlayerPref ten jsonsave'e kaydettik bunu PlayerDataya çeviricez
			string jsonSave = PlayerPrefs.GetString("Save");
			Player.instance.playerData=JsonUtility.FromJson<PlayerData>( jsonSave ) == null ? new PlayerData() : JsonUtility.FromJson<PlayerData>( jsonSave );
		}

		public void SaveLevelInfo(int Levelindex)
		{
			Debug.Log("Level index called from Continue button "+ Levelindex );
			LevelChecker.instance.LevelDone(Levelindex);
			string jsonSave = JsonUtility.ToJson(LevelChecker.instance.Levels[Levelindex]);
			PlayerPrefs.SetString("SaveLevelInfo"+Levelindex,jsonSave);
		}
		
		public void LoadLevelInfo()
		{
			string jsonSave = PlayerPrefs.GetString("SaveLevelInfo"+SceneManager.GetActiveScene().buildIndex);
			Debug.Log(jsonSave);
			if(JsonUtility.FromJson<LevelInfo>( jsonSave ) == null)
        {
            InitializeLevelChecker();

        }

        else
			{
				
				Debug.Log("Yüklendi bölüm kayıt dosyası no: "+"SaveLevelInfo"+SceneManager.GetActiveScene().buildIndex);
				LevelChecker.instance.Levels[SceneManager.GetActiveScene().buildIndex] = JsonUtility.FromJson<LevelInfo>( jsonSave ) ;	
			}
			
		}

    public static void InitializeLevelChecker()
    {
        LevelChecker.instance.Levels = new List<LevelInfo>();
        //Hata Çıkabilir yeni level eklendiğinde
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings ; i++)
        {

            LevelChecker.instance.Levels.Add(new LevelInfo());
			LevelChecker.instance.Levels[i].levelindex= i;
            Debug.Log("Index of loop   " + i + " Levelindex   :  " + LevelChecker.instance.Levels[i].levelindex + "isLEVELDONE : " + LevelChecker.instance.Levels[i].isLevelDone);

        }
    }
}

