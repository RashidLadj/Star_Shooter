using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteControl : MonoBehaviour {
	Rigidbody rigidBodyMeteorite;
	public float vitesseMeteorite;
	public Vector3 eulerAngleVelocity;
	public GameObject explosion;
	/** Collision avec le vaisseau --> Defaite **/
	public GameObject explosionWithPlayer;

	// Use this for initialization
	void Start () {
		rigidBodyMeteorite = GetComponent<Rigidbody>();
		rigidBodyMeteorite.velocity = transform.forward * -vitesseMeteorite;
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
	void FixedUpdate () {
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rigidBodyMeteorite.MoveRotation(rigidBodyMeteorite.rotation * deltaRotation);
	}
}
