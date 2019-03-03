using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave {
		//Wave Bilgileri
		public List<EnemyGroups> enemyGroups;
		public float rate;



		public int enemyTotal
		{
				get
				{
					int value=0;
					foreach(EnemyGroups eg in enemyGroups)
					{
							value+=eg.ecount;
					}

					return value;
				}
		}


		
}


[System.Serializable]

public class EnemyGroups
{

		public GameObject Enemy;
		public int ecount;
		
		//TODO editorde tek tek girmek yerine 
		public string EnemyType;

		 
}
