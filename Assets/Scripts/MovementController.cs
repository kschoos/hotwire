using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float rotation;
    public Transform mooble;

    private int FORWARD = 1, BACKWARD = -1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Horizontal") > 0)
        {
            RotateMooble(FORWARD);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            RotateMooble(BACKWARD);
        }
	}

    void RotateMooble(int direction)
    {
        mooble.Rotate(0, 0, rotation * direction);
    }
}
