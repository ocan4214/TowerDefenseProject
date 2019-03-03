using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Binalı node'a tıklandığında bunun bulunduğu konumu turret'a getiricez sonra canvas'ı aktif edecez yada önceden sürüklenen editördeki canvas'ı deaktif edecez
public class NodeUI : MonoBehaviour {
	//Buna Canvas'ı atacaz
	public GameObject ui ;
	public Text sellCost;
	
	public Text upgradeCost;

	public Button upgradeButton;

	//UI'ın geleceği node
	private Node target;




	public void SetTarget(Node _target)
	{

		target=_target;
		//Seçili node'u alacak sonra UI'ı node'un olduğu pozisyona göndericek
		transform.position =  target.GetBuildPosition();
		sellCost.text="$"+ target.turretBlueprint.GetSellAmount().ToString();


		if(target.isUpgraded == false)
		{
		upgradeCost.text="$" + target.turretBlueprint.upgradeCost.ToString();
		upgradeButton.interactable=true;

		}
		else
		{
			upgradeCost.text="DONE";		
			upgradeButton.interactable=false;
		}


		//Node belli olduğunda ui çıkacak
		ui.SetActive(true);
	}

	public void Upgrade()
	{
			//seçili node'un upgrade butonu çalışacak
			target.UpgradeTurret();
			//Upgrade edildikten sonra seçili node deselect olacak
			BuildManager.instance.Deselect();

	}


	public void Hide()
	{
			//node'da gözükmemesi için
			ui.SetActive(false);
	}

	public void Sell()
	{
		target.SellTurret();


		BuildManager.instance.Deselect();	



	}

}
