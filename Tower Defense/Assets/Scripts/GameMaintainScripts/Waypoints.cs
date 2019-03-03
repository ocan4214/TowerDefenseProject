using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {


	public static Transform[] points;
	
	void Awake()
	{
		//çocuk sayısı kadar array hazırladık
		points = new Transform[transform.childCount];

		for(int i=0;i<points.Length;i++)
		{
			//Çocukları script array'ine atadık
			points[i]=transform.GetChild(i);
			

		}


	}



}
