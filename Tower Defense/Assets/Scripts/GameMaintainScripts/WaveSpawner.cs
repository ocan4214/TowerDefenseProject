using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive=0;

	public bool isStarted = false;
	
	//Prefablar bunun içinde burdan ulaşılacak
	public List<Wave> waves;
	//Spawn Noktası
	public Transform spawnPoint;
	
	public GameManager gameManagerforWin;

	

	public float timeBetweenWaves = 5f;	
	//Yeni dalganın kaç saniyede geleceği
	private float countdown = 2f;
	//level sayısı
	private int waveIndex = 0;

	public Text waveCountDownText;

	//Bu scripte bilgi yollayacaz
	public EnemyInfoUI Info;

	


	void Start()
	{
			
		
			EnemiesAlive=0;
			//Ekran yeniden yüklendiğinde çalışmayacak
			Player.instance.willSaveSliderWork = false;
			
			
	}

	void Update ()
	{
			
			if(GameManager.gameIsOver == false)
			{
				if(EnemiesAlive > 0 && isStarted )
					{

						return;
					}
			
				//bunuSpawn waveden buraya aldık çünkü son wave spawn edince leveli kazanmış olacaktık ama şimdi eğer son düşman ölüyse ve tüm dalgalar bitiyse win level çalışacak
				//Eğer waveindex waves 'in boyutuna ulaştıysa bu script disable olacak
			

			
				if(waveIndex == waves.Count)
				{
					Player.instance.willSaveSliderWork = true;
					//Bütün dalgalar bitince leveli kazanıyorsun
					gameManagerforWin.WinLevel();
					
					this.enabled = false;

					return;
				}
			

			if(countdown <=0f )
			{
				//IEnumerator'lar StartCoroutine ile başlar
				StartCoroutine(SpawnWave());
				
				

				//Bunu bu işlem bittikten sonra Countdown'ın frame atlamaması için yaptık aşağıda
				return;

			}
			NextWaveInfo(waveIndex);
			//Son frameden yeni frame'e geçene kadarki saniye
			countdown-=Time.deltaTime;
			countdown=Mathf.Clamp(countdown,0f,Mathf.Infinity);
			//Ondalıklı şekilde gözükecek baştaki 0 index numarası
			waveCountDownText.text=string.Format("{0:00.00}",countdown);
		}	
	}
	//IEnumerator ile Kodun çalışma aralıklarını belirleyebiliyoruz
	IEnumerator SpawnWave()
	{
			isStarted = true;
			
			
			//Spawnedilecek wave
			Wave waveToSpawn=waves[waveIndex];
			EnemiesAlive=waveToSpawn.enemyTotal;
			//Basılacak wave'in enemy sayısı


						


		for(int j = 0 ; j < waveToSpawn.enemyGroups.Count ;j++)
		{

			

			for(int i=0;i < waveToSpawn.enemyGroups[j].ecount;i++)
				{
					SpawnEnemy(waveToSpawn.enemyGroups[j].Enemy);
					
					//Spawn Rate'e göre her enemy arasındaki doğum süresi
					yield return new WaitForSeconds(1f/waveToSpawn.rate);
				}
		
		}


				

				waveIndex++;

				//0 olduğunda negatif sayılara düşmesin diye bir dahaki darbenin süresine konacak
				countdown=timeBetweenWaves;
						

	}

	void SpawnEnemy(GameObject enemy)
	{
		
		//EnemyPrefab spawnPoint'transformunun pozisyonu ve rotasyonu
		Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
		
	}

	void NextWaveInfo(int nextWaveIndex)
	{
		

		Wave NextWave = waves[nextWaveIndex];

		for(int j = 0 ; j < NextWave.enemyGroups.Count ;j++)
		{

						 if(NextWave.enemyGroups[j].EnemyType == "Simple")
							{
									Info.simp.text = "x"+ NextWave.enemyGroups[j].ecount.ToString();

							}
						 
						 else if(NextWave.enemyGroups[j].EnemyType == "Strong")
							{
									Info.stro.text = "x"+ NextWave.enemyGroups[j].ecount.ToString();

							}

						 else if(NextWave.enemyGroups[j].EnemyType == "Speed")
							{
									Info.speed.text = "x"+ NextWave.enemyGroups[j].ecount.ToString();

							}		
		
		}



	}
	
	



}



