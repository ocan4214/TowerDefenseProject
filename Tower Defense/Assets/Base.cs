using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

		public int baseLife=25;
		public int upgradeCost=1000;
		public int baseLevel=1;

		public Vector3 positionOffSet;

		private Renderer rend;
		private Color startColor;
		[Header("Hovering")]
		public Color hoverColor;
		

		public BuildManager buildManager;

		void Start()
		{		
			rend=GetComponent<Renderer>();
			startColor=rend.material.color;

			buildManager=BuildManager.instance;


		}

		public Vector3 GetBuildPosition()
        {
            return transform.position+positionOffSet;
        }


		public void UpgradeBase()
		{
			
			


			if(LevelVariables.Money < upgradeCost)
				{
					Debug.Log("Not enough money");
                    return;
				}
			
			LevelVariables.Money -= upgradeCost;
			baseLevel++;
			upgradeCost+=500;
			IncreaseLife();
			Debug.Log("Cost : " + upgradeCost + " baseLevel : " + baseLevel);

		}

		public void IncreaseLife()
		{

			LevelVariables.Lives+=25;

		}


		void OnMouseDown()
		{

			buildManager.SelectedBase();


		}



		void OnMouseEnter()
		{

				
			rend.material.color = hoverColor;


		}
		
		void OnMouseExit()
		{

			rend.material.color = startColor;

		}




}
