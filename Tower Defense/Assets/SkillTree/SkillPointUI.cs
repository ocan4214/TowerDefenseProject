using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillPointUI : MonoBehaviour {

	public Text text;
	
	// Update is called once per frame
	void Update () {
		
			text.text = "SP : "+Player.instance.playerData.unspendSP.ToString();


	}
}
