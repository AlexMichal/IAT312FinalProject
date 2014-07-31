using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int levelCount = 4;
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
			switch (Application.loadedLevelName) {
				case "Level_1":
					Application.LoadLevel ("Level_2_Cutscene");
					break;
				case "Level_2_Cutscene":
					Application.LoadLevel ("Level_2");
					break;
				case "Level_2":
					Application.LoadLevel ("Level_3");
					break;
				case "Level_3":
					Application.LoadLevel ("Level_4");
					break;
				case "Level_4":
						Application.LoadLevel ("Final_Cutscene");
					break;
				
			default:
					
					break;
			}
			
			currentLevel++;
			
			
			/*if (currentLevel == 1) {
			
			}
			// Change Scene
			Application.LoadLevel ("Level " + currentLevel);*/
		} else {
			Debug.Log("Game Over");
		}
	}
	
	public void IncreaseLuggageCount() {
		luggageCount++;
	}
}