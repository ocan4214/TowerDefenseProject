using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//x ve z ekseninde gidecek hız
	public float panSpeed = 30f;

	public float scrollSpeed = 5f;
	
	

	public float panBorderThickness = 10f;

	//Scroll'un sınırlamak için değerler
	public float minY=10f;
	public float maxY=80f;

	void Update () {
			//Eğer gameover olduysa kontroller duruyor

			//Player.instance.showCurrentExp();
			if(GameManager.gameIsOver)
			{
				this.enabled = false;
			}

			

				//Edge Pan  olayı
			//w ye basıldığında veya fare ekranın üstünde olduğunda
			if(Input.GetKey("a") || Input.mousePosition.y >= Screen.height - panBorderThickness)
			{
					//ileri gidecek Space.World ile global eksene göre hareket edecek
					transform.Translate(Vector3.forward*panSpeed*Time.deltaTime,Space.World);
			}
			
			if(Input.GetKey("d") || Input.mousePosition.y <= panBorderThickness)
			{
					//ileri gidecek Space.World ile global eksene göre hareket edecek
					transform.Translate(Vector3.back*panSpeed*Time.deltaTime,Space.World);
			}

			if(Input.GetKey("w") || Input.mousePosition.x >= Screen.width - panBorderThickness)
			{
					//ileri gidecek Space.World ile global eksene göre hareket edecek
					transform.Translate(Vector3.right*panSpeed*Time.deltaTime,Space.World);
			}

			//Eğer fare pozisyonu sınırdan küçükse sola kayacak
			if(Input.GetKey("s") || Input.mousePosition.x <= panBorderThickness)
			{
					//ileri gidecek Space.World ile global eksene göre hareket edecek
					transform.Translate(Vector3.left*panSpeed*Time.deltaTime,Space.World);
			}

			//Fare yuvarlağı ile zoom in zoom out

			float scroll=Input.GetAxis("Mouse ScrollWheel");

			Vector3 pos = transform.position;

			pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;

			pos.y=Mathf.Clamp(pos.y,minY,maxY);

			transform.position = pos;

	}
}
