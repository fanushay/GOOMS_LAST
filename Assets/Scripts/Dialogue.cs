using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	public SpriteRenderer dialogueSprite;
	public SpriteRenderer dialogueIndicatorSprite;
	public TextMesh dialogueText;

	public float inactiveOpacity;
	public float activeOpacity;

	public bool amIHappy = false;
	public string whereAmI = "Neutral";

	public string[] comfyNeutral;
	public string[] uncomfyNeutral;
	public string[] comfyBar;
	public string[] uncomfyBar;
	public string[] comfyDancefloor;
	public string[] uncomfyDancefloor;

	public Drag myDrag;

	public int maxNumberOfCharactersInASingleLine = 10;

	public void PleaseTellMeWhereIAm (string receivedLocation) {
		whereAmI = receivedLocation;
		DecideDialogue ();
	}

	public void PleaseTellMeIfImHappy (bool receivedHappiness) {
		amIHappy = receivedHappiness;
		DecideDialogue ();
	}

	void DecideDialogue() {
		StopAllCoroutines ();
		dialogueText.text = null;
		if (!amIHappy) {
			if (whereAmI == "Neutral") {
				StartCoroutine("AnimateText", uncomfyNeutral [Mathf.RoundToInt (Random.Range (0, uncomfyNeutral.Length))]);
			}
			if (whereAmI == "Bar") {
				StartCoroutine("AnimateText", uncomfyBar [Mathf.RoundToInt (Random.Range (0, uncomfyBar.Length))]);
			}
			if (whereAmI == "Dancefloor") {
				StartCoroutine("AnimateText", uncomfyDancefloor [Mathf.RoundToInt (Random.Range (0, uncomfyDancefloor.Length))]);
			}
		}
		if (amIHappy) {
			if (whereAmI == "Neutral") {
				StartCoroutine("AnimateText", comfyNeutral [Mathf.RoundToInt (Random.Range (0, comfyNeutral.Length))]);
			}
			if (whereAmI == "Bar") {
				StartCoroutine("AnimateText", comfyBar [Mathf.RoundToInt (Random.Range (0, comfyBar.Length))]);
			}
			if (whereAmI == "Dancefloor") {
				StartCoroutine("AnimateText", comfyDancefloor [Mathf.RoundToInt (Random.Range (0, comfyDancefloor.Length))]);
			}
		}
	}

	IEnumerator AnimateText(string receivedText) {
		int numberOfCharacters = 0;
		for (int i = 0; i < receivedText.Length; i++)
		{
			numberOfCharacters += 1;
			dialogueText.text += receivedText[i];
			if (numberOfCharacters >= maxNumberOfCharactersInASingleLine && receivedText[i].ToString() == " ") {
				dialogueText.text += "\n";
				numberOfCharacters -= maxNumberOfCharactersInASingleLine;
			}
			yield return new WaitForSeconds(0.0001f);
		}
	}

	void Update() {
		if (myDrag.amIBeingDraggedAroundByThePlayerInput) {
			dialogueSprite.color = new Color (dialogueSprite.color.r, dialogueSprite.color.g, dialogueSprite.color.b, activeOpacity);
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, activeOpacity);
			dialogueIndicatorSprite.color = new Color (dialogueIndicatorSprite.color.r, dialogueIndicatorSprite.color.g, dialogueIndicatorSprite.color.b, activeOpacity);
		}
		else if (!myDrag.amIBeingDraggedAroundByThePlayerInput) {
			dialogueSprite.color = new Color (dialogueSprite.color.r, dialogueSprite.color.g, dialogueSprite.color.b, inactiveOpacity);
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, inactiveOpacity);
			dialogueIndicatorSprite.color = new Color (dialogueIndicatorSprite.color.r, dialogueIndicatorSprite.color.g, dialogueIndicatorSprite.color.b, inactiveOpacity);
		}
	}
}
