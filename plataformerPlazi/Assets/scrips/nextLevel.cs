using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour {


	private void OnTriggerEnter2D(Collider2D collider) {

			if(collider.tag == "Player"){

				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // carga la scena siguiente , el GetActiveScene().buildIndex es el numero de las scenas cuando se colocan en el build Setings

			}
		
	}
}
