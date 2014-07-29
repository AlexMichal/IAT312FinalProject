using UnityEngine;
using System.Collections;

public class LoadLevel1 : MonoBehaviour {
	public float myTimer = 5f;
	public AudioClip gameStart;
	
	void Start () {
	
	}
	
	void Update() {
		if (Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel ("Level 1");
			audio.PlayOneShot(gameStart, 0.7F);
		}
	}
}
