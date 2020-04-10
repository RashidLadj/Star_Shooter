using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject[] obstacle;
	public Vector3 positionVague;
	public int nombreMeteorites;
	public float debutAttente;
	public float attenteVague;
	public float intervalVague;
	public Canvas canvasGameOver;
	public Button replay;
	public Button Menu;
	public Text GameOver;

	// Use this for initialization
	void Start () {
		canvasGameOver = canvasGameOver.GetComponent<Canvas>();
		replay = replay.GetComponent<Button>();
		Menu = Menu.GetComponent<Button>();
		GameOver = GameOver.GetComponent<Text>();

		StartCoroutine(ApparitionVague());
	}

	public void RestartGame(){
		canvasGameOver.enabled = false;
		replay.enabled = false;
		Menu.enabled = false;
		GameOver.enabled = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MenuGame(){
		canvasGameOver.enabled = false;
		replay.enabled = false;
		Menu.enabled = false;
		GameOver.enabled = false;
		SceneManager.LoadScene("MenuAccueil");
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
