using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {	
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.GetComponent<Player>().Die ();
		}
	}
}