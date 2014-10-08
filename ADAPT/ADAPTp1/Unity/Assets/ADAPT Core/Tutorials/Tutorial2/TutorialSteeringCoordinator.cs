using UnityEngine;
using System.Collections;

public class TutorialSteeringCoordinator : ShadowCoordinator {
	protected ShadowTransform[] buffer1 = null;
	protected ShadowLocomotionController loco = null;
	// Use this for initialization
	void Start () {
		this.buffer1 = this.NewTransformArray();
		this.loco = this.GetComponent<ShadowLocomotionController>();
		this.ControlledStartAll();
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateCoordinates(); //moves root pos of each shadow to match display model
		this.loco.ControlledUpdate(); //update lean controller write shadow into buff
		this.loco.Encode(this.buffer1);

		Shadow.ReadShadowData(//write shadow buffer to display model starting at hips
		                      this.buffer1,
		                      this.transform.GetChild(0),
		                      this);
	}
}
