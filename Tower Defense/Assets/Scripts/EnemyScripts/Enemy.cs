using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
		//Hızın durmaması için startSpeed ypatık
		public float startSpeed=10f;
		[HideInInspector]
		public float speed;

		private bool isDead=false;		

		private float currentHealth=0;

		public float startHealth = 100f;

		public int goldDrop;
		
		public int expDrop;

		public GameObject deathEffect;

		public Player refPlayer;

		

		[Header("Unity Stuff")]
		public Image healthBar;
	
		void Start()
		{
			refPlayer = Player.instance;
			speed=startSpeed;
			currentHealth=startHealth;
		}

		//canı azalıcak
		public void TakeDamage(float amount)
		{

				currentHealth -=amount;
				//Yüzdeye çeviricez ikisi aynı ise 1 azalıyorsa 0.9 0.8 gibi olacak hasar yediğinde
				healthBar.fillAmount = currentHealth / startHealth; 	

				Debug.Log("Bu kadar hasar alındı " + amount + " Şu anki can  bundan "+ startHealth+ " buna indi" + currentHealth);
				//Canı 0 dan küçük veya eşit ve ölü değilse ölecek öldüyse bir daha ölemez hızlı kesince daha fazla para geliyor destroy olmadan önce bir kere daha vurulursa para gelecek
				if(currentHealth <= 0 && !isDead)
				{
					
					Die();

				}
					
		}

		void Die()
		{
			isDead=true;
			//Ölüm efekti
			GameObject effect = Instantiate(deathEffect,transform.position,Quaternion.identity);

			Destroy(effect,5f);

			//Öldüğünde enemy sayısı azalıcak
			WaveSpawner.EnemiesAlive--;

			

			Destroy(gameObject);

			LevelVariables.Money+=goldDrop;
			//False ise exp verecek
			Debug.Log("Bölüm Numarası : "+UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + " YAPILDI MI : "+LevelChecker.instance.Levels[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex].isLevelDone);
			if(!LevelChecker.instance.Levels[UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex].isLevelDone)
			{
			refPlayer.GetExperience(expDrop);
			}
			else{

				Debug.Log("Bölüm önceden tamamlanmış exp vermiyor.");
			}
			//Debug.Log("Current Exp =  " + refPlayer.GetCurrentExp());
			
		}

		public void Slow(float percentage)
		{
			//StartSpeed ile çarpararak her saniye dahada yavaşlayıp durmasını engelledik	 yani 10x0.5 10x0.5 hep sabit kalacak speed
			speed = startSpeed * (1f-percentage);

		}
			


}
