using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling_decor : MonoBehaviour {

	public float vitesseDefilement;
	Render render;
	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * vitesseDefilement;
		render.material.mainTextureOffset = new Vector2(offset, 0);
		
	}
}
