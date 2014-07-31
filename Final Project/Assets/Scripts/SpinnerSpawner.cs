using UnityEngine;
using System.Collections;

public class SpinnerSpawner : MonoBehaviour {
	public GameObject spinner;
	public float timeBetweenSpawns;
	
	private float timer;

	// Use this for initialization
	void Start () {
		// Spawn Spinner
		Instantiate(spinner, this.transform.position, Quaternion.identity);
		
		// Set timer
		timer = timeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () {
		//spinner = Instantiate(spinner, this.transform.position, Quaternion.identity) as GameObject;
		timer = timer - Time.smoothDeltaTime;
		
		if (timer <= 0) {
			// Spawn Spinner
			Instantiate(spinner, this.transform.position, Quaternion.identity);
			
			// Reset timer
			timer = timeBetweenSpawns;
		}
	}
}
