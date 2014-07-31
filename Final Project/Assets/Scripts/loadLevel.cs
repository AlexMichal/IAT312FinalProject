using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour 
{
	public AudioClip gameStart;
	int level;
	void Start ()
	{
	}
	
	void Update()
	{
		level = Application.loadedLevel;
		if (Input.GetKey(KeyCode.Space)) {
			StartCoroutine (loadNext());
		}
	}
	IEnumerator loadNext(){
		audio.PlayOneShot(gameStart, 0.7f);
		yield return new WaitForSeconds (0.7f);
		print("space key is held down");
		Application.LoadLevel (Application.loadedLevel + 1);

	}
}
