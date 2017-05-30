using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuitGame : MonoBehaviour {

	public Button quitButton;



	public void Start () {
		quitButton = quitButton.GetComponent<Button>();
	}

	public void QuitNow(){
		SceneManager.LoadScene("Intro");
	}
}