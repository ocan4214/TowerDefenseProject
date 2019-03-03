using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoUI : MonoBehaviour {

		public Transform SpawnGate;
		public GameObject Ui;
		public Vector3 offSet;
		public bool isActive = false;

		public Text simp;
		public Text stro;
		public Text speed;


		void Start () 
		{

			if(Ui.activeSelf)
			Ui.SetActive(false);
		
		}

		


		public void ToggleInfo()
		{
			if(isActive == false)
				{
						Ui.SetActive(true);
						isActive = true;
				}
			else
				{
						Ui.SetActive(false);
						isActive = false;
				}
		}

		public Vector3 UIPosition()
		{
				return SpawnGate.position+offSet;
		}

		
		



}
	


