using UnityEngine;
using System.Collections;


public class BlinkText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			 StartCoroutine(flash());
	}
	public IEnumerator flash(){
		renderer.enabled = false;
		yield return new WaitForSeconds(0.2f);
		renderer.enabled = true;
	}
}
