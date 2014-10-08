using UnityEngine;
using System.Collections;

public class TutorialWaypoint2 : MonoBehaviour {
	public KeyCode code;
	public Body body;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(this.code)){
			this.body.NavGoTo(transform.position);
		}
	}
}
