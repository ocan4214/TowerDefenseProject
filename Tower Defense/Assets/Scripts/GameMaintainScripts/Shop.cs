using UnityEngine;

public class Shop : MonoBehaviour {

		/*Çalışma Şekli 
		Simgelere tıklandığında aşağıdaki fonksiyonlar çalışıyor
		sonra buildManager'a ulaşıp istediğimiz turret tipini
		inşa edilecek turret tipine yolluyoruz
		sonra node'a tıkladığımızda eğer buildManager.CanBuild fonksiyonu 
		true döndürürse
		buildManagerdan o node'da inşa etmesi içinBuildonHere çağrılıyor
		buildManager'a ise node fonksyinonunda instance'ı olduğu için ulaşıyoruz
	
		
		 */

		BuildManager buildManager;
		//Bunlara editörden değerlerini atadık bu BluePrintler üzerinden işlem yapacaz
		public TurretBluePrint standartTurret;
		public TurretBluePrint missileLauncher;
		public TurretBluePrint LaserBeamer;

		void Start()
		{
				//BuildManager'ın tek bir instance'ı var buna ulaşıp kullanmak için kendi buildManager'ımızı oluşturup referans sağlıyoruz
				buildManager=BuildManager.instance;
				
		}

		public void SelectStandartTurret()
		{
			
			//Tıklıyoruz Button'a sonra tıkladığımızda buildManager'ın inşa edecek olduğu turret'ı buildmanager'ın turretToBuild objesini yolluyor
			//Sonra ise bir node'a fareyi getirdiğimizde ve tıkladığımızda eğer turretToBuild dolu ise inşa edilecek turret'ı node'un turret'ına atıp onu instantiate edecek
			buildManager.SelectTurretToBuild(standartTurret);

		}

		public void SelectMissileLauncher()
		{
				Debug.Log("MissileLauncher");
				buildManager.SelectTurretToBuild(missileLauncher);
		}

		public void SelectLaserBeamer()
		{
				Debug.Log("Laser Beamer selected");
				buildManager.SelectTurretToBuild(LaserBeamer);



		}



}
