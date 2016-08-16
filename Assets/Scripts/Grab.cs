using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

    public Collider2D handleCollider;
    public Rigidbody2D mooble;
    public float movementForceMultiplier = 100;

    private Vector3 lastMousePosition = Vector3.zero;
    private bool isGrabbed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            Collider2D col;
            col = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f);

            if(col == handleCollider)
            {
                isGrabbed = true;
            }
        }

        if(Input.GetButtonUp("Fire1") && isGrabbed)
        {
            isGrabbed = false;
            lastMousePosition = Vector3.zero;
        }

        if (isGrabbed)
        {
            MoveHandleToMousePosition();
        }

	}

    void MoveHandleToMousePosition(){
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if( lastMousePosition == Vector3.zero)
        {
            lastMousePosition = pos;
        }
        mooble.AddForce((pos - lastMousePosition) * movementForceMultiplier);
        lastMousePosition = pos;
    }
}
