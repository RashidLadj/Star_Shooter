using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Class dédié au control du Laser Ennemi, qui detruit le vaisseau du player en cas de collision **/
public class LaserEnnemiConroller : MonoBehaviour {
	public GameObject explosion;
	/** Collision avec le vaisseau --> Defaite **/
	public GameObject explosionWithPlayer;

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player"){
			Instantiate(explosionWithPlayer, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
			
	}	
}
