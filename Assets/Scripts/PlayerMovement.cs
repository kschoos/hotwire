using UnityEngine;
using System.Collections;

public class PlayerMovement : MovingObject {

    int direction = 1;

	// Update is called once per frame
	protected override void Update () {

        float velocity = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            Slash();
        }
         
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        Move(velocity);

        direction = velocity != 0 ? (int) Mathf.Sign(velocity) : direction;
        Face(direction);

        base.Update();
	}


    void Slash()
    {
        animator.SetTrigger("playerAttack");
    }
}
