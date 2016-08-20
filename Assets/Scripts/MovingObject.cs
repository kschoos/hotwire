using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

    public float movementSpeed = 5f;
    public float jumpHeight = 3f;

    public float airDrag = 0f;
    public float groundDrag = 3f;
    public int   baseDirection = 1;

    public bool hasAirControl;

    protected Animator animator;
    protected Rigidbody2D body;

    protected bool isGrounded = false;
    protected bool hasControl = true;

    private bool isJumping = false;

	// Use this for initialization
	protected virtual void Start () {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
	}

    protected virtual void Update()
    {
        if (!isGrounded)
        {
            body.drag = airDrag;
        } else
        {
            if (!hasControl)
            {
            }
            body.drag = groundDrag;
        }
    }
	

    public void Face(int t_direction)
    {
        if (animator)
        {
            animator.transform.localScale = new Vector2(t_direction * baseDirection, 1);
        }
    }

    public void Move(float t_velocity)
    {
        if (hasControl)
        {
            if (animator)
            {
               animator.SetFloat("speed", Mathf.Abs(t_velocity));
            }
           body.velocity = new Vector2(t_velocity * movementSpeed, body.velocity.y);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            isJumping = true;
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    public void SetHasControl(bool t_hasControl)
    {
        hasControl = t_hasControl;
    }

    void OnCollisionEnter2D(Collision2D t_collision)
    {
        if(t_collision.collider.tag == "Ground")
        {
            SetHasControl(true);
            isJumping = false;
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D t_collision)
    {
        if(t_collision.collider.tag == "Ground")
        {
            SetHasControl(false | isJumping);
            isGrounded = false;
        }
    }

}
