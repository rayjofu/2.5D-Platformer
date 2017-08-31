using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
	public GameObject[] item;

	public GameObject GetPrefab(int id)
	{
		return item [id];
	}
}
