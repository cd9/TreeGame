using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	private WallController wc;

	public float incrementSpeed = -0.15f;
	public float driftSpeed = -0.01f;
	public float incrementLength = 2;
	public float distance = 0; //distance travelled
	public float spawnDelta = 3;
	private bool isIncrementing;

	public bool IsIncrementing{
		get{return isIncrementing;}
		set{ isIncrementing = value; }
	}

	public float SpawnDelta{
		get{ return spawnDelta; }
		set{ spawnDelta = value; }
	}

	public float Distance{
		get{ return distance; }
		set{ distance = value; }
	}

	public float IncrementSpeed{
		get{return incrementSpeed;}
		set{ incrementSpeed = value; }
	}

	public float DriftSpeed{
		get{ return driftSpeed; }
		set{ DriftSpeed = value; }
	}

	public float IncrementLength{
		get{return incrementLength;}
		set{ incrementLength = value; }
	}

	// Use this for initialization
	void Start () {

		GameObject wcObject = GameObject.Find ("wallController");
		wc = wcObject.GetComponent<WallController> ();

		wc.spawnWall ();
		isIncrementing = false;

	}

	
	// Update is called once per frame
	void FixedUpdate () {
		distance += driftSpeed;


		int fingercount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended) {
				fingercount++;
			}
		}
		if (fingercount > 0&&!isIncrementing) {
			isIncrementing = true;
			onTouch ();
		}


	}

	private void onTouch(){
		print ("touch detected");
		StopAllCoroutines();
		StartCoroutine (wc.incrementWalls(incrementLength, 0.01f));
	
	}
}
