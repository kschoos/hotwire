using UnityEngine;
using Spine.Unity;
using System.Collections;

public class DragonJump : MonoBehaviour {

    public float jumpHeight = 5;

    private Rigidbody2D body;
    private SkeletonAnimation skeletonAnimation;
    [SpineEvent] public string startEvent; 

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.state.Event += HandleEvent;
	}

	
	// Update is called once per frame
	void Update () {
	
	}

    void HandleEvent (Spine.AnimationState state, int trackIndex, Spine.Event e) {
      // Play some sound if the event named "footstep" fired.
      if (e.Data.Name == startEvent) {
            body.AddForce(new Vector2(0, 1) * jumpHeight, ForceMode2D.Impulse);
      }
   }
}
