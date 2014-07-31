using UnityEngine;
using System.Collections;

public class Spinner_MoveLeft : Enemy {
	private float moveSpeed = 4;
	
	void Update () {
		transform.position += Vector3.left * moveSpeed * Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider c) {
		Debug.Log ("Spinner trigger");
	
		if (c.tag == "Player") {
			c.GetComponent<Player>().Die ();
		}
	}
}