using UnityEngine;
using System.Collections;

public class LoadLevel1 : MonoBehaviour {
	//public float myTimer = 5f;
	public AudioClip gameStart;
	
	void Start () {
	
	}
	
	void Update() {
		if (Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel ("TitleScreen");
		}
	}
}
