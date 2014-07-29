using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	private float speed = 4;
	
	public float startingPosition;
	public float endPosition;
	public int unitsToMove = 5;
	public int moveSpeed = 2;
	private bool moveRight;
	
	void Awake() {
		startingPosition = transform.position.x;
		endPosition = startingPosition + unitsToMove;
	}
	
	void Update () {
		if (moveRight) {
			transform.eulerAngles = new Vector3(0, 180, 0);
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		
		if (transform.position.x >= endPosition) {
			moveRight = false;
		}
		
		if (!moveRight) {
			transform.eulerAngles = new Vector3(0, 0, 0);
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		
		if (transform.position.x <= startingPosition) {
			moveRight = true;
		}
	}
}
