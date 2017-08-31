using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public GameObject camera;
	public GameObject player;
	PlayerManager pm;

	// Use this for initialization
	void Start () {
		pm  = player.GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (Input.GetKey (KeyCode.Q))
		{
			camera.transform.position -= new Vector3 (5, 0, 0) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.E))
		{
			camera.transform.position += new Vector3 (5, 0, 0) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A))
		{
			player.transform.position -= new Vector3 (5, 0, 0) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D))
		{
			player.transform.position += new Vector3 (5, 0, 0) * Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.Space))
		{
			player.transform.position += new Vector3 (0, 50, 0) * Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.F))
		{
			pm.Collect();
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			pm.PrintInventory();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
//			pm.Transport ();
		}
	}
}
