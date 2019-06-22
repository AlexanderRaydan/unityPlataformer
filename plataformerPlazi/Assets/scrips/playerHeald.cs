using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerHeald : MonoBehaviour {

	// Use this for initialization

	public int heald = 3;

	public Rigidbody2D playerRB; 

	bool hasCooldown;

	public Image [] heardImage ; 
	
	public Scene sceneChange;

	public Animator playerAnimator;

	public AudioSource damageAudio;



	private void OnCollisionEnter2D(Collision2D Collision) {


		if(Collision.transform.tag == "limit")

			SceneManager.LoadScene("firstLevel");


		
		if(Collision.transform.tag == "enemy"){

			playerAnimator.SetTrigger("playerDamage");

			damageAudio.Play();

			substractHeald();

			if(gameObject.GetComponent<SpriteRenderer>().flipX){

				playerRB.AddForce(new Vector2(-5000 , 0));

				//Debug.Log("esele");

			} else {

				playerRB.AddForce(new Vector2(5000 , 0));

				
			}

		}
	}
			void substractHeald(){

				if(!hasCooldown){

					if(heald > 0){

						heald--;

						hasCooldown = true;

						StartCoroutine( cooldown() );
					}

					if(heald <= 0){

						SceneManager.LoadScene("firstLevel");
					}

					empyHeard();
				}
			}
		
	

	IEnumerator cooldown(){ // esto es una suprrutina , la llamas arriba y ejecuta esto

		yield return new WaitForSeconds(.5f);  // hace esperar el tiempo que le pongas en los parentesis

		hasCooldown = false;


		StopCoroutine( cooldown() ); // detiene la subrrutina

	}

	void empyHeard(){

		for(int i = 0 ; i < heardImage.Length ; i++){  // revisa cual es el corazon que hay que quitar dependiendo de su vida 

			if((heald -1) < i ){

				heardImage[ i ].gameObject.SetActive(false);  // desactiva el corazon dependiendo de su vida 
			}

		}
	}

	
}
