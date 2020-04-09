using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class Player_Control : MonoBehaviour {
	/** Vitesse Vaisseau **/
	public float vitesse;
	public Boundary boundary;
	public float rotationvVaisseau;	
	public Rigidbody laserJoueur;
	public Transform canonLaser;
	public float vitesseTir;

	public Rigidbody lightLaser;

	public float frequenceTir;
	float tirSuivant;


	void Update(){
		if (Input.GetButtonDown("Fire1") && Time.time>tirSuivant){
			tirSuivant = Time.time + frequenceTir;
			Rigidbody munitionLaser;
			munitionLaser = Instantiate(laserJoueur, canonLaser.position, canonLaser.rotation) as Rigidbody;
			munitionLaser.AddForce(canonLaser.forward * vitesseTir);

			Rigidbody maLumiereLaser;
			maLumiereLaser = Instantiate(lightLaser, canonLaser.position, canonLaser.rotation) as Rigidbody;
			maLumiereLaser.AddForce(canonLaser.forward * vitesseTir);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
