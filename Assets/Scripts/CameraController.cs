using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private bool isFirstPerson;

	// Use this for initialization
	void Start () {
		isFirstPerson = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.P)) {
			transform.Translate (Vector3.up);
		} else if (Input.GetKeyDown (KeyCode.Semicolon)){
			transform.Translate (Vector3.down);
		} else if (Input.GetKeyDown (KeyCode.LeftBracket)){
			transform.Rotate (Vector3.left);
		} else if (Input.GetKeyDown (KeyCode.Quote)){
			transform.Rotate (Vector3.right);
		} else if (Input.GetKeyDown (KeyCode.C)) {
			if(isFirstPerson){
				isFirstPerson = false;
				transform.localPosition = new Vector3(0f, 8f, -3f);
				transform.localRotation = Quaternion.Euler(new Vector3(30f, 0f, 0f));
			}else{
				isFirstPerson = true;
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.Euler(Vector3.zero);
			}
		}
	}
}
