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
				Debug.Log ("Something is between us");
			} else {
				if (!entities.Contains(receivedEntity.gameObject)) {
					entities.Add(receivedEntity.gameObject);
					SendMessage ("happyChecker");
				}
			}
		}
		if (receivedEntity.gameObject.tag == "Environment")
		{
            SendMessage ("enterZoneParams");
        }
		if (GetComponent<Friend>() && receivedEntity.gameObject.name.Contains("Friend"))
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
		if (receivedEntity.gameObject.tag == "Environment")
		{
			SendMessage ("leaveZoneParams");
		}
        
		if (GetComponent<Friend>() && receivedEntity.gameObject.name.Contains("Friend"))
        {
            SendMessage("withoutFriendParams");
        }

    }
}