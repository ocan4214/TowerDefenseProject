using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSliderUI : MonoBehaviour {

	public static ExpSliderUI instance;
	public Player mainPlayer;
	public Slider expSlider;
	public Slider SaveSlider; 
	private IEnumerator coroutine;
	float prog;	
	float destP;
	bool isLevelUpSlider;



	//TODO PAUSEMENU COMPLETE LEVEL VE GAMEMANAGER'DA 3 KERE START TA AYNI KOD ÇALIŞIYOR ONU DÜZELT
	//TODO PAUSEMENU COMPLETE LEVEL VE GAMEMANAGER'DA 3 KERE START TA AYNI KOD ÇALIŞIYOR ONU DÜZELT
	//TODO PAUSEMENU COMPLETE LEVEL VE GAMEMANAGER'DA 3 KERE START TA AYNI KOD ÇALIŞIYOR ONU DÜZELT

	void Awake()
	 {

		 	if(instance == null)
				{
					
					instance = this;

				}

			else if( instance != this)	
				{

						Destroy(gameObject);
						Debug.Log("SliderUI duplicate destroyed");
				}
	 
	 }

		


	void Start()
	{
			
			mainPlayer = Player.instance;
			InitializeSlider();
			//Oyun başında geçen levelde  kaldığın exp bar'ı yerleştirecek
			SetLastLevelExpBar();
			
			
			
	}

	void Update()
	{
				SaveSliderProgress();

	}

	
	
	public void InitializeSlider()
	{
		
		expSlider.minValue = 0;
		expSlider.maxValue = mainPlayer.GetLvlUpExp();
		expSlider.value = mainPlayer.GetCurrentExp();
	}
	

	public void UpdateCurrentExpOnSlider()
	{

			expSlider.value =  mainPlayer.GetCurrentExp();
			Debug.Log(expSlider.value+" / " + mainPlayer.GetCurrentExp() );


	}
	
	public void UpdateAfterLevelUp()
	{

			
			expSlider.maxValue = mainPlayer.GetLvlUpExp();
			expSlider.value = mainPlayer.GetCurrentExp();
	}
	//başlangıçta bir kere çalışıyor
	public void SetLastLevelExpBar()
	{
			isLevelUpSlider = false;
			prog = 0f;
			SaveSlider.maxValue = mainPlayer.GetLvlUpExp();
			destP =	SaveSlider.maxValue;
			SaveSlider.value = mainPlayer.GetLastLevelExperience();

	}

	

	public void SaveSliderProgress()

	{
			

			if(mainPlayer.willSaveSliderWork)
			{
				
				if(mainPlayer.GetStartLvl() != mainPlayer.GetCurrentLvl())
				{
					prog += 1f * Time.deltaTime;
					SaveSlider.value = Mathf.Lerp(SaveSlider.value,destP,prog );

					if(prog > 1.0f && !isLevelUpSlider)
					{

						SaveSlider.maxValue = mainPlayer.GetLvlUpExp();
						destP=mainPlayer.GetCurrentExp();
						SaveSlider.value = 0;
						prog = 0f;
						isLevelUpSlider = true;
					}

				}
				else
				{

					prog += 1f * Time.deltaTime;		
					SaveSlider.value = Mathf.Lerp(SaveSlider.value,mainPlayer.GetCurrentExp(),prog );	
					

				}



			}






	}
	
	


}
