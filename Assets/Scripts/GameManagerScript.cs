using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManagerScript : MonoBehaviour
{


    public UImanager myUImanager;
	public GameObject youWin;
	public GameObject nextButton;
    public List<GameObject> happyGuests = new List<GameObject>();
	public List<GameObject> unHappyGuests = new List<GameObject>();

	private WinConditions myWinConditions;
	public int time;

	GameObject[] getAll;
	Drag myDrag;
    CircleSpace myCircleSpace;
	//public GameObject youWin;
	//public GameObject Next;
	//public GameObject Quit1;

	void Start (){
		
		///change 

	}


	public void addToList(GameObject receivedEntity, bool isThisEntityHappy)
	{
		if (!isThisEntityHappy) {
			if (!unHappyGuests.Contains(receivedEntity)) {
				unHappyGuests.Add(receivedEntity);
			}
			if (happyGuests.Contains (receivedEntity)) {
				happyGuests.Remove(receivedEntity);
			}
		}
		if (isThisEntityHappy) {
			if (!happyGuests.Contains (receivedEntity)) {
				happyGuests.Add (receivedEntity);
			} 
			if (unHappyGuests.Contains (receivedEntity)) {
				unHappyGuests.Remove (receivedEntity);
			}
		}
	}


	void Update (){

		if (unHappyGuests.Count == 0) {
			youWin.SetActive (true);
			nextButton.SetActive (true);


			//Display YOU WIN text and next quit buttons
			//myUImanager.youWin.SetActive (true);
			//Next.SetActive (true);
			//Quit1.SetActive (true);

			if (getAll == null)
				getAll = GameObject.FindGameObjectsWithTag ("Character");
			foreach (GameObject entity in getAll) {
				entity.GetComponent<Drag>().canIMoveIfIAmDraggedBecauseTheGameHasNotYetEnded = false;
			}

			//Communicate with UI Manager script and load "You Win!"
			//myUImanager.youWin ();


			//if (time = 0){
				//myUImanager.youLose ();
			//}
		}

	}

}
