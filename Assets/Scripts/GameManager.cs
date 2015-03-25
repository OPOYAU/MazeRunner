using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Maze mazePrefab;
	private Maze mazeInstance;
	public PlayerController playerPrefab;
	private PlayerController playerInstance;

	// Use this for initialization
	void Start () {
		StartCoroutine (BeginGame ());
		//BeginGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			RestartGame();
		}
	}

	// Begin Game
	IEnumerator BeginGame(){
		mazeInstance = Instantiate (mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate ());
		playerInstance = Instantiate (playerPrefab) as PlayerController;
		playerInstance.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
	}

	// Restart Game
	void RestartGame(){
		StopAllCoroutines();
		Destroy (mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine (BeginGame ());
		//BeginGame ();
	}
}
