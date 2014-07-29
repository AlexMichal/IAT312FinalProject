using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {
	private float speed = 4;
	private float timer = 5;

	void Awake() {
		/*startingPos = transform.position.x;
		endPos = startingPos + unitsToMove;*/
	}
	
	void Update () {
		/*if (moveRight) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
	
		if (transform.position.x >= endPos) {
			moveRight = false;
		}
		
		if (!moveRight) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		
		if (transform.position.x <= startingPos) {
			moveRight = true;
		}*/
		/*timer = 5;
		
		
		timer = timer - Time.smoothDeltaTime;
		
		Debug.Log ("LEFT");
		transform.Translate(Vector3.left * speed * Time.deltaTime);
		Debug.Log (timer);*/
		
		/*do {
			timer = timer - Time.deltaTime;
			
			Debug.Log ("LEFT");
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		} while (timer > 0) ;*/
		
		
		/*timer = timer - Time.deltaTime;
		
		if (timer <= 0) {
			timer = 3;
			
			Debug.Log ("RIGFHT");
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}*/
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.GetComponent<Player>().Die ();
		}
	}
}