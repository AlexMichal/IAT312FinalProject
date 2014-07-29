using UnityEngine;
using System.Collections;

public class Luggage : MonoBehaviour {
	
	public GameManager manager;
	public int currentLuggage;

	// Use this for initialization
	void Start () {
		manager = Camera.main.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			PickUpLuggage();
		}
	}
	
	public void PickUpLuggage() {
		manager.IncreaseLuggageCount();
		Destroy(this.gameObject);
	}
}
