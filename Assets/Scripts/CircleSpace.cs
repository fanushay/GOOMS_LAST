using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpace : MonoBehaviour
{
	public List<GameObject> entities = new List<GameObject>();
	Drag myDrag;


	void Start()
	{
		myDrag = GetComponent<Drag> ();
	}
	void OnTriggerEnter(Collider receivedEntity)
	{
		if (receivedEntity.gameObject.tag == "Character")
		{
			RaycastHit raycastHit;
			Physics.Raycast(transform.position, (receivedEntity.transform.position - transform.position).normalized, out raycastHit, (receivedEntity.transform.position - transform.position).magnitude, myDrag.backgroundLayerMask);

			if (raycastHit.collider != null) {
			} else {
				if (!entities.Contains(receivedEntity.gameObject)) {
					entities.Add(receivedEntity.gameObject);
					SendMessage ("happyChecker");
				}
			}
		}
		if (receivedEntity.gameObject.tag == "Dancefloor")
		{
			SendMessage ("enterDancefloorParams");
		}
		if (receivedEntity.gameObject.tag == "Bar")
		{
			SendMessage ("enterBarParams");
		}

		if (GetComponent<Friend>() && receivedEntity.gameObject.name.Contains("Friend") && receivedEntity.gameObject == GetComponent<Friend>().thisIsMyFriendWhoILoveAndCameToThisPartyTogetherWithCauseWeAreBestFriends)
		{
			SendMessage("withFriendParams");
		}
	}

	void OnTriggerExit(Collider receivedEntity)
	{
		if (receivedEntity.gameObject.tag == "Character") {
			if (entities.Contains (receivedEntity.gameObject)) {
				entities.Remove (receivedEntity.gameObject);
				SendMessage ("happyChecker");
			}
		}
		if (receivedEntity.gameObject.tag == "Dancefloor")
		{
			SendMessage ("leaveDancefloorParams");
		}

		if (receivedEntity.gameObject.tag == "Bar")
		{
			SendMessage ("leaveBarParams");
		}

		if (GetComponent<Friend>() && receivedEntity.gameObject.name.Contains("Friend") && receivedEntity.gameObject == GetComponent<Friend>().thisIsMyFriendWhoILoveAndCameToThisPartyTogetherWithCauseWeAreBestFriends)
		{
			SendMessage("withoutFriendParams");
		}

	}
}