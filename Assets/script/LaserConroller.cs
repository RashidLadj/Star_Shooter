using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserConroller : MonoBehaviour {

	public GameObject explosion;
	/** Collision avec le vaisseau --> Defaite **/
	public GameObject explosionWithPlayer;

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
}
