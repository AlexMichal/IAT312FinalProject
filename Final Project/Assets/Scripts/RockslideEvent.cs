using UnityEngine;
using System.Collections;

public class RockslideEvent : MonoBehaviour {
	public GameObject player;
	public GameObject rockslide;
	
	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	private void OnTriggerEnter(Collider c) {
		Debug.Log ("Rockslide Trigger");
		
		if (c.tag == "Player") {
			rockslide.gameObject.SetActive(true);
		}
	}
}
