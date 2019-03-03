using System.Collections;//Coroutine ıenum için
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneFader : MonoBehaviour {

		//Bunun Alphasını fading için kullanıcaz
		public Image img;

		public AnimationCurve curve;

		void Start()

		{


			StartCoroutine(FadeIn());




		}


		public void FadeTo(string scene)
		{

				StartCoroutine(FadeOut(scene));
		
		
		
		
		}

		public void FadeTo1()
		{

				StartCoroutine(FadeOut("Skilltree"));
		
		
		
		
		}

	


		IEnumerator FadeIn()
		{
				//alpha oranını değiştirecek değer
				float t = 1f;
				//Zamanla azalmasını sağlayacaz
				while(t > 0f)
				{
					//Update'in çalışması gibi çalışacak
					t -=Time.deltaTime * 0.5f ;

					float a = curve.Evaluate(t);

					//img'i yeni bir renk ile değiştiriyoruz giderek azalan alfa efekti ile sönüyormuş gibi gözükecek
					img.color = new Color( 0f ,0f ,0f , a) ;

					//Bir frame bekle sonra bidaha uygula
					yield return 0;
				}
		}
	
		
		IEnumerator FadeOut(string scene)
		{
				//alpha oranını değiştirecek değer
				float t = 0f;
				//Zamanla azalmasını sağlayacaz
				while(t > 0f)
				{
					//Update'in çalışması gibi çalışacak
					t +=Time.deltaTime * 0.5f ;

					float a = curve.Evaluate(t);

					//img'i yeni bir renk ile değiştiriyoruz giderek azalan alfa efekti ile sönüyormuş gibi gözükecek
					img.color = new Color( 0f ,0f ,0f , a) ;

					//Bir frame bekle sonra bidaha uygula
					yield return 0;
				}

				//Bölümü yükleyecek
				SceneManager.LoadScene(scene);	


		}	


	



}
