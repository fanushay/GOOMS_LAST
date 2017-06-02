using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	public SpriteRenderer dialogueSprite;
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

	public void PleaseTellMeWhereIAm (string receivedLocation) {
		whereAmI = receivedLocation;
		DecideDialogue ();
	}

	public void PleaseTellMeIfImHappy (bool receivedHappiness) {
		amIHappy = receivedHappiness;
		DecideDialogue ();
	}

	void DecideDialogue() {
		if (!amIHappy) {
			if (whereAmI == "Neutral") {
				dialogueText.text = uncomfyNeutral [Mathf.RoundToInt (Random.Range (0, uncomfyNeutral.Length))];
			}
			if (whereAmI == "Bar") {
				dialogueText.text = uncomfyBar [Mathf.RoundToInt (Random.Range (0, uncomfyBar.Length))];
			}
			if (whereAmI == "Dancefloor") {
				dialogueText.text = uncomfyDancefloor [Mathf.RoundToInt (Random.Range (0, uncomfyDancefloor.Length))];
			}
		}
		if (amIHappy) {
			if (whereAmI == "Neutral") {
				dialogueText.text = comfyNeutral [Mathf.RoundToInt (Random.Range (0, comfyNeutral.Length))];
			}
			if (whereAmI == "Bar") {
				dialogueText.text = comfyBar [Mathf.RoundToInt (Random.Range (0, comfyBar.Length))];
			}
			if (whereAmI == "Dancefloor") {
				dialogueText.text = comfyDancefloor [Mathf.RoundToInt (Random.Range (0, comfyDancefloor.Length))];
			}
		}
	}

	void Update() {
		if (myDrag.amIBeingDraggedAroundByThePlayerInput) {
			dialogueSprite.color = new Color (dialogueSprite.color.r, dialogueSprite.color.g, dialogueSprite.color.b, activeOpacity);
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, activeOpacity);
		}
		else if (!myDrag.amIBeingDraggedAroundByThePlayerInput) {
			dialogueSprite.color = new Color (dialogueSprite.color.r, dialogueSprite.color.g, dialogueSprite.color.b, inactiveOpacity);
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, inactiveOpacity);
		}
	}
}
