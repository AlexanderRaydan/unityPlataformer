using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour {


	ParticleSystem shootParticle;

	ParticleSystem shootExplotion;

	Vector2 positionParticle;

	bool PlayerFlip;

	 void Start() {
		 
		shootParticle = GameObject.Find("shootParticle").GetComponent<ParticleSystem>();

		shootExplotion = GameObject.Find("shootExplotion").GetComponent<ParticleSystem>();

		PlayerFlip = GameObject.Find("player").GetComponent<SpriteRenderer>().flipX;

	}

	void Update() {

		if(PlayerFlip){

			positionParticle = new Vector2(transform.position.x + 2 , transform.position.y);

		} else {

			positionParticle = new Vector2(transform.position.x - 2 , transform.position.y);

		}

		shootParticle.transform.position = positionParticle;

		shootParticle.Play();
		
	}

	private void OnCollisionEnter2D(Collision2D collision) { // cuando la bala toca el suelo , se destruye

			shootExplotion.transform.position = transform.position;

			shootExplotion.Play();


		//if (collision.transform.tag == "floor"){


			//shootParticle.Play();

			Destroy(gameObject);
		//}
	}
	
}
