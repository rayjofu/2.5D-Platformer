using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour {

	public Transform exit;

	public Vector3 GetExitPosition()
	{
		return exit.position;
	}
}