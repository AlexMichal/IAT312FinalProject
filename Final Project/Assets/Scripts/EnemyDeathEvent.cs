using UnityEngine;
using System.Collections;

public class EnemyDeathEvent : MonoBehaviour {
	 void OnTriggerEnter(Collider c) {
		Debug.Log ("Enemy Death Trigger");
		
		if (c.tag == "Enemy") {
			//Destroy(c.GetComponent<Enemy>());
			Destroy (c.gameObject);
		}
	}
}
