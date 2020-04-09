using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour {
	public float timeBeforeDestroy;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeBeforeDestroy);
	}
}
