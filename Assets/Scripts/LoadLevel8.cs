using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel8 : MonoBehaviour {
	public Button startButton;



	public void Start () {
		startButton = startButton.GetComponent<Button>();
	}

	public void StartLevel(){
		SceneManager.LoadScene("Level8");

	}
}