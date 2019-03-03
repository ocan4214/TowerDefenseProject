using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGM : MonoBehaviour {

	public Button STAttack1;
	public Button STAttack2;
	public Button STAttack3;
	
	public bool isLevelMaxed(int levelUpLimit,int currentSkillLevel)
	{
		
		if(currentSkillLevel >= levelUpLimit)
		{

			return true;
		}
		else
			return false;


			
	}

	public void STAttackUpgrade1()
	{

		
		if(isLevelMaxed(Player.instance.skillTreeVariables.maxLevelUpA1,Player.instance.skillTreeVariables.countLevelUpA1))
		{			
			Debug.Log("Skill is already maxed");
			return;
		}
			

		Player.instance.playerData.unspendSP++;
		Player.instance.skillTreeVariables.bulletDamMult+=0.25f;
		Debug.Log("Player.instance.skillTreeVariables.bulletDamMult : " + Player.instance.skillTreeVariables.bulletDamMult);
		Player.instance.skillTreeVariables.countLevelUpA1 ++;
		//STAttack1.GetComponent<Image>().color = new Color(255f,255f,0f,1f);
		
		Debug.Log("Current Skill Level : " + Player.instance.skillTreeVariables.countLevelUpA1 + " Max Level Limit of this skill : " + Player.instance.skillTreeVariables.maxLevelUpA1);
		



	}

	
	public void STAttackUpgrade2()
	{

		
		if(isLevelMaxed(Player.instance.skillTreeVariables.maxLevelUpA2,Player.instance.skillTreeVariables.countLevelUpA2))
		{			
			Debug.Log("Skill is already maxed");
			return;
		}

		if(isLevelMaxed(Player.instance.skillTreeVariables.maxLevelUpA1,Player.instance.skillTreeVariables.countLevelUpA1))
		{	
		Debug.Log("STAttackUpgrade 2 geliştirilebilir çünkü bir önceki stattackupgrade1 geliştirilmiş");
		Player.instance.playerData.unspendSP--;
		Player.instance.skillTreeVariables.bulletDamMult+=0.10f;
		Debug.Log("Player.instance.skillTreeVariables.bulletDamMult : " + Player.instance.skillTreeVariables.bulletDamMult);
		Player.instance.skillTreeVariables.countLevelUpA2 ++;
		//STAttack1.GetComponent<Image>().color = new Color(255f,255f,0f,1f);
		
		Debug.Log("Current Skill Level : " + Player.instance.skillTreeVariables.countLevelUpA2 + " Max Level Limit of this skill : " + Player.instance.skillTreeVariables.maxLevelUpA2);
		}



	}

	
	public void STAttackUpgrade3()
	{

		
		if(isLevelMaxed(Player.instance.skillTreeVariables.maxLevelUpA3,Player.instance.skillTreeVariables.countLevelUpA3))
		{			
			Debug.Log("Skill is already maxed");
			return;
		}
			
		if(isLevelMaxed(Player.instance.skillTreeVariables.maxLevelUpA2,Player.instance.skillTreeVariables.countLevelUpA2))
		{	
		Player.instance.playerData.unspendSP--;
		Player.instance.skillTreeVariables.bulletDamMult+=0.05f;
		Debug.Log("Player.instance.skillTreeVariables.bulletDamMult : " + Player.instance.skillTreeVariables.bulletDamMult);
		Player.instance.skillTreeVariables.countLevelUpA3 ++;
		//STAttack1.GetComponent<Image>().color = new Color(255f,255f,0f,1f);
		
		Debug.Log("Current Skill Level : " + Player.instance.skillTreeVariables.countLevelUpA3 + " Max Level Limit of this skill : " + Player.instance.skillTreeVariables.maxLevelUpA3);
		}



	}




	void Update()
	{



		if(Player.instance.playerData.unspendSP <= 0  )
		{
				STAttack1.GetComponent<Button>().interactable= false;
				STAttack2.GetComponent<Button>().interactable= false;
				STAttack3.GetComponent<Button>().interactable= false;
		}

		else
		{
				STAttack1.GetComponent<Button>().interactable = true;
				STAttack2.GetComponent<Button>().interactable = true;
				STAttack3.GetComponent<Button>().interactable = true;
		}




	}
	
	
	
		//ötek, skilleri yap





}



