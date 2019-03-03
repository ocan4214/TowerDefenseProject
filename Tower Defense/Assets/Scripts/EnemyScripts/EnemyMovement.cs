using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Enemy componenti olmadan çalışmıyor
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	
		//Bu şuanki takip ettiği wavepointIndex'i
		//private int wavepointIndex=0;	
		private Transform target;
		private Enemy enemy;
		NavMeshAgent agent;

		void Start()
		{

			agent=GetComponent<NavMeshAgent>();
			//burda hedefin pozisyonunu alacaz
			target=GameObject.Find("BaseGate").GetComponent<Transform>();
			//EnemyMovement'ın bulunduğu gameobjedeki enemy compenentini aldık speed'e ulaşmak için
			enemy = GetComponent<Enemy>();
			agent.SetDestination(target.position);
			
			//hedef olarak Waypoints'ten points array'ini aldık
			//target= Waypoints.points[0];
		}


			void Update()
		{
				
				

				if(isDestinationReached())
					{
						
						EndPath();
						return ;
					}
				
				
				

			

			

			
			/* 
			
			//hedefe hareket gerçekleşecek
			//Aralarındaki gitmesi gereken mesafeyi hesaplayıp ona göre hareket ettirecez
			Vector3 dir = target.position-transform.position;
			
			//hızın sabit kalmasını istiyoruz giderken ve frame sayısına göre değil geçen saniyeye göre ilerlemesini istiyoruz
			transform.Translate(dir.normalized*enemy.speed*Time.deltaTime,Space.World);

			//Eğer 0.2 birim yakınlıktaysa vardı varsayıp sıradakine ilerliyecez
			if(Vector3.Distance(transform.position,target.position)<=0.2f)
			{//yakınlık değeri sağa sola dönüşlerde takılmaya sebep verebilir büyüterek halledilir
				GetNextWayPoint();

			}
			//Burda ise hızı eski haline getiriyoruz her frame eğer çıkarsa eski hızla çıkacak lazer vururken ise lazerde frame sırasında update edecek
			

			*/
			enemy.speed=enemy.startSpeed;
		
		}

		/*
		void GetNextWayPoint()
			{
				
					if(wavepointIndex >= Waypoints.points.Length-1)
					{
						//Eğer son wavepoint'e ulaşırsa enemy yok oalacak
						EndPath();
						
						//böyle yapmazsak Arrayındex  is out of range hatası veriyor nedeni ise  alt satıra geçmesi kodun destroy yaptıktan sonra enemy objesini
						return;
					}

				wavepointIndex++;
				target=Waypoints.points[wavepointIndex];

			

			}
			// Can azalıcak
			
		*/

		bool isDestinationReached()
		{
			//Kontrol ediyor bir sonra gideceği yol var mı yoksa true dönüp kkalan mesafe eğer durmamesafesinden küüçükse durmuş oluyor
			if(!agent.pathPending)
				{	
					if(agent.remainingDistance <= agent.stoppingDistance)
						{	
							if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)			
								{
									return true;
        						}
								
						}
						
				}
			
			return false;

		}

		void EndPath()
			{

					//Debug.Log("Worked");
					LevelVariables.Lives--;
					//Bitişe varırsa sayısıda azalıcak
					WaveSpawner.EnemiesAlive--;
					Destroy(gameObject);


			}
}
