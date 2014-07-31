using UnityEngine;
using System.Collections;

public class FinalSword : MonoBehaviour {
	public GameObject dopii;

	void OnTriggerEnter(Collider c) {
		Debug.Log ("Final Sword Trigger");
		
		if (c.tag == "Player") {
			Destroy(this.gameObject);
			Destroy(GameObject.FindGameObjectWithTag("Dopii").gameObject);
			Destroy(GameObject.Find ("Spinner_Spawner").gameObject);
			GameObject.Find ("Door").SetActive(false);
		}
	}
}
