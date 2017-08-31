using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	
	public string name;
	public string stats;
	public string description;
	public int id;
	public int stock;

	public Item()
	{
		
	}

	public void AddStock(int i)
	{
		if (i < 0)
		{
			return;
		}

		stock += i;

		if (stock < 0)
		{
			stock = 0;
		}
	}

	public void Print()
	{
		Debug.Log ("Item : " + name + ", " + id + ", " + stock);
	}
}