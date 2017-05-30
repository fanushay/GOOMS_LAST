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
    public Vector3 zoneRingScale;

    public bool amIhappy;
    public bool withFriend;

    Transform[] myRing;

    void Start() {
        myRing = gameObject.GetComponentsInChildren<Transform>();
        currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
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
		}
		else if (withFriend/*myCircleSpace.entities.Count <= currentMaxEntities && myCircleSpace.entities.Count >= currentMinEntities*/)
		{

			amIhappy = true;
			myColorManager.HappyAnimation (); //happy
			myGameManager.addToList(gameObject, amIhappy);
		}

		//Debug.Log (amIhappy);
	}

    public void enterZoneParams()
    {
        currentMaxEntities = currentMaxEntities + 1;
        currentMinEntities = currentMinEntities - 1;
        foreach (Transform component in myRing)
        {
            if (component.gameObject.transform.parent != null)
            {
                component.gameObject.transform.localScale = zoneRingScale;
            }
        }
        Debug.Log("zonemax" + maxEntities);
        Debug.Log("zonecurr max" + currentMaxEntities);
        Debug.Log("zonemin" + minEntities);
        Debug.Log("zonecurr min" + currentMinEntities);    
        happyChecker();
    }

    public void leaveZoneParams()
    {
        currentMaxEntities = currentMaxEntities - 1;
        currentMinEntities = currentMinEntities + 1;
        foreach (Transform component in myRing)
        {
            if (component.gameObject.transform.parent != null)
            {
                component.gameObject.transform.localScale = normalRingScale;
            }
        }
        Debug.Log("zonemax" + maxEntities);
        Debug.Log("zonecurr max" + currentMaxEntities);
        Debug.Log("zonemin" + minEntities);
        Debug.Log("zonecurr min" + currentMinEntities);
        happyChecker();
    }

    public void withFriendParams()
    {
        currentMaxEntities = currentMaxEntities + 1;
        currentMinEntities = currentMinEntities - 1;
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
        currentMaxEntities = currentMaxEntities + 1;
        currentMinEntities = currentMinEntities - 1;
        //myRing.localScale = new Vector3(1.25f, 1, 1.25f);
        Debug.Log("friendmax" + maxEntities);
        Debug.Log("friendcurr max" + currentMaxEntities);
        Debug.Log("friendmin" + minEntities);
        Debug.Log("friendcurr min" + currentMinEntities);
        withFriend = true;
        happyChecker();
    }
}
