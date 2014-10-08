using UnityEngine;
using System.Collections;

public class TutorialReachPoint : MonoBehaviour  {
	public KeyCode on;
	public KeyCode off;
	public Body body;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(this.on)){
			this.body.ReachFor(transform.position);
		}
		if(Input.GetKeyDown(this.off)){
			this.body.ReachStop();
		}
	}
}

