using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introvert : MonoBehaviour {

	public CircleSpace myCircleSpace;
	public GameManagerScript myGameManager;
	public ColorManager myColorManager; 


	public int maxEntities;
	public int minEntities;
	public int barMaxEntities;
	public Vector3 normalRingScale;
	public Vector3 zoneRingScale;
	public Vector3 zone2RingScale;

	int currentMaxEntities;
	int currentMinEntities;

	public string whereAmI;

	public Dialogue myDialogue;

	Transform[] myRing;

	public bool amIhappy;

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
		}
		else if (myCircleSpace.entities.Count <= currentMaxEntities && myCircleSpace.entities.Count >= currentMinEntities)
		{

			amIhappy = true;
			myColorManager.HappyAnimation (); //happy
			myGameManager.addToList(gameObject, amIhappy);
		}
		myDialogue.gameObject.SendMessage ("PleaseTellMeWhereIAm", whereAmI);
		myDialogue.gameObject.SendMessage ("PleaseTellMeIfImHappy", amIhappy);
	}


	//ZONE 1 PARAMS
	public void enterDancefloorParams ()
	{
		whereAmI = "Dancefloor";
		currentMinEntities = currentMinEntities + 30;
		happyChecker ();

		foreach (Transform component in myRing)
		{
			if (component.gameObject.transform.parent != null)
			{
				//component.gameObject.transform.localScale = zoneRingScale;
			}
		}
		Debug.Log ("Introvert Entered Dancefloor");
		happyChecker();
	}

	public void leaveDancefloorParams ()
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
		Debug.Log ("Introvert left Dancefloor");
		happyChecker ();
	}

	//ZONE 2 PARAMS
	public void enterBarParams ()
	{
		whereAmI = "Bar";
		currentMaxEntities = barMaxEntities;
		foreach (Transform component in myRing)
		{
			if (component.gameObject.transform.parent != null)
			{
				//component.gameObject.transform.localScale = zone2RingScale;
			}
		}
		Debug.Log ("Introvert Entered Bar");
		happyChecker();
	}

	public void leaveBarParams ()
	{
		whereAmI = "Neutral";
		currentMaxEntities = maxEntities;

		foreach (Transform component in myRing)
		{
			if (component.gameObject.transform.parent != null)
			{
				//component.gameObject.transform.localScale = normalRingScale;
			}
		}
		Debug.Log ("Introvert left Bar");
		happyChecker();
	}
}
