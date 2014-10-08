using UnityEngine;
using System.Collections;

public class TutorialCoordinator : ShadowCoordinator {
	protected ShadowTransform[] buffer1 = null;
	protected ShadowTransform[] buffer2 = null;
	protected ShadowLeanController lean = null;
	protected ShadowAnimationController anim = null;
	protected Slider weight;

	// Use this for initialization
	void Start() {
		this.buffer1 = this.NewTransformArray();
		this.buffer2 = this.NewTransformArray();
		this.lean = this.GetComponent<ShadowLeanController>();
		this.anim = this.GetComponent<ShadowAnimationController>();
		this.weight = new Slider(4.0f);
		this.ControlledStartAll();
	}
	
	// Update is called once per frame
	void Update() {
		this.weight.Tick(Time.deltaTime);

		this.UpdateCoordinates();

		//update lean controller, write shadow to buffer
		this.lean.ControlledUpdate();
		this.lean.Encode (this.buffer1);

		//update anim controller, write shadow to buffer
		this.anim.ControlledUpdate();
		this.anim.Encode(this.buffer2, new Whitelist<string>("Spine1")); 


		if(Input.GetKey(KeyCode.T)){
			this.anim.AnimPlay("dismissing_gesture");
			this.weight.ToMin();
		}

		if(anim.IsPlaying() == false){
			this.weight.ToMax();
		}

		BlendSystem.Blend(
			this.buffer1,
			new BlendPair(this.buffer1, this.weight.Value),
			new BlendPair(this.buffer2, this.weight.Inverse));

		Shadow.ReadShadowData(
			this.buffer1,
			this.transform.GetChild(0),
			this);
	}
}
