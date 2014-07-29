using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {	
	public float health = 100;
	
	public void TakeDamage(float damage) {
		health = health - damage;
		
		if (health <= 0) {
			Die();	
		}
	}
	
	public void Die() {
		Debug.Log ("DEATH");
		
		Destroy(this.gameObject);
	}
}
