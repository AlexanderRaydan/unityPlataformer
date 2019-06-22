using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {


	public Rigidbody2D enemyRB;

	Transform playerTransform;

	bool canJump;

	public int jump = 700;

	public float enemyVelocity =  0.02f;

	bool focus;

	public float focusRate = 8f;

	public Animator enemyAnimator;

	public AudioSource enemyDeadAudio;



	void Start () {

		playerTransform = GameObject.Find("player").GetComponent<Transform>(); 
		
	}
	
	// Update is called once per frame
	void Update () {


		if(transform.position.x < playerTransform.transform.position.x + focusRate && transform.position.x > playerTransform.transform.position.x - focusRate ){

			focus = true;

		} else {

			focus = false;
		}



		if( focus && transform.position.x > playerTransform.transform.position.x){

			transform.position = new Vector2(transform.position.x - enemyVelocity , transform.position.y);

			GetComponent<SpriteRenderer>().flipX = true; // voltea al personaje 

			enemyAnimator.SetBool("isWalking" , true);


		}

		else if (focus){
			
			transform.position = new Vector2(transform.position.x + enemyVelocity , transform.position.y);

			GetComponent<SpriteRenderer>().flipX = false; // voltea al personaje 

			enemyAnimator.SetBool("isWalking" , true);


		} else{

			enemyAnimator.SetBool("isWalking" , false);

		}
 
		if ( canJump && transform.position.x >=  playerTransform.transform.position.x -1 
		
			&& transform.position.x <=  playerTransform.transform.position.x +1
		
			&& transform.position.y < playerTransform.transform.position.y){

			enemyRB.AddForce(new Vector2(0,jump));

			enemyAnimator.SetBool("isJump" , true ) ; // activa la transicion de salto

			canJump = false;
		}

		/* if(transform.position.x <=  playerTransform.transform.position.x -.5f
		
			&& transform.position.x >=  playerTransform.transform.position.x + .5f

			&& transform.position.y < playerTransform.transform.position.y){

			enemyAnimator.SetBool("isWalking" , true);

		}*/

	}


	private void OnCollisionEnter2D(Collision2D collision) {

			if(collision.transform.tag == "floor"){

				canJump = true;

				enemyAnimator.SetBool("isJump" , false );

		}

		if(collision.transform.tag == "bullet"){

					enemyDeadAudio.Play(); 

					//enemyRB.gravityScale = 0; 

					gameObject.GetComponent<CapsuleCollider2D>().enabled = false;  // esto apaga el collider

					enemyAnimator.SetTrigger("isDead");

				}

		if(collision.transform.tag == "Player"){

			enemyAnimator.SetTrigger("attack");

		}


	}


	public void enemyDestroy(){


		Destroy(gameObject); 
	}
}
