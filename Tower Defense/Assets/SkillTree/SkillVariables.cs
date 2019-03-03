using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Playerda
[System.Serializable]
public class SkillVariables
{
	

	[Header("Multipliers")]
	public float bulletDamMult = 1;
	public float missileDamMult = 1;
	public float laserDamMult = 1 ;
	public float bulletRangeMult = 1;
	public float missileRangeMult = 1;
	public float laserRangeMult = 1 ;
	public float laserslowMult = 1;
	public float missileRadiusMult = 1;
	public float bulletFireRateMult = 1;

	[Header("countLevelUp")]
	public int countLevelUpA1 = 0;
	public int countLevelUpA2 = 0;
	public int countLevelUpA3 = 0;
	

	[Header("maxLevel")]
	public int maxLevelUpA1 = 3;
	public int maxLevelUpA2 = 3;
	public int maxLevelUpA3 = 3;

	
	

}