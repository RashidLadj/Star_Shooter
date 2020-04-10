using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject[] obstacle;
	public Vector3 positionVague;
	public int nombreMeteorites;
	public float debutAttente;
	public float attenteVague;
	public float intervalVague;

	// Use this for initialization
	void Start () {
		StartCoroutine(ApparitionVague());
	}
	
	IEnumerator ApparitionVague () {
		
		yield return new WaitForSeconds(debutAttente);
		while(true){
			for (int i=0; i<nombreMeteorites; i++){
				Vector3 maVague = new Vector3(Random.Range(-positionVague.x, positionVague.x), positionVague.y, positionVague.z);
				Quaternion rotationVague = Quaternion.identity;
				Instantiate(obstacle[Random.Range(0,9)], maVague, rotationVague);
				yield return new WaitForSeconds(attenteVague);
			}
			yield return new WaitForSeconds(intervalVague);
		}
		
	}
}
