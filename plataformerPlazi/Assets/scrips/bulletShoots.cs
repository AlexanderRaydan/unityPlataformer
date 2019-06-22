using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoots : MonoBehaviour {


	public GameObject bulletReference;

	public float bulletPower = 4000f;

	public AudioSource shootAudio;

	GameObject bulletClone ; 

	Vector2 positionPlayerRigt;

	Vector2 positionPlayerLeft;

	public Animator playerAnimator;



	
	void Update () {

		positionPlayerRigt = new Vector2(transform.position.x + 1.5f , transform.position.y );

		positionPlayerLeft = new Vector2(transform.position.x - 1.5f , transform.position.y );


			if(Input.GetMouseButtonDown(0)){  // cuando se preciona un click , se dispara


				shootAudio.Play(); 

				playerAnimator.SetTrigger("attack"); 

				if(GetComponent<SpriteRenderer>().flipX){

				bulletClone = Instantiate(bulletReference , positionPlayerLeft , transform.rotation) as GameObject;  // se crea una bala en la posicion del jugador un poco a la derecha o la izquierda 


				bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector2( -bulletPower , 0)); // se le da la fuerza a la bala a la izquierda si el jugador esta mirando a la izquierda 

			} else {

				bulletClone = Instantiate(bulletReference , positionPlayerRigt , transform.rotation) as GameObject;


				bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector2( bulletPower , 0));  // lo mismo pero la bala va hacia la derecha
		
			}

		}	
		
	}
	
}
