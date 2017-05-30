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

    int currentMaxEntities;
	int currentMinEntities;

	public bool amIhappy;

	Transform[] myRing;
    //Vector3 normalRingSize = new Vector3 (1,1,1);
    //Vector3 zoneRingSize = new Vector3(0.75f, 0.75f, 0.75f);;

	void Start() {
		myRing = gameObject.GetComponentsInChildren<Transform> ();
        

        currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
		happyChecker ();
	}

	public void happyChecker ()
	{

		//myGameManager.happyGuests.Clear ();
		//myGameManager.unHappyGuests.Clear ();

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

		//Debug.Log (amIhappy);
	}

	public void enterZoneParams ()
	{
		currentMaxEntities = maxEntities + 1;
		currentMinEntities = minEntities - 1;
       
        foreach (Transform component in myRing)
        {
            if (component.gameObject.transform.parent != null)
            {
                component.gameObject.transform.localScale = zoneRingScale ;
            }
        }
        Debug.Log("max" + maxEntities);
        Debug.Log("curr max" + currentMaxEntities);
        Debug.Log("min" + minEntities);
        Debug.Log("curr min" + currentMinEntities);
        happyChecker();
    }

	public void leaveZoneParams ()
	{
		currentMaxEntities = maxEntities - 1;
		currentMinEntities = maxEntities + 1;
        
        foreach (Transform component in myRing)
        {
            if (component.gameObject.transform.parent != null)
            {
                component.gameObject.transform.localScale = normalRingScale;
            }
        }
        Debug.Log("max" + maxEntities);
        Debug.Log("curr max" + currentMaxEntities);
        Debug.Log("min" + minEntities);
        Debug.Log("curr min" + currentMinEntities);
        happyChecker();

    }

}
