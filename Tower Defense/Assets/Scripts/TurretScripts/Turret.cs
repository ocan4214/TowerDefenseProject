using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	//nişan alacağı hedef
	private Transform target;
	private Enemy targetEnemy;

	[Header("General")]
	
	public float range=15f;

	[Header("Use Bullets (Default)")]
	//Instantiate edilecek bullet
	public GameObject bulletPrefab;
	public float fireRate=1f;
	private float fireCountdown=0f;


	[Header ("Use Laser")]
	public int damageOverTime=30;
	public float slowAmount= .5f;

	public bool useLaser = false;
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;


	[Header("UnitySetupField")]
	public float turnSpeed=10f;
	public Transform partToRotate;
	public string enemyTag="Enemy";
	
	public bool isMissile = false;
	
	//Ateşin çıkacağı nokta
	public Transform  firePoint;

	
	
	void Start () {
		
			InvokeRepeating("UpdateTarget",0f,0.5f);

	}

	void UpdateTarget()
	{
			//Enemy Taglı GameObjectleri enemies array'ine koyduk
			GameObject [] enemies=GameObject.FindGameObjectsWithTag(enemyTag);
			//Default olarak sonsuz sayısı olacak çünkü düşman bulamazsa aralarında sonsuz uzaklık bulunacak
			float shortestDistance=Mathf.Infinity;

			//En yakın düşmanı tutmak için variable
			GameObject nearestEnemy=null;

			//enemies arrayindeki her enemy GameObjesi için Düşmana olan uzaklık ölçüldü
			foreach(GameObject enemy in enemies)
			{
					float distanceToEnemy =Vector3.Distance(transform.position,enemy.transform.position);
					
					if(distanceToEnemy<shortestDistance)
						{
							//Bakıyor eğere en kısa mesafe düşmana uzaklıktan büyükse yeni enkısa mesafe düşmana olan uzaklık oluyor sonra en yakın düşmanı o düşman yapıyorz
							shortestDistance=distanceToEnemy;
							nearestEnemy=enemy;
						}
			}

			//Burda kontrol yapılıyor hesaplandıktan sonra target'a nearestenemy'nin transform'u atılıyor yanlış ise hedef null
			if(nearestEnemy!=null && shortestDistance <=range )
			{

					target=nearestEnemy.transform;
					//targetEnemy'ye enemy compenentini attık
					targetEnemy=nearestEnemy.GetComponent<Enemy>();

			}
			else
				{
					target=null;
				}

	}
	
	
	void Update () {

			if(target==null)
			{

					if(useLaser)
						{
								//hedef yokken line renderer kapalı kalacak
								if(lineRenderer.enabled)
									{	
										lineRenderer.enabled=false;
										//Efekti oynat durdur yaptık yok olunca hedef 
										impactEffect.Stop();
										impactLight.enabled=false;
									}
						}



					return;

			}

				
				
				LockOnTarget();

			if(useLaser)	
				{
						ShootLaser();
				}
				else
				{


			if(fireCountdown <= 0)
				{
					
					if(!isMissile)
					{
						Shoot();
						//saniyede atış sayısı
						fireCountdown = 1f / fireRate;
					}
					else
					{
						ShootMissile();
						fireCountdown = 1f / fireRate;
					}
					
				}
				//İki frame arasında geçen süre çıkacak fireCountdown azalacak
				fireCountdown-=Time.deltaTime;
			}
	}

		void LockOnTarget()
		{
			
				//Hangi yöne bakmamız gerektiği Bitiş Pozisyonu-Başlangıç Pozisyonu yani hedef-cisim
				Vector3 dir = target.position-transform.position;
				//Rotasyonlar Quaternion ile kullanılır burda LookRotation fonksiyonu bakılacak yön için vector3 input istiyor
				Quaternion lookRotation = Quaternion.LookRotation(dir);
				//transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed) bakmak istenen yönü
				Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
					//Lerp ile aniden eski yerine dönmeyi durdurduk yani loop'a aldık
				//Euler cinsinden rotation aldık sonra Quaternion.Euler ile dönmesini istediğimiz yönlerde dönecek y ekseninde dönecek şuan
				partToRotate.rotation =  Quaternion.Euler(0f,rotation.y,0f) ;

		}

		void ShootLaser()
		{
				targetEnemy.TakeDamage(damageOverTime*Player.instance.skillTreeVariables.laserDamMult*Time.deltaTime);
				Debug.Log("Lazer Hasarı saniye başına : "+ damageOverTime*Player.instance.skillTreeVariables.laserDamMult*Time.deltaTime);
				targetEnemy.Slow(slowAmount);


				if(!lineRenderer.enabled)
				{
					//Eğer kapalıysa renderer açıcaz lazeri görmek için
					lineRenderer.enabled = true;
					//düşmanı gördüğünde efekt çalışacak
					impactEffect.Play();
					impactLight.enabled = true; 

				}


				//Laserin yönü
				lineRenderer.SetPosition(0,firePoint.position);
				lineRenderer.SetPosition(1,target.position);
				//Amaç lazeri enemy'nin arkasından çıkarmak onun için A - B yapıyoruz B - A yerine yani turret'a doğru yönelim
				Vector3 dir=firePoint.position - target.position;

				//Efektin target'ın bulunduğu yerin biraz gerisinde çıkmasını istiyoruz Yapılan işlem ise vektörün birimlik yönünü 0.5 ile çarpıp offset olarak ekliyoruz böylece biraz gerisinde oluşacak lazer
				impactEffect.transform.position = target.position + dir.normalized * 0.5f;

				//Efektin yönü
				impactEffect.transform.rotation = Quaternion.LookRotation(dir);

				


		}


		void Shoot()
		{		
				//Bunu GameObject 'e koyup oluşturduğumuz bullet'ı kullanmak için referans oluşturucaz
				GameObject bulletGO =(GameObject) Instantiate(bulletPrefab,firePoint.position,firePoint.rotation) ;
				//Burda ise bullet'ın scriptine ulaşmak için bulletGO game objesinin Bullet Compenantına ulaşıp onu bullet ' a kullanmamız için atayacaz referans
				Bullet bullet=bulletGO.GetComponent<Bullet>();

				if(bullet!=null)
				{
					//Eğer bullet null değilse bullet'ın target'ine Turret'ın şu an hedef aldığı target'i göndericez
					bullet.Seek(target);
				}

		}

		void ShootMissile()
		{		
				//Bunu GameObject 'e koyup oluşturduğumuz bullet'ı kullanmak için referans oluşturucaz
				GameObject missileGO =(GameObject) Instantiate(bulletPrefab,firePoint.position,firePoint.rotation) ;
				//Burda ise bullet'ın scriptine ulaşmak için bulletGO game objesinin Bullet Compenantına ulaşıp onu bullet ' a kullanmamız için atayacaz referans
				Missile missile=missileGO.GetComponent<Missile>();

				if(missile!=null)
				{
					//Eğer bullet null değilse bullet'ın target'ine Turret'ın şu an hedef aldığı target'i göndericez
					missile.Seek(target);
				}

		}
		


		//Mesafeyi gösteren Gizmo
		void OnDrawGizmosSelected() {
			
			Gizmos.color=Color.red;
			Gizmos.DrawWireSphere(transform.position,range);

		
	}




}
