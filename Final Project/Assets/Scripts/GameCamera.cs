using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	private Transform target;
	private float trackSpeed = 10;
	
	public void SetTarget(Transform t) {
		target = t;
		transform.position = new Vector3(t.position.x, t.position.y, transform.position.z);
	}
	
	// Track target
	void LateUpdate() { // LateUpdate Happens after all the update methods
		if (target != null) {
			float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
			float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
			
			transform.position = new Vector3(x, y, transform.position.z);
		}
	}
	
	private float IncrementTowards(float n, float target, float a) {
		float direction;
		
		if (n == target) {
			return n;	
		} else {
			direction = Mathf.Sign(target - n);
			
			n += a * Time.deltaTime * direction;
			
			if (direction == Mathf.Sign (target - n)) {
				return n;
			} else {
				return target;
			}
		}
	}
}
