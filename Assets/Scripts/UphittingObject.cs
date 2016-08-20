using UnityEngine;
using System.Collections;

public class UphittingObject : HittableObject{


	// Use this for initialization
	protected override void Start () {
        base.Start();
        hitFromLeft = (new Vector2(1, 10)).normalized;
        hitFromRight = (new Vector2(-1, 10)).normalized;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
