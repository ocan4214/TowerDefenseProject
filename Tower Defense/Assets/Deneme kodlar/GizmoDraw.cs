using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDraw : MonoBehaviour {

		 void OnDrawGizmosSelected() {

				 Gizmos.color=Color.cyan;
				 Gizmos.DrawWireSphere(transform.position,2);


		}

	

}
