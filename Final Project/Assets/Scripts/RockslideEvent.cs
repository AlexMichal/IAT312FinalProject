using UnityEngine;
using System.Collections;

public class RockslideEvent : MonoBehaviour {
	public GameObject rockslide;

	private void OnTriggerEnter(Collider c) {
		Debug.Log ("Rockslide Trigger");
		
		if (c.tag == "Player") {
			rockslide.gameObject.SetActive(true);
		}
	}
}
