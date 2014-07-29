using UnityEngine;
using System.Collections;

public class LoadCutscene : MonoBehaviour {
	public float myTimer = 5f;
	public AudioClip gameStart;
	
	void Start () {
	
	}
	
	void Update() {
		if (Input.GetKey(KeyCode.Space)) {
			Debug.Log ("SPACE PRESSED");
			
			Application.LoadLevel ("BeginningCutscene");
		}
	}
}
