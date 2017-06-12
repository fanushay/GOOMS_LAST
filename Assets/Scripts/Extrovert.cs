using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrovert : MonoBehaviour {

	public CircleSpace myCircleSpace;
	public GameManagerScript myGameManager;
	public ColorManager myColorManager;


	public int maxEntities;
	public int minEntities;
	public Vector3 normalRingScale;
	public Vector3 zoneRingScale;
	public Vector3 zone2RingScale;

	int currentMaxEntities;
	int currentMinEntities;

	public bool amIhappy;

	public string whereAmI;

	Transform[] myRing;

	public Dialogue myDialogue;

	public Sprite comfortableSprite;
	public Sprite uncomfortableSprite;
	public SpriteRenderer mySprite;

	void Start() {
		myRing = gameObject.GetComponentsInChildren<Transform> ();


		currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
		whereAmI = "Neutral";
		happyChecker ();
	}

	public void happyChecker ()
	{



		if (myCircleSpace.entities.Count > currentMaxEntities || myCircleSpace.entities.Count < currentMinEntities)
		{

			amIhappy = false;
			myColorManager.UnhappyAnimation (); //unHappy
			myGameManager.addToList(gameObject, amIhappy);
			mySprite.sprite = uncomfortableSprite;
		}
		else if (myCircleSpace.entities.Count <= currentMaxEntities && myCircleSpace.entities.Count >= currentMinEntities)
		{

			amIhappy = true;
			myColorManager.HappyAnimation (); //happy
			myGameManager.addToList(gameObject, amIhappy);
			mySprite.sprite = comfortableSprite;
		}
		myDialogue.gameObject.SendMessage ("PleaseTellMeWhereIAm", whereAmI);
		myDialogue.gameObject.SendMessage ("PleaseTellMeIfImHappy", amIhappy);

		//Debug.Log (amIhappy);
	}

	public void enterDancefloorParams ()
	{
		whereAmI = "Dancefloor";
		currentMaxEntities = maxEntities + 1;
		currentMinEntities = 0;

		foreach (Transform component in myRing)
		{
			if (component.gameObject.transform.parent != null)
			{
				//component.gameObject.transform.localScale = zoneRingScale ;
			}
		}
		Debug.Log ("Extrovert Entered Dancefloor");
		happyChecker();
	}

	public void leaveDancefloorParams ()
	{
		whereAmI = "Neutral";
		currentMaxEntities = maxEntities - 1;
		currentMinEntities = maxEntities;

		foreach (Transform component in myRing)
		{
			if (component.gameObject.transform.parent != null)
			{
				//component.gameObject.transform.localScale = normalRingScale;
			}
		}

		Debug.Log ("Extrovert Exited Dancefloor");
		happyChecker ();

	}

	//ZONE 2 PARAMS
	public void enterBarParams ()
	{
		whereAmI = "Bar";
		currentMinEntities = currentMinEntities +1;
		foreach (Transform component in myRing)
		{
			if (component.gameObject.transform.parent != null)
			{
				//component.gameObject.transform.localScale = zone2RingScale;
			}
		}
		Debug.Log ("Extrovert Entered Bar");
		happyChecker();
	}

	public void leaveBarParams ()
	{
		whereAmI = "Neutral";
		currentMinEntities = minEntities;
		foreach (Transform component in myRing)
		{
			if (component.gameObject.transform.parent != null)
			{
				//component.gameObject.transform.localScale = normalRingScale;
			}
		}
		Debug.Log ("Extrovert Left Bar");
		happyChecker();
	}

}
