using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	public float speed = 1.5f;
	private float timer = 10;
	
	private bool moveRight;
	
	public float startingPosition;
	public float endPosition;
	public int unitsToMove = 10;
	public float moveSpeed = 1.5f;
	public bool startLeft = false;
	
	void Awake() {
		startingPosition = transform.position.x;
		if (startLeft) {
			endPosition = startingPosition - unitsToMove;
		} else {
			endPosition = startingPosition + unitsToMove;
		}
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