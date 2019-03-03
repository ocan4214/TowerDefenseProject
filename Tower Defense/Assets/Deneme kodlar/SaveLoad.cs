using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad  {



		public static GameData gameInfo = new GameData();
		

		public static void Save()
		{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.gd");
				bf.Serialize(file,SaveLoad.gameInfo);
				file.Close();

				
		}


		public static void Load()
		{
				if(File.Exists(Application.persistentDataPath + "/gameInfo.gd"))
				{
					BinaryFormatter bf = new BinaryFormatter();
					FileStream file = File.Open(Application.persistentDataPath+"/gameInfo.gd",FileMode.Open);
					SaveLoad.gameInfo=(GameData)bf.Deserialize(file);
					file.Close();

				}
				else
				{

					Debug.Log("NO SAVE FILE");
					
				}

		}
	
}
