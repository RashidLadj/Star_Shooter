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
	public float rotationvVaisseau;	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		/** Deplacement **/
		float deplacementHorizontal = Input.GetAxis("Vertical");
		float deplacementVertical = Input.GetAxis("Horizontal");
		Vector3 mouvement = new Vector3(-deplacementHorizontal, 0, deplacementVertical);
		rigidbody.velocity = mouvement * vitesse;	
		/** limit Scene ***/
		rigidbody.position = new Vector3(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			rigidbody.position.y,
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		/** Rotation **/
		rigidbody.rotation = Quaternion.Euler(0f, 0f, rigidbody.velocity.x * -rotationvVaisseau);
	}	
}
