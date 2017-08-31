using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public GameObject[] slots;
	public GameObject selector;
	public TextMesh item_name;
	public TextMesh item_stats;
	public TextMesh item_description;
	int select_index;
	List<Item> inventory;

	public enum DIRECTION {UP, DOWN, LEFT, RIGHT};

	void Start()
	{
		select_index = 11;
		inventory = new List<Item> ();
	}

	public void AddItem(Item item)
	{
		// if item already exists in inventory, increment stock
		foreach (Item i in inventory)
		{
			if (item.id == i.id)
			{
				i.AddStock (item.stock);
				return;
			}
		}

		// otherwise add into list
		inventory.Add (item);
	}

	public void ShowInventory()
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			//Instantiate ();
			//inventory[i].id;
		}
	}

	// for debugging
	public void PrintInventory()
	{
		foreach (Item item in inventory)
		{
			item.Print ();
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
	}
}
