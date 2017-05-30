using UnityEngine;
using System.Collections;

public class snaptogrid : MonoBehaviour {

	public float xSnap = 1f;
	public float ySnap = 1f;

	public static float XSnap { get; private set; }
	public static float YSnap { get; private set; }

	void Awake () {
		XSnap = xSnap;
		YSnap = ySnap;
	}
	// Use this for initialization
	void Start () {
		Vector3 currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
