using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Node'a tıklandığında aktif olacak BuildManager
public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public GameObject sellEffect;
    public GameObject buildEffect;

    public NodeUI nodeUI;
    public BaseUI baseUI;

    void Awake()
    {
        //singleton
        if(instance !=null)
        {
            Debug.LogError("More than one Build Manager");
            return;


        }
        instance=this;
        

    }
        //İnşa edilecek içinde fiyat ve türü var
    	private TurretBluePrint turretToBuild;

        //UI için gerekli tıklamaları halledecek
        private Node selectedNode;
 

        //property eğer turretToBuild null değil ise true döndürecek inşa edilebilir anlamında
        public bool CanBuild { get{ return turretToBuild != null; } }   
        // Para yetip yetmediğine göre farklı yanacak
        public bool HasMoney { get{ return LevelVariables.Money >= turretToBuild.cost ; } } 
        
        //İnşa edilecek turret bunu yapmak için shop'a reference oluşturmamız
        public void SelectTurretToBuild(TurretBluePrint turret)
        {
            //biri seçiliyken diğeri kullanılmayacak
            turretToBuild=turret;
            selectedNode = null;
            //Turret inşa etmek istediğimizde UI kapalı olacak
            nodeUI.Hide();
        }
        //Bu Node'da eğer turret inşa ediliyse upgrade etmek için kullanılacak
        public void SelectNode(Node node)
        {      
            //Her tıkladığımızda node'a bu SelectNode methodu çalışacak
            //Eğer aynı node tıklandıysa seçimi iptal edecek
            if(selectedNode == node)
                {
                    Deselect();
                    return;
                }
                

            selectedNode = node;
            turretToBuild = null;
            //seçilen node'un UI'ını gönderiyor
            nodeUI.SetTarget(node);

            
        }

        //UI çağırılıyor
        public void SelectedBase()
        {
            baseUI.ToggleUI();

        }



        public void Deselect()
        {

            selectedNode = null;
            nodeUI.Hide();

        }

        public void Reset()
        {
            turretToBuild=null;
            
        }

        //node'a inşa edilecek turret'ı gönderiyor
        public TurretBluePrint GetTurretToBuild()
        {

                return turretToBuild;

        }



}
