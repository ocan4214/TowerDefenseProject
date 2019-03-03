using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//editorde gözlenebilir ve değiştirilebilir ama component değil yani sürüklenemiyor
[System.Serializable]

public class TurretBluePrint{

	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	public int GetSellAmount()
	{

		//Yarı fiyatı dönecek satınca
		return cost / 2;

	}

}
