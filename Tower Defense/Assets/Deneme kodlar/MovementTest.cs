using UnityEngine;
using System.Collections;
using UnityEngine.AI;//NavMeshAgent'a ulaşmak için	


public class MovementTest : MonoBehaviour {


	public Transform Base;
	NavMeshAgent enemy;

	// Use this for initialization
	void Start () {
				//Start Methodunda bu scriptin olduğu gameobjesinin NavMeshAgent'ına ulaşıp Setdestinationa'ulaşıcak
				enemy=GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
			//Hedefi ise Base'in transfromunun position'a 
			enemy.SetDestination(Base.position);
		
	}
}
