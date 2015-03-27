using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Maze mazePrefab;
	private Maze mazeInstance;
	public PlayerController playerPrefab;
	private PlayerController playerInstance;
	public Rotator coinPrefab;
	private Rotator[] coinInstances;
	private int coinsInGame;
	public GUIText countText;
	public int coins;

	// Use this for initialization
	void Start () {
		StartCoroutine (BeginGame ());
		//BeginGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			RestartGame ();
		}
		if(playerInstance != null){
			coins = playerInstance.coins;
		}
		SetCountText();
	}

	// Begin Game
	IEnumerator BeginGame(){
		coins = 0;
		Camera.main.clearFlags = CameraClearFlags.Skybox;
		mazeInstance = Instantiate (mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate ());
		playerInstance = Instantiate (playerPrefab) as PlayerController;
		playerInstance.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
		coinsInGame = 50;
		coinInstances = new Rotator[50];
		for(int i=0; i<coinsInGame; i++){
			Vector3 temp = mazeInstance.GetCell(mazeInstance.RandomCoordinates).transform.position;
			coinInstances[i] = Instantiate (coinPrefab) as Rotator;
			coinInstances[i].transform.position = new Vector3(temp.x, 0.3f, temp.z);
		}
		Camera.main.clearFlags = CameraClearFlags.Depth;
		coins = playerInstance.coins;
		SetCountText();
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

	void SetCountText(){		
		countText.text = "Score : "+coins.ToString() + " coins";
	}
}
