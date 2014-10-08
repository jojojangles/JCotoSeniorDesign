using UnityEngine;
using System.Collections;

public class TutorialLookPoint : MonoBehaviour {
	public KeyCode on;
	public KeyCode off;
	public Body body;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(this.on)){
			this.body.HeadLookAt(transform.position);
		}
		if(Input.GetKeyDown(this.off)){
			this.body.HeadLookStop();
		}
	}
}
