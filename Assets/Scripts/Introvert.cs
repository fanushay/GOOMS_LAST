using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introvert : MonoBehaviour {
    
	public CircleSpace myCircleSpace;
    public GameManagerScript myGameManager;
	public ColorManager myColorManager; 


    public int maxEntities;
    public int minEntities;
    public Vector3 normalRingScale;
    public Vector3 zoneRingScale;
    int currentMaxEntities;
	int currentMinEntities;

	Transform[] myRing;

	public bool amIhappy;

	void Start() {
		myRing = gameObject.GetComponentsInChildren<Transform> ();
		Debug.Log (myRing);
		currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
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


    }

	public void enterZoneParams ()
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

	public void leaveZoneParams ()
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
}
