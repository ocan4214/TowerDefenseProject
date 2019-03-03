using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//Bunu Turret simgesi ve logosu aynı yerde olunca ikisi highlight olmasın diye

public class Node : MonoBehaviour {

        public Color notEnoughMoneyColor;
        public Color hoverColor;
        public Vector3 positionOffSet;
        
        [HideInInspector]
        public GameObject turret;//Bu Node üzerindeki turret olup olmadığını kontrol ediyor

        [HideInInspector]
        public TurretBluePrint turretBlueprint;//bu ise bilgileri içeriyor prefab ücret vb

         [HideInInspector]
         public bool isUpgraded=false;


        BuildManager buildManager;
        
        //saklamak için
        private Renderer rend;
        private Color startColor;

        void Start()
        {
            buildManager=BuildManager.instance;
            rend=GetComponent<Renderer>();
            //Başlangıç rengini saklıyoruz fare üstünden ayrıldıktan sonra kullanmak için
            startColor=rend.material.color;
        }
        //Bu method ile turret'ın pozisyonunu buildmanager'a yolluyoruz
        public Vector3 GetBuildPosition()
        {
            return transform.position+positionOffSet;
        }

        //Tıklandığında
        void OnMouseDown()
        {       //Bunun ile aynı anda hem node hem turret highlight olmuyor
                if(EventSystem.current.IsPointerOverGameObject())
                   return;

            //buildManager'ın inşa edilecek olan turret'ı döndürecek eğer null ise return olacak
            

            if(turret != null)
                {
                    //Burda turret yapılı yeri seçecez böylece upgrade yada sell
                    buildManager.SelectNode(this);
                    return;
                }

                if(!buildManager.CanBuild)
                return;

                
                BuildTurret(buildManager.GetTurretToBuild());

        }
        //Build Managerdan inşa edilecek blueprint'i parametre yollayacaz 
        void BuildTurret(TurretBluePrint blueprint)
        {
             //Eğer oyuncunun parası inşa edilecek TurretBluePrint tipindeki class içindeki cost tan düşükse inşa edilemeyecek
            if(LevelVariables.Money < blueprint.cost)
            {
                    
                    Debug.Log("Not enough money");
                    return;
            }
            LevelVariables.Money -= blueprint.cost;
            GameObject _turret = (GameObject) Instantiate(blueprint.prefab,GetBuildPosition(),Quaternion.identity);
            
            //Node'un turret değişkenine inşa edilen turret'ı koyduk
            turret=_turret;
            //Böyle yapıyoruz böylece upgrade edilecek tip belli oluyor
            turretBlueprint=blueprint;

            GameObject effect= (GameObject)  Instantiate(buildManager.buildEffect,GetBuildPosition(),Quaternion.identity);

            Destroy(effect,5f);

            //inşa ettikten sonra hala inşa edebiliyoruz amaç bunu engellemek
            buildManager.Reset();

            Debug.Log("Turret build, Money left : "+LevelVariables.Money);



        }

        public void UpgradeTurret()
        {
             
            if(LevelVariables.Money < turretBlueprint.upgradeCost)
            {
                    Debug.Log("Not enough money");
                    return;
            }
            LevelVariables.Money -= turretBlueprint.upgradeCost;

            //eski turret'ı silecez yerine geliştirilmiş hali gelecek
            Destroy(turret);

            //yeni olanı inşa edecek
            GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradedPrefab,GetBuildPosition(),Quaternion.identity);
            
            //Node'un turret değişkenine inşa edilen turret'ı koyduk
            turret=_turret;

            GameObject effect= (GameObject)  Instantiate(buildManager.buildEffect,GetBuildPosition(),Quaternion.identity);

            Destroy(effect,5f);

            
            isUpgraded=true;

            Debug.Log("Turret upgraded, Money left : "+LevelVariables.Money);





        }

        public void SellTurret()
        {
            //turretBlueprint te inşa edili turret'ın bilgileri var satıp sonra null yapıyoruz
            LevelVariables.Money += turretBlueprint.GetSellAmount();
            
            GameObject effect= (GameObject)  Instantiate(buildManager.sellEffect,GetBuildPosition(),Quaternion.identity);

            

            Destroy(effect,5f);

            Destroy(turret);
            
            //Burda Node üstündeki turret ile ilgili bilgileri 0 lıyoruz
            isUpgraded=false;
            turretBlueprint = null;
            //şimdi bunu ui ile entegre etmeliyiz 

        }


        void OnMouseEnter()
        {
                //aynı anda highlightı önlemek için
                if(EventSystem.current.IsPointerOverGameObject())
                   return;

                 

                //Burda ise eğer Turret yok ise inşa edecek highlight olmayacak yani turret'a tıklayacak inşa edilebilir ise highlight olacak
                if(!buildManager.CanBuild)
                return;

                if(buildManager.HasMoney && turret == null)
                {
                   rend.material.color=hoverColor;
     
                }
                else
                {
                    rend.material.color=notEnoughMoneyColor;
                }
               //Fare üstüne geldiğinde cismin rengi değişecek
               
        }

        void OnMouseExit()
        {

                rend.material.color=startColor;

        }
        


}
