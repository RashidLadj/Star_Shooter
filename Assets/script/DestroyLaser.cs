using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 1.8f);
	}
}
