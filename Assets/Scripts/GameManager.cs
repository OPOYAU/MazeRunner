using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Maze mazePrefab;
	private Maze mazeInstance;


	// Use this for initialization
	void Start () {
		BeginGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			RestartGame();
		}
	}

	// Begin Game
	void BeginGame(){
		mazeInstance = Instantiate (mazePrefab) as Maze;
		StartCoroutine(mazeInstance.Generate ());
	}

	// Restart Game
	void RestartGame(){
		StopAllCoroutines();
		Destroy (mazeInstance.gameObject);
		BeginGame ();
	}
}
