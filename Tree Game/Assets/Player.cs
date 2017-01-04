using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float dist;
	private bool rising;
	private MainController mc;

	// Use this for initialization
	void Start () {
		dist = 4;
		rising = true;
		GameObject mcObject = GameObject.Find ("mainController");
		mc = mcObject.GetComponent<MainController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (mc.IsIncrementing) {
			return;
		}
		if (rising){
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y+0.1f, gameObject.transform.position.z);
			if (gameObject.transform.position.y >= dist) {
				rising = !rising;
			}
			print ("rising");
				
		}
		else{
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y-0.1f, gameObject.transform.position.z);
			if (gameObject.transform.position.y <= -dist) {
				rising = !rising;
			}
		}
		
	}
}
