using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

	public float changeSpeed = 10.0f;
	public float changeTime = 0.25f;
	SpriteRenderer mySpriteRenderer;
	int currentState = 2;

	public Color unComfyColor = new Color();
	public Color comfyColor = new Color();

	void Start()
	{
		mySpriteRenderer = GetComponent<SpriteRenderer> ();

	}

	public void UnhappyAnimation()
	{
		CancelInvoke ("UnhappyAnimation");
		if (currentState != 0) {
			currentState = 0;
		} else if (currentState == 0) {
			currentState = 1;
		}
		Invoke ("UnhappyAnimation", changeTime);
	}

	public void HappyAnimation() {
		CancelInvoke ("UnhappyAnimation");
		currentState = 2;
		GetComponent<SpriteRenderer> ().color = comfyColor;

	}



	void Update()
	{
		if (currentState == 0) {
			mySpriteRenderer.color = Color.Lerp (mySpriteRenderer.color, unComfyColor, Time.deltaTime * changeSpeed);
		} else if (currentState == 1) {
			mySpriteRenderer.color = Color.Lerp (mySpriteRenderer.color, comfyColor, Time.deltaTime * changeSpeed);
		}
	}

}
