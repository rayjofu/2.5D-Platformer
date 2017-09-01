using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public GameObject[] slots;
	public GameObject selector;
	public TextMesh item_name;
	public TextMesh item_stats;
	public TextMesh item_description;
	public ItemDatabase db;
	int select_index;
	List<Item> inventory;
	List<GameObject> inventory_object;

	public enum DIRECTION {UP, DOWN, LEFT, RIGHT};

	void Awake()
	{
		select_index = 11;
		inventory = new List<Item> ();
		inventory_object = new List<GameObject> ();
	}

	public void AddItem(Item item)
	{
		// if item already exists in inventory, increment stock
		for (int i = 0; i < inventory.Count; i++)
		{
			if (item.id == inventory[i].id)
			{
				inventory[i].AddStock (item.stock);
				return;
			}
		}

		// otherwise add into list
		inventory.Add (item);
		int index = ConvertIndexFromInventoryToSlot(inventory_object.Count);
		GameObject obj = Instantiate (db.GetPrefab (item.id), slots [index].transform.position, Quaternion.identity);
		obj.transform.parent = slots [index].transform;
		obj.SetActive (slots [index].activeSelf);
		inventory_object.Add(obj);
	}

	// NOT SCALABLE
	public int ConvertIndexFromSlotToInventory(int index)
	{
		if (11 <= index && index <= 15)
		{
			return index - 11;
		}
		else if (19 <= index && index <= 23)
		{
			return index - 14;
		}
		else if (27 <= index && index <= 31)
		{
			return index - 17;
		}
		else //if (35 <= index && index <= 39)
		{
			return index - 20;
		}
	}

	public int ConvertIndexFromInventoryToSlot(int index)
	{
		return index + 11 + (index / 5) * 8;
	}

	// DOESNT UPDATE ITEM DETAILS
	public void RemoveItem(Item item)
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory [i] == item)
			{
				inventory.RemoveAt (i);
				inventory_object.RemoveAt (i);
				int index = ConvertIndexFromInventoryToSlot (i);
				Destroy(slots [index].transform.GetChild (0).gameObject);
				return;
			}
		}
	}

	public void RemoveItem()
	{
		int index = ConvertIndexFromSlotToInventory (select_index);

		if (index >= inventory.Count)
		{
			return;
		}

		Item item = inventory [index];
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory [i] == item)
			{
				inventory.RemoveAt (i);
				inventory_object.RemoveAt (i);
				index = ConvertIndexFromInventoryToSlot(i);
				Destroy(slots [index].transform.GetChild (0).gameObject);
				return;
			}
		}
	}

	// IMPLEMENT
	public void UpdateItemDetails()
	{

	}

	public void SetItemDetails(string name = "", string stats = "", string description = "")
	{

	}

	// for debugging
	public void PrintInventory()
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			inventory[i].Print ();
		}
	}

	public void MoveSelector(DIRECTION dir)
	{
		if (dir == DIRECTION.UP)
		{
			// out of bounds
			if (0 <= select_index && select_index <= 2)
			{
				return;
			}

			// scroll inventory up
			if (11 <= select_index && select_index <= 15)
			{
				return;
			}

			if (select_index == 24 || select_index == 26 || select_index == 33)
			{
				select_index -= 16;
			} else
			{
				select_index -= 8;
			}
		} 

		else if (dir == DIRECTION.DOWN)
		{
			// out of bounds
			if (32 <= select_index && select_index <= 34)
			{
				return;
			}

			// scroll inventory down
			if (35 <= select_index && select_index <= 39)
			{
				return;
			}

			if (select_index == 8 || select_index == 10 || select_index == 17)
			{
				select_index += 16;
			} else
			{
				select_index += 8;
			}
		}

		else if (dir == DIRECTION.LEFT)
		{
			// out of bounds
			if (select_index == 0 || select_index == 8 || select_index == 17 || select_index == 24 || select_index == 32)
			{
				return;
			}

			// corner case (inventory to legs)
			if (select_index == 19)
			{
				select_index = 17;
			}
			// corner case (right foot to left foot)
			else if (select_index == 26)
			{
				select_index = 24;
			} else
			{
				select_index--;
			}
		}

		else if (dir == DIRECTION.RIGHT)
		{
			// out of bounds
			if (select_index == 15 || select_index == 23 || select_index == 31 || select_index == 39)
			{
				return;
			}

			// corner case (right weapon to inventory)
			if (select_index == 2)
			{
				select_index = 11;
			}
			// corner case (legs to inventory)
			else if (select_index == 17)
			{
				select_index = 19;
			}
			// corner case (left foot to right foot)
			else if (select_index == 24)
			{
				select_index = 26;
			} else
			{
				select_index++;
			}
		}

		selector.transform.position = slots [select_index].transform.position;

		// update item name, stats, description, rarity for selected item
		if (slots [select_index].transform.childCount != 0)
		{
			Item item = slots [select_index].transform.GetChild (0).GetComponent<Item> ();
			item_name.text = item.name;
			item_stats.text = item.stats;
			item_description.text = item.description;
			//item_rarity
		} 
		// otherwise show nothing
		else
		{
			item_name.text = "";
			item_stats.text = "";
			item_description.text = "";
		}
	}
}
