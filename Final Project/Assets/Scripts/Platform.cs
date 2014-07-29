using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	public float speed = 1.5f;
	private float timer = 10;
	
	void Update () {
		timer = timer - Time.deltaTime;
		
		if (timer <= 0) {
			Debug.Log ("LESS THAN 0");
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}
}