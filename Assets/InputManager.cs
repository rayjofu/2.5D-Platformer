using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public GameObject camera;
	public PlayerManager pm;
	public GameObject menu;
	public InventoryManager im;

	public enum GAMESTATE {ACTIVE, MENU};

	GAMESTATE state = GAMESTATE.ACTIVE;

	// Use this for initialization
	void Start () {
		state = GAMESTATE.ACTIVE;
		menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		// move camera forward (active)
		if (Input.GetKey (KeyCode.UpArrow))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				camera.transform.position += new Vector3 (0, 0, 5) * Time.deltaTime;
			}
		}
		// move selector up (menu)
		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.UP);
			}
		}

		// move camera backward (active)
		if (Input.GetKey (KeyCode.DownArrow))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				camera.transform.position -= new Vector3 (0, 0, 5) * Time.deltaTime;
			}
		}
		// move selector down (menu)
		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.DOWN);
			}
		}

		// move camera left (active)
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				camera.transform.position -= new Vector3 (5, 0, 0) * Time.deltaTime;
			}
		}
		// move selector left (menu)
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.LEFT);
			}
		}

		// move camera right (active)
		if (Input.GetKey (KeyCode.RightArrow))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				camera.transform.position += new Vector3 (5, 0, 0) * Time.deltaTime;
			}
		}
		// move selector right (menu)
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.RIGHT);
			}
		}

		// move player up (active)
		if (Input.GetKey (KeyCode.W))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				pm.Move (PlayerManager.DIRECTION.UP);
			}
		}
		// move selector up (menu)
		if (Input.GetKeyDown (KeyCode.W))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.UP);
			}
		}
			
		// move player down (active)
		if (Input.GetKey (KeyCode.S))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				pm.Move (PlayerManager.DIRECTION.DOWN);
			}
		}
		// move selector down (menu)
		if (Input.GetKeyDown (KeyCode.S))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.DOWN);
			}
		}

		// move player left (active)
		if (Input.GetKey (KeyCode.A))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				pm.Move (PlayerManager.DIRECTION.LEFT);
			}
		}
		// move selector left (menu)
		if (Input.GetKeyDown (KeyCode.A))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.LEFT);
			}
		}

		// move player right (active)
		if (Input.GetKey (KeyCode.D))
		{
			if (state == GAMESTATE.ACTIVE)
			{
				pm.Move (PlayerManager.DIRECTION.RIGHT);
			}
		}
		// move selector left (menu)
		if (Input.GetKeyDown (KeyCode.D))
		{
			if (state == GAMESTATE.MENU)
			{
				im.MoveSelector (InventoryManager.DIRECTION.RIGHT);
			}
		}

		// jump/confirm
		if (Input.GetKeyDown (KeyCode.Space))
		{
			switch (state)
			{
			case GAMESTATE.ACTIVE:
				pm.Jump();
				break;
			case GAMESTATE.MENU:
				break;
			}
		}

		// interact
		if (Input.GetKeyDown (KeyCode.F))
		{
			switch (state)
			{
			case GAMESTATE.ACTIVE:
				pm.Collect();
				break;
			case GAMESTATE.MENU:
				break;
			}
		}

		// toggle menu
		if (Input.GetKeyDown (KeyCode.I))
		{
			menu.SetActive (!menu.activeSelf);
			if (menu.activeSelf)
			{
				state = GAMESTATE.MENU;
			} else
			{
				state = GAMESTATE.ACTIVE;
			}
		}
	}
}