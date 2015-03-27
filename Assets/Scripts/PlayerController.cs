using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private MazeCell currentCell;
	private bool isFaceNorth;
	private bool isFaceSouth;
	private bool isFaceEast;
	private bool isFaceWest;
	public int coins;
	private int deltaCoin;


	void Start(){
		coins = 0;
		deltaCoin = 0;

		isFaceNorth=true;
		isFaceSouth=false;
		isFaceEast=false;
		isFaceWest=false;
		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
	}

	public void SetLocation (MazeCell cell) {
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		transform.localPosition += new Vector3 (0f, 0.3f, 0f);
	}

	private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
	}

	private void Update () {
		//update Player position
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			//Move (MazeDirection.North);
			if(isFaceNorth) Move (MazeDirection.North);
			else if(isFaceSouth) Move (MazeDirection.South);
			else if(isFaceEast) Move (MazeDirection.East);
			else if(isFaceWest) Move (MazeDirection.West);
		} else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
			//Move (MazeDirection.South);
			if(isFaceNorth) Move (MazeDirection.South);
			else if(isFaceSouth) Move (MazeDirection.North);
			else if(isFaceEast) Move (MazeDirection.West);
			else if(isFaceWest) Move (MazeDirection.East);
		} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			if(isFaceNorth){
				isFaceNorth = false;
				isFaceEast = true;
			}
			else if(isFaceSouth){
				isFaceSouth	= false;
				isFaceWest = true;
			}
			else if(isFaceEast){
				isFaceEast = false;
				isFaceSouth = true;
			}
			else if(isFaceWest){
				isFaceWest = false;
				isFaceNorth = true;
			}
			transform.Rotate(new Vector3(0f, 90f, 0f));
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
			//Move (MazeDirection.West);
			if(isFaceNorth){
				isFaceNorth = false;
				isFaceWest = true;
			}
			else if(isFaceSouth){
				isFaceSouth	= false;
				isFaceEast = true;
			}
			else if(isFaceEast){
				isFaceEast = false;
				isFaceNorth = true;
			}
			else if(isFaceWest){
				isFaceWest = false;
				isFaceSouth = true;
			}
			transform.Rotate(new Vector3(0f, -90f, 0f));
		} else if (Input.GetKeyDown (KeyCode.E)) {
			if(isFaceNorth) Move (MazeDirection.East);
			else if(isFaceSouth) Move (MazeDirection.West);
			else if(isFaceEast) Move (MazeDirection.South);
			else if(isFaceWest) Move (MazeDirection.North);
		} else if (Input.GetKeyDown (KeyCode.Q)) {
			if(isFaceNorth) Move (MazeDirection.West);
			else if(isFaceSouth) Move (MazeDirection.East);
			else if(isFaceEast) Move (MazeDirection.North);
			else if(isFaceWest) Move (MazeDirection.South);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Coin") {
			Destroy(other.gameObject);
			deltaCoin++;
			CountCoin();
		}
	}

	void CountCoin(){
		if(deltaCoin==4){
			deltaCoin = 0;
			coins++;
		}
	}
}