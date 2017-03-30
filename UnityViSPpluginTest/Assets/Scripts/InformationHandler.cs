using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationHandler : MonoBehaviour {

	public Text cube3Dposition;
	public Text pluginOutput;

	private Vector3 privPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (privPosition != transform.position) {
			privPosition = transform.position;
			UpdateUI ();
		}
	}

	private void UpdateUI() {
		cube3Dposition.text = transform.position.ToString ();
	}
}
