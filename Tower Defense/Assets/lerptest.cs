using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lerptest : MonoBehaviour {
	public bool isFull ;
	public Slider slider;
	float progress;

	// Use this for initialization
	void Start () {
			isFull = false;
			progress = 0.0f;
			slider.maxValue=250;
			slider.minValue=0;
			
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(!isFull)
		{
		progress += 1f * Time.deltaTime;
		
		slider.value = Mathf.Lerp(slider.minValue,slider.maxValue,progress);

			if(slider.value == slider.maxValue)
			{
					isFull = true;
					progress = 0f;
			}
		
		}

		else if(isFull)
		{

				progress += 1f * Time.deltaTime;

				slider.value = Mathf.Lerp(slider.maxValue,slider.minValue+25f,progress);

					if(slider.value == slider.minValue)
			{
					isFull = false;
					progress = 0f;
			}

		}
		
		
	}
}
