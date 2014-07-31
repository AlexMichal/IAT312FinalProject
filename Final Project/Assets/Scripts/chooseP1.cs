using UnityEngine;
using System.Collections;

public class chooseP1 : MonoBehaviour {
	public bool p1Choosen = true;
	Animator anim;
	public AudioClip gameStart;
	int level;
	
	
	// Use this for initializatio
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		p1Choosen = anim.GetBool ("left");

		if (Input.GetKey (KeyCode.RightArrow)) {
			if( p1Choosen == true){
				anim.SetBool ("left", false);
			}
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if( p1Choosen == false){
				anim.SetBool ("left", true);
			}
		}
		if(p1Choosen == true && Input.GetKey (KeyCode.Space)){
			level = Application.loadedLevel;
			if (Input.GetKey(KeyCode.Space)) {
				StartCoroutine (loadNext());
			}
			
		}
	}
	IEnumerator loadNext(){
		audio.PlayOneShot(gameStart, 0.7f);
		yield return new WaitForSeconds (0.7f);
		print("space key is held down");
		Application.LoadLevel (Application.loadedLevel + 1);
		
	}

}

