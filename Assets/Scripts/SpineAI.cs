using UnityEngine;
using System.Collections;

public class SpineAI : SpineMovingObject{

    public float attackRange;
    public float attackPause;

    private GameObject player;
    private bool isAttacking;

    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update () {
        MoveTowardPlayer();
        base.Update();
	}


    void MoveTowardPlayer()
    {
        float distance = player.transform.position.x - transform.position.x;
        int direction = (int)Mathf.Sign(distance);

        Face(direction);

        if (hasControl && Mathf.Abs(distance) > attackRange)
        {
            isAttacking = false;
            Move(direction);
        }

        else if(hasControl && Mathf.Abs(distance) < attackRange)
        {
            isAttacking = true;
        }
    }
}
