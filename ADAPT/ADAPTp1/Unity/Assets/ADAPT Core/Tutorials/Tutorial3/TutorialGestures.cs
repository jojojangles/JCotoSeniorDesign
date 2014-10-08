using UnityEngine;
using System.Collections;

public class TutorialGestures : MonoBehaviour {
	protected Body body;
	// Use this for initialization
	void Start () {
		this.body = this.GetComponent<Body>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) == true)
			this.body.AnimPlay("dismissing_gesture");
		if (Input.GetKeyDown(KeyCode.F) == true)
			this.body.AnimPlay("being_cocky");
	}
}
