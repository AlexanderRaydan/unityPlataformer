using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ondulation : MonoBehaviour {

	// Use this for initialization

	public Transform playerTransform;

	public float variation = 1;

	public float deliay = 1;

	public float distancia = 1;

	float ondulacion;

	float aumento = 0;
	
	// Update is called once per frame
	void Update () {

		aumento += 0.1f;

		ondulacion = variation*(Mathf.Sin(aumento - deliay));

		transform.position = new Vector2(playerTransform.position.x -distancia , playerTransform.position.y + ondulacion );
	
	}
}
