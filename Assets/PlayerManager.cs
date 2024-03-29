﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public InventoryManager im;
	public float moveSpeed = 5;
	public float jumpSpeed = 50;
	List<Item> nearby;
	List<Transporter> transporters;
	Rigidbody body;

	public enum DIRECTION { UP, DOWN, LEFT, RIGHT };

	void Start()
	{
		nearby = new List<Item> ();
		transporters = new List<Transporter> ();
		body = this.GetComponent<Rigidbody> ();
	}
		
	/*
	 *	player actions
	 *
	*/
	public void Move(DIRECTION dir)
	{
		switch (dir)
		{
		case DIRECTION.UP:
			Transport (dir);
			break;
		case DIRECTION.DOWN:
			Transport (dir);
			break;
		case DIRECTION.LEFT:
			this.transform.position -= new Vector3 (moveSpeed, 0, 0) * Time.deltaTime;
			break;
		case DIRECTION.RIGHT:
			this.transform.position += new Vector3 (moveSpeed, 0, 0) * Time.deltaTime;
			break;
		}
	}

	public void Transport(DIRECTION dir)
	{
		if (transporters.Count == 0)
		{
			//			Debug.Log ("PlayerManager.cs : Teleport() : Transporter is null");
			return;
		}
			
		for (int i = 0; i < transporters.Count; i++)
		{
			Vector3 newPos = transporters[i].GetExitPosition ();
			if (dir == DIRECTION.UP && this.transform.position.z < newPos.z)
			{
				this.transform.position = transporters[i].GetExitPosition ();
				return;
			} else if (dir == DIRECTION.DOWN && this.transform.position.z > newPos.z)
			{
				this.transform.position = transporters[i].GetExitPosition ();
				return;
			}
		}
	}

	public void Jump()
	{
		body.AddForce (Vector3.up * jumpSpeed);
	}

	public void Collect()
	{
		for (int i = 0; i < nearby.Count; i++)
		{
			im.AddItem (nearby[i]);
			Destroy (nearby[i].gameObject);
		}
		nearby.Clear ();
	}

	/*
	 * 	collisions
	 * 
	*/
	void OnTriggerEnter(Collider other)
	{
//		Debug.Log ("trigger enter with " + other.tag);
		if (other.tag == "Item")
		{
			// is it possible for duplicates?
			nearby.Add (other.GetComponent<Item> ());
		} else if (other.tag == "Transporter")
		{
			// is it possible for duplicates?
			transporters.Add(other.gameObject.GetComponent<Transporter> ());
		}
	}

	void OnTriggerExit(Collider other)
	{
//		Debug.Log ("trigger exit with " + other.tag);
		if (other.tag == "Item")
		{
			nearby.Remove (other.GetComponent<Item> ());
		} else if (other.tag == "Transporter")
		{
			transporters.Remove(other.gameObject.GetComponent<Transporter> ());
		}
	}
}