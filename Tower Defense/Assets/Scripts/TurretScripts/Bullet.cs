using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	//Bu turret'taki target'ı alıyor
	private Transform target;

	public float damage = 20;
	public float speed=35f;
	public float explosionRadius=0f;

	public GameObject impactEffect;

	//bu fonksiyon ile Turret'ın hedefini Bullet'a atıp takip etmesini sağlayacaz
	public void Seek(Transform _target)
	{
			target=_target;

	}

	void Update()
	{
		//eğer hedef menzilden çıktıysa sonradan atılan mermiyi yok edicek
		if(target==null)
		{
			Destroy(gameObject);
			return;
		}
		//merminin bakacağı pozisyon ona göre mermi ilerleyecek
		Vector3 dir = target.position - transform.position;
		//şu anki framede gideceği yol
		float distanceThisFrame = speed * Time.deltaTime;

		//Eğer merminin hedefe olan uzaklığı gideceği yoldan küçükse hedefi vurmuş olacak
		if(dir.magnitude <= distanceThisFrame)
		{

			HitTarget();
			return;
		}
			//normalize etme sebebimiz aynı yönde 1 birimlik halde gitmesini istememiz
			transform.Translate(dir.normalized*distanceThisFrame,Space.World);
			//Bununla rotasyon sağlanıcak füze giderken düşmana yönelik gidecek
			transform.LookAt(target);


	}

		void HitTarget()
		{
			//Vurduktan sonra çıkan efekt
			GameObject effectinstance =	(GameObject) Instantiate(impactEffect,transform.position,transform.rotation);
			
			Destroy(effectinstance,5f);
			if(explosionRadius > 0f)
			{
				//Roket için	
				Explode();

			}
			else
			
			{
					//Mermi için
					Damage(target);

			}

			//Hasar verdikten sonra mermiyi yok ediyoruz.
			
			Destroy(gameObject);

		}

		//düşmana hasar verecek
		void Damage(Transform enemy)
		{	
			//enemy'nin enemy scriptini alıyor yani şu an hasar vereceği target'ın sonra o enemy'e ait scripti çalıştırıp hasar verdirecek
			Enemy e = enemy.GetComponent<Enemy>();

			if(e !=null)
			e.TakeDamage(damage * Player.instance.skillTreeVariables.bulletDamMult);
			Debug.Log("Mermi hasarı : " + damage * Player.instance.skillTreeVariables.bulletDamMult );

		}

		void Explode()
		{
			//bulunduğu konumda belli bir yarıçaplı kürelik alandaki tüm collidersları toplayıp onların içinden tag'ı Enemy olanlar yok edilecek
			Collider [] colliders =	Physics.OverlapSphere(transform.position,explosionRadius);

			foreach(Collider collider in  colliders)
			{

				if(collider.tag == "Enemy") 
				{
						Damage(collider.transform);
				}

			}


		}

		void OnDrawGizmosSelected()
		{
			Gizmos.color=Color.red;
			Gizmos.DrawWireSphere(transform.position,explosionRadius);
			

		}

}
