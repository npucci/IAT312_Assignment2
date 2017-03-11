using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	List<string> items;

	// Use this for initialization
	void Start () {
		items = new List<string> ();
	}

	public int getInventoryCount() {
		return items.Count;
	}

	public void addItem(string itemName) {
		items.Add (itemName);
	}

	public string getItem(string itemName) {
		int position = -1;
		for (int i = 0; i< items.Count; i++) {
			if (items[i] == itemName) {
				position = i; 
			}
		}

		if (position > -1) {
			string throwAway = items [position];
			items.RemoveAt (position);
			return throwAway;
		}
		return "";
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Item item = coll.gameObject.GetComponent<Item> (); 
		if (item != null) {
			addItem (coll.gameObject.name);
			Destroy (coll.gameObject);
		}
	}
}
