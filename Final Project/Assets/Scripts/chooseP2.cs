using UnityEngine;
using System.Collections;

public class chooseP2 : MonoBehaviour {
	public bool p2Choosen = true;
	Animator anim;
	public AudioClip gameStart;
	int level;
	
	
	// Use this for initializatio
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		p2Choosen = anim.GetBool ("right");
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if( p2Choosen == true){
				anim.SetBool ("right", false);
			}
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if( p2Choosen == false){
				anim.SetBool ("right", true);
			}
		}
		if(p2Choosen == true && Input.GetKey (KeyCode.Space)){
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

