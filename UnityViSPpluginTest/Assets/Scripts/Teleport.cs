using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Teleports a game object if it fell out of the game scene
public class Teleport : MonoBehaviour {

	[Tooltip ("The position where the object will be teleported")]
	public Vector3 startPosition;
	[Tooltip ("The teleportation trigger based on the Y-axis position of the object")]
	public float teleportTriggerY = -10;

	void Update () {
		if (gameObject.transform.position.y < -10) {
			gameObject.transform.position = startPosition;
		}
	}
}
