using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	private float speed = 4;
	
	public float startingPosition;
	public float endPosition;
	public int unitsToMove = 150;
	public float moveSpeed = 1.5f;
	private bool moveRight;
	
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
