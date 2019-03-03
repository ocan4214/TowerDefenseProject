using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO bunun ile leveldeki textlerin değerleri güncellemek için kullanılacak değişime açık  Base'in kullanım nedeni başlangıç değerleri girmek
public class LevelVariables : MonoBehaviour {
		//Buna değer koymadıkeğer koysaydık her yeni ekranda para bir dahaki ekrana taşınacaktı
		public static int Money;
		public int startMoney = 400;
		public static int Lives;
		public Base baseref;
		
		
		//wave sayısı farkı ise  survive edilen wave sayısı
		public static int Rounds ;

		void Start()
		{
			
			
			Money = startMoney;
			Lives=baseref.baseLife;
			
			Rounds = 0;
		}

		

}

