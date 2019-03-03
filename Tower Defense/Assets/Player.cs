using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TODO kullanıcı değerlerini tutacak ek olarak skill point,skilltree
public class Player : MonoBehaviour {

	public static Player instance;
	public bool willSaveSliderWork;

	public PlayerData playerData = new PlayerData();
	public SkillVariables skillTreeVariables = new SkillVariables();
	

	//singleton
	void Awake()
	{
		if(instance == null)
			{

				instance=this;
				DontDestroyOnLoad(gameObject);
			}
		else if(instance != this)
			{
				
				Destroy(gameObject);
				Debug.Log("another instance deleted");
			}

			


	}


	void Start()
	{
			
			

			
			
	}
	

	
	//Reset'e basıldığında toplam skillPointleri döndürecek
	public int ReturnTotalSP()
	{
		playerData.totalSP = (playerData.currentLvl * playerData.perLevelSP) - playerData.perLevelSP;
		return  playerData.totalSP;
	}

	public int GetCurrentExp()
	{

		return playerData.currentExp;
	}

	public int GetLvlUpExp()
	{

		return playerData.lvlUpExp;
	}

	public int GetCurrentLvl()
	{
		return playerData.currentLvl;
	}

	public int GetStartLvl()
	{
		return playerData.startLvl;
	}
	

	public void CheckLevelUp()
	{	
			//Level Atlanacak
			if ( playerData.currentExp >= playerData.lvlUpExp)
				{	
					playerData.currentLvl ++;
					playerData.unspendSP += playerData.perLevelSP;
					playerData.currentExp = playerData.currentExp - playerData.lvlUpExp;
					playerData.lvlUpExp*=2;
					Debug.Log("Level UP");
					ExpSliderUI.instance.UpdateAfterLevelUp();
				}

			else
				{			
					Debug.Log("Not enough Exp slider moved");
					ExpSliderUI.instance.UpdateCurrentExpOnSlider();
				}
		
	}
	//Kontrol ediyor
	public void GetExperience(int expdrop)
	{

			playerData.currentExp += expdrop;
			
			CheckLevelUp();
			

	}
	//Bölüm başında bir kere çalışıyor kaydetmek için
	public void SetLastLevelExperience()
	{
			playerData.startLvl = playerData.currentLvl;
			playerData.lastlevelExp = playerData.currentExp;
			Debug.Log("lastlevelExp = "+ playerData.lastlevelExp + " ----current Exp = " + playerData.currentExp + "-------startLvl of beginning : "  +playerData.startLvl);
	}

	//Bölümü geçemezse lastlevelExp'i eski haline currentExp'i de bir önceki haline dönüştürecez
	public void SetLastLevelExperience(int beginexp)
	{
			
			playerData.lastlevelExp=beginexp;
			playerData.currentExp=beginexp;
			Debug.Log("lost game so we reset to beginning of level lastlevelexp = "+ playerData.lastlevelExp + " ----current Exp = " + playerData.currentExp);
	}

	public int GetLastLevelExperience()
	{
			return playerData.lastlevelExp;
	}

	
	public void showCurrentExp()
	{
		Debug.Log("Current Experience = " + playerData.currentExp+ "/"+playerData.lvlUpExp  + "--Current Level = " + playerData.currentLvl + " "+ "Skill points = "+playerData.unspendSP);
	}

	//TODO burdan Slider'a bilgi gönderilecek

	
}	

[System.Serializable]
public class PlayerData
{
	
	public int lastlevelExp = 0 ;
	public int lvlUpExp = 200;
	public int currentExp = 0;
	public int currentLvl = 1 ;
	public int startLvl = 1;
	public int unspendSP = 50;
	public int perLevelSP = 3;
	public int totalSP = 0;
	



}

