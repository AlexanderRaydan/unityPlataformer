using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rubyBehavior : MonoBehaviour {

	public GameObject ruby; // le paso el prefab del ruby

	public static int rubyColectableInt = 0; // al hacerla statica , la variable es unica para todos los objetoos por igual

	Text rubyColectableString;

	ParticleSystem particleCollectable;

	AudioSource collectableAudio;


	 void Start() {

		 rubyColectableInt = 0;
		
		rubyColectableString = GameObject.Find("number").GetComponent<Text>();
		
		particleCollectable = GameObject.Find("particleCollectable").GetComponent<ParticleSystem>();  // con esta funcion busca el objeto particleCollection 

		collectableAudio = GameObject.Find("rubyAudio").GetComponent<AudioSource>();

	}

	
	private void OnTriggerEnter2D(Collider2D collision) {

			if(collision.tag == "Player"){

				
			particleCollectable.transform.position = transform.position;

			particleCollectable.Play();

			rubyColectableInt ++;

			rubyColectableString.text = rubyColectableInt.ToString();

			collectableAudio.Play();


			Destroy(ruby);

		}
		
	}

}
