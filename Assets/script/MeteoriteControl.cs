using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteControl : MonoBehaviour {
	Rigidbody rigidBodyMeteorite;
	public float vitesseMeteorite;
	public Vector3 eulerAngleVelocity;

	// Use this for initialization
	void Start () {
		rigidBodyMeteorite = GetComponent<Rigidbody>();
		rigidBodyMeteorite.velocity = transform.forward * -vitesseMeteorite;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rigidBodyMeteorite.MoveRotation(rigidBodyMeteorite.rotation * deltaRotation);
	}
}
