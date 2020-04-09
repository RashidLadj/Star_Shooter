using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class Player_Control : MonoBehaviour {
	public float vitesse;
	public Boundary boundary;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float deplacementHorizontal = Input.GetAxis("Vertical");
		float deplacementVertical = Input.GetAxis("Horizontal");
		Vector3 mouvement = new Vector3(-deplacementHorizontal, 0, deplacementVertical);
		GetComponent<Rigidbody>().velocity = mouvement * vitesse;	
		GetComponent<Rigidbody>().position = new Vector3(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			GetComponent<Rigidbody>().position.y,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);

	}	
}
