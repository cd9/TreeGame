using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	private float incrementSpeed;
	MainController mc;
	private float distance;

	// Use this for initialization
	void Start () {
		GameObject mcObject = GameObject.Find ("mainController");
		mc = mcObject.GetComponent<MainController> ();
		incrementSpeed = mc.IncrementSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distance = mc.Distance;
		if (distance >= mc.SpawnDelta) {
			spawnWall ();
			mc.Distance = 0;
		}

	}

	public void spawnWall(){
		GameObject wall = Resources.Load<GameObject> ("wall");
		float rand = Random.Range(-1.5f , 1.5f);
		float y = wall.transform.position.y + rand;
		Vector3 pos = new Vector3(wall.transform.position.x, y, wall.transform.position.z);
		Instantiate (wall, pos, Quaternion.identity);
	}

	public IEnumerator incrementWalls(float length, float secondsToWait){ //coroutine to increment wall, f is distance to increment
		float i = 0;
		while (i < length) {
			GameObject[] walls = GameObject.FindGameObjectsWithTag ("wall"); //the wall objects not the actual Wallls
			foreach (GameObject wall in walls) {
				Vector3 pos = new Vector3 (wall.transform.position.x+incrementSpeed, wall.transform.position.y, wall.transform.position.z);
				wall.transform.position = pos;
				i += incrementSpeed;
			}
			mc.distance += incrementSpeed;
			yield return new WaitForSeconds (secondsToWait);
		}
		mc.IsIncrementing = false;

	}
}
