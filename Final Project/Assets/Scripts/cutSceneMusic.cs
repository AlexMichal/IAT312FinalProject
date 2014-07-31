using UnityEngine;
using System.Collections;

public class cutSceneMusic : MonoBehaviour {
	//public AudioClip[] bgSound;
	// Use this for initialization
	void Start () {
		//AnimationEvent sound1 = new AnimationEvent ();

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (loadNext());

	}
	IEnumerator loadNext(){
		yield return new WaitForSeconds (animation.clip.length + 5);
		Application.LoadLevel (Application.loadedLevel + 1);

	}
	void PlaySound(int num){
		//audio.clip = bgSound [index];
		//audio.play();
		Debug.Log ("play sound" + num);
	}
}
