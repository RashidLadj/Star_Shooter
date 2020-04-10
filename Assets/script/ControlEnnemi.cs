using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnnemi : MonoBehaviour {
	public float vitesse;
	Rigidbody rigidBodyEnnemi;
	public Rigidbody laserEnnemi;
	public Transform canonLaserDroit, canonLaserGauche;
	public Rigidbody lightLaser;
	public float vitesseTir;
	public float frequenceTir = 0.5f;
	float tirSuivant = 0.0f;

	public GameObject explosion;
	/** Collision avec le vaisseau --> Defaite **/
	public GameObject explosionWithPlayer;

	// Use this for initialization
	void Start () {
		/** Pour le deplacement du vaisseau ennemi **/
		rigidBodyEnnemi = GetComponent<Rigidbody>();
		rigidBodyEnnemi.velocity = transform.forward * -vitesse;
	}
	
	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Player" || other.tag == "laserPlayer"){
			Destroy(other.gameObject);
			Destroy(gameObject);
			if (other.tag == "Player")
				Instantiate(explosionWithPlayer, transform.position, transform.rotation);
			if (other.tag == "laserPlayer")
				Instantiate(explosion, transform.position, transform.rotation);
		}	
	}

	// Update is called once per frame
	void Update () {
		/** Pour la gestion du laser **/
		if (Time.time>tirSuivant){
			tirSuivant = Time.time + frequenceTir;
			Rigidbody munitionLaserDroit;
			munitionLaserDroit = Instantiate(laserEnnemi, canonLaserDroit.position, canonLaserDroit.rotation) as Rigidbody;
			munitionLaserDroit.AddForce(canonLaserDroit.forward * -vitesseTir);

			Rigidbody maLumiereLaserDroit;
			maLumiereLaserDroit = Instantiate(lightLaser, canonLaserDroit.position, canonLaserDroit.rotation) as Rigidbody;
			maLumiereLaserDroit.AddForce(canonLaserDroit.forward * -vitesseTir);

			Rigidbody munitionLaserGauche;
			munitionLaserGauche = Instantiate(laserEnnemi, canonLaserGauche.position, canonLaserGauche.rotation) as Rigidbody;
			munitionLaserGauche.AddForce(canonLaserGauche.forward * -vitesseTir);

			Rigidbody maLumiereLaserGauche;
			maLumiereLaserGauche = Instantiate(lightLaser, canonLaserGauche.position, canonLaserGauche.rotation) as Rigidbody;
			maLumiereLaserGauche.AddForce(canonLaserGauche.forward * -	vitesseTir);

			/** Gestion du son Laser **/
			AudioSource audioLaser = GetComponent<AudioSource>();
			audioLaser.Play();
		}
	}
}
