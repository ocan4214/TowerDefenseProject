using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour {

	public Base MBase;	
	public GameObject baseui;

	public Button upgradeButton;

	public Text upgradeCost;

	//Bununla tıkladığımızda UI gözüküp kapanıyor
	public void ToggleUI()
	{

		transform.position=MBase.GetBuildPosition();

		if(MBase.baseLevel < 5)
			{

				upgradeCost.text="$" + MBase.upgradeCost.ToString();
				upgradeButton.interactable=true;


			}
		else
			{
				upgradeCost.text="MAX LEVEL";
				upgradeButton.interactable=false;	
			}	




		if(baseui.activeSelf)	
			{
				HideUI();
			}
		else
			{
				activeUI();
			}	


	}

	public void HideUI()
	{
		baseui.SetActive(false);
	}

	public void activeUI()
	{	
		baseui.SetActive(true);
	}

	public void UpgradeButton()
	{

			MBase.UpgradeBase();
			
			//Upgrade edildikten sonra UI kapanıcak
			HideUI();
	}

}
