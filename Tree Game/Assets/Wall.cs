using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	private MainController mc;
	private float driftSpeed  = 0.05f; //for wall drifting when not moving
	private float incrementSpeed = 0.15f; //speed that wall moves when player taps


	// Use this for initialization
	void Start () {
		GameObject mcObject = GameObject.Find ("mainController");
		mc = mcObject.GetComponent<MainController> ();
		driftSpeed = mc.DriftSpeed;
		incrementSpeed = mc.IncrementSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = new Vector3 (transform.position.x+driftSpeed, transform.position.y, transform.position.z);
		transform.position = pos;

		if (transform.position.x >= 5) {
			Destroy (gameObject);
		}
	}

}
