using UnityEngine;
using System.Collections;

public class ShadowLeanController : ShadowController {

	public Transform spine;

	// Use this for initialization
	public override void ControlledStart () {
		this.spine = this.shadow.GetBone(this.spine);
	}
	
	// Update is called once per frame
	public override void ControlledUpdate () {
		Vector3 rot = spine.rotation.eulerAngles;

		if(Input.GetKey(KeyCode.R)) {
			rot.x -= Time.deltaTime * 50.0f;
		}
		if(Input.GetKey(KeyCode.F)) {
			rot.x += Time.deltaTime * 50.0f;
		}

		spine.rotation = Quaternion.Euler(rot);
	}
}
