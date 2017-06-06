using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour {
	public CircleSpace myCircleSpace;
	public GameManagerScript myGameManager;
	public ColorManager myColorManager;

	public int maxEntities;
	public int minEntities;

	public int maxWithFriend;
	public int minWithFriend;

	int currentMaxEntities;
	int currentMinEntities;
	public Vector3 normalRingScale;
	public Vector3 dancefloorRingScale;
	public Vector3 barRingScale;
	public int barMaxEntities;

	public bool amIhappy;
	public bool withFriend;
	public GameObject thisIsMyFriend;
	public string whereAmI;

	public Sprite comfortableSprite;
	public Sprite uncomfortableSprite;
	public SpriteRenderer mySprite;

	Transform[] myRing;

	public Dialogue myDialogue;

	void Start() {
		myRing = gameObject.GetComponentsInChildren<Transform>();
		currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
		whereAmI = "Neutral";
		happyChecker ();
	}

	public void happyChecker ()
	{

		//myGameManager.happyGuests.Clear ();
		//myGameManager.unHappyGuests.Clear ();

		if (!withFriend/*myCircleSpace.entities.Count > currentMaxEntities || myCircleSpace.entities.Count < currentMinEntities*/)
		{

			amIhappy = false;
			myColorManager.UnhappyAnimation (); //unHappy
			myGameManager.addToList(gameObject, amIhappy);
			mySprite.sprite = uncomfortableSprite;
		}
		else if (withFriend/*myCircleSpace.entities.Count <= currentMaxEntities && myCircleSpace.entities.Count >= currentMinEntities*/)
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
				//component.gameObject.transform.localScale = dancefloorRingScale;
			}
		}
		Debug.Log ("Friend Entered Dancefloor");
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
		Debug.Log ("Friend left Dancefloor");
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
				//component.gameObject.transform.localScale = barRingScale;
			}
		}
		Debug.Log ("Friend Entered Bar");
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
		Debug.Log ("Friend left Bar");
		happyChecker();
	}


	public void withFriendParams()
	{
		currentMaxEntities = currentMaxEntities + 1;
		currentMinEntities = minEntities;
		//myRing.localScale = new Vector3(1.25f, 1, 1.25f);
		Debug.Log("friendmax" + maxEntities);
		Debug.Log("friendcurr max" + currentMaxEntities);
		Debug.Log("friendmin" + minEntities);
		Debug.Log("friendcurr min" + currentMinEntities);
		withFriend = true;
		happyChecker();
	}


	public void withoutFriendParams()
	{
		currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
		//myRing.localScale = new Vector3(1.25f, 1, 1.25f);
		Debug.Log("friendmax" + maxEntities);
		Debug.Log("friendcurr max" + currentMaxEntities);
		Debug.Log("friendmin" + minEntities);
		Debug.Log("friendcurr min" + currentMinEntities);
		withFriend = false;
		happyChecker();
	}


}

