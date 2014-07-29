using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	void Update () {

	}
	
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.GetComponent<Player>().Die();
		}
	}
}