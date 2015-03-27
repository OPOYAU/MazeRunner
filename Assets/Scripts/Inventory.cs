using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item> inventory = new List<Item>();
	public ItemDatabase database;

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase> ();
		inventory.Add (database.items [0]);
		inventory.Add (database.items [1]);
		inventory.Add (database.items [2]);
		inventory.Add (database.items [3]);
		inventory.Add (database.items [4]);
		inventory.Add (database.items [5]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
