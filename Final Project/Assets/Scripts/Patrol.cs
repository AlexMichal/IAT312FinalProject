using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	private bool moveRight;
	
	public float startingPosition;
	public float endPosition;
	public int unitsToMove = 10;
	public float moveSpeed = 1.5f;
	public bool startLeft = false;
	public bool faceMovementBearing = true;
	
	void Awake() {
		startingPosition = transform.position.x;
		if (startLeft) {
			endPosition = startingPosition - unitsToMove;
		} else {
			endPosition = startingPosition + unitsToMove;
		}
	}
	
	void Update () {
		if (startLeft) {
			
			if (!moveRight) {
				if (faceMovementBearing) {
					transform.eulerAngles = new Vector3(0, 0, 0);
				}
				transform.position += Vector3.left * moveSpeed * Time.deltaTime;
			}
			
			if (transform.position.x <= endPosition) {
				moveRight = true;
			}
		
			if (moveRight) {
				if (faceMovementBearing) {
					transform.eulerAngles = new Vector3(0, 180, 0);
				}
				transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			}
			
			if (transform.position.x >= startingPosition) {
				moveRight = false;
			}
		
			
		} else {
			if (moveRight) {
				if (faceMovementBearing) {
					transform.eulerAngles = new Vector3(0, 180, 0);
				}
				transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			}
			
			if (transform.position.x >= endPosition) {
				moveRight = false;
			}
			
			if (!moveRight) {
				if (faceMovementBearing) {
					transform.eulerAngles = new Vector3(0, 0, 0);
				}
				transform.position += Vector3.left * moveSpeed * Time.deltaTime;
			}
			
			if (transform.position.x <= startingPosition) {
				moveRight = true;
			}
		}
	}
}
