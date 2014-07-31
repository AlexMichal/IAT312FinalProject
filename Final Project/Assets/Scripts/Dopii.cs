using UnityEngine;
using System.Collections;

public class Dopii : Enemy {

	public void Die() {
		Debug.Log ("Dopii DEATH");
		
		Destroy(this.gameObject);
	}
}
