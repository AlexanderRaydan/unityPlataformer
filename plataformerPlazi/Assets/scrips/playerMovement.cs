using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public Rigidbody2D playerRB; 

	public float speed = .5f;

	public float jumpScale = 2000f;
  
	public bool isGrounded = true;  

	public Animator playerAnimator;

	public AudioSource JumpAudio;

	public SpriteRenderer playerRenderer;



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		playerRB.velocity = new Vector2(Input.GetAxis("Horizontal")*speed , playerRB.velocity.y); // funcion automatica de unity para detectar si las tecla a y d y que se mueva a la derecha y a la izquierda 



		if(Input.GetAxis("Horizontal") == 0 ){

			playerAnimator.SetBool("isWalking" , false); // va a el parametro isWalking de la animacion y cambia su valor


		}else  if(Input.GetAxis("Horizontal") < 0){


			playerAnimator.SetBool("isWalking" , true);

			GetComponent<SpriteRenderer>().flipX = true;

		}else  if(Input.GetAxis("Horizontal") > 0){


			playerAnimator.SetBool("isWalking" , true);

			GetComponent<SpriteRenderer>().flipX = false; // voltea al personaje 

		}


		if(isGrounded){

			if(Input.GetKeyDown(KeyCode.Space)){

					playerRB.AddForce(new Vector2( 0 , jumpScale));

					JumpAudio.Play();

					playerAnimator.SetBool("jump" , true); // activa la transicion de salto

					isGrounded = false;

				}
			}
		}
 	
	private void OnCollisionEnter2D(Collision2D collision) {

			if(collision.transform.tag == "floor"){

				isGrounded = true;

				playerAnimator.SetBool("jump" , false);

			}
			
	}

	 public void desactiveSprite(){

		//gameObject.GetComponent<SpriteRenderer>().enabled = false;
		
		playerRenderer.enabled = false;

	}


	public void activeSprite(){

		//gameObject.GetComponent<SpriteRenderer>().enabled = true;

		playerRenderer.enabled = true;

	}

}



  
