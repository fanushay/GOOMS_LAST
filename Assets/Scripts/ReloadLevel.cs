using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour {

	public Button playAgain;


	// Use this for initialization
	void Start () {
		playAgain = playAgain.GetComponent<Button>();
	}
	
	// Update is called once per frame
	public void ReloadScene () {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
