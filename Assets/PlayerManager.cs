using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Dictionary<int, Item> inventory;
	public List<Item> nearby;

	void Start()
	{
		inventory = new Dictionary<int, Item> ();
		nearby = new List<Item> ();
	}

	public void AddItem(Item item)
	{
		// if item already exists in inventory, increment stock
		if (inventory.ContainsKey (item.id))
		{
			Item temp;
			inventory.TryGetValue (item.id, out temp);
			temp.AddStock (item.stock);
			return;
		}

		inventory.Add (item.id, item);
	}

	public void Collect()
	{
		foreach (Item item in nearby)
		{
			AddItem (item);
			Destroy (item.gameObject);
		}
		nearby.Clear ();
	}

	public void PrintInventory()
	{
		foreach (Item item in inventory.Values)
		{
			item.Print ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item")
		{
			// is it possible for duplicates?
			nearby.Add (other.GetComponent<Item>());
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Item")
		{
			nearby.Remove (other.GetComponent<Item> ());
		}
	}
}
