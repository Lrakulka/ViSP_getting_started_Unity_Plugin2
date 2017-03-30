using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Method teleports game object if it fell out of the game scene
public class Teleport : MonoBehaviour {

	public Vector3 startPosition;

	public float teleportTriggerY = -10;

	void Update () {
		if (gameObject.transform.position.y < -10) {
				gameObject.transform.position = startPosition;
			}
	}
}
