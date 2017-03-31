using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationHandler : MonoBehaviour {

	public Text cube3Dposition;
	public Text pluginOutput;

	private Vector3 privPosition;
	
	// Update is called once per frame
	void Update () {
		// if the position of the object changed, update the information
		if (privPosition != transform.position) {
			privPosition = transform.position;
			UpdateUI ();
		}
	}

	// Updates the UI with data from ViSP
	private void UpdateUI() {
		cube3Dposition.text = transform.position.ToString ();
		pluginOutput.text = ViSPpluginAdapter.GetProjection (transform.position);
	}
}
