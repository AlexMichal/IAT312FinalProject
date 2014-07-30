using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	private bool moveRight;
	
	public float startingPosition;
	public float endPosition;
	public int unitsToMove = 5;
	public int moveSpeed = 2;
	
	void Awake() {
		startingPosition = transform.position.x;
		endPosition = startingPosition + unitsToMove;
	}
	
	void Update () {
		if (moveRight) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		
		if (transform.position.x >= endPosition) {
			moveRight = false;
		}
		
		if (!moveRight) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		
		if (transform.position.x <= startingPosition) {
			moveRight = true;
		}
	}
}
