using UnityEngine;
using System.Collections;

public class TutorialWaypoint : MonoBehaviour {
	public KeyCode code;
	public UnitySteeringController controller;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(this.code)){
			this.controller.Target = transform.position;
		}
	}
}
