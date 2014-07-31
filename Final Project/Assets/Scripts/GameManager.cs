using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int levelCount = 3;
	public static int currentLevel = 1;
	public static int luggageCount = 0;
	
	public GameObject player;
	public GUIText luggageCountText;

	private GameObject currentPlayer;	
	private GameCamera camera;
	private Vector3 checkpoint;
	
	private void Start () {
		camera = GetComponent<GameCamera>();
		
		if (GameObject.FindGameObjectWithTag("Spawn")) {
			checkpoint = GameObject.FindGameObjectWithTag("Spawn").transform.position;
		}
			
		SpawnPlayer(checkpoint);
	}
	
	private void Update() {
		if (!currentPlayer) {
			if (Input.GetButtonDown("Respawn")) {
				SpawnPlayer (checkpoint);
			}
		}
		luggageCountText.text = "" + luggageCount;
	}
	
	public void SetCheckpoint(Vector3 cp) {
		checkpoint = cp;
	}
	
	private void SpawnPlayer(Vector3 spawnLocation) {
		// Instantiate a Player
		currentPlayer = Instantiate(player, spawnLocation, Quaternion.identity) as GameObject;
		
		camera.SetTarget(currentPlayer.transform);
	}
	
	public void EndLevel() {
		if (currentLevel < levelCount) {
			currentLevel++;
			
			// Change Scene
			Application.LoadLevel ("Level " + currentLevel);
		} else {
			Debug.Log("Game Over");
		}
	}
	
	public void IncreaseLuggageCount() {
		luggageCount++;
	}
}