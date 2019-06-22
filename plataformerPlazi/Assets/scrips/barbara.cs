using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barbara : MonoBehaviour {

	public Rigidbody2D barbarita;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		barbarita.velocity = new Vector2( 2 , 0 );
		
	}
}
