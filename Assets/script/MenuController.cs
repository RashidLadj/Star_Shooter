using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
	public void lunchgame(){
		Application.LoadLevel("Game");
	}

	public void leavegame(){
		Application.Quit();
	}
}
