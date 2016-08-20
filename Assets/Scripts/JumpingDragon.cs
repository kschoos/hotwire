using UnityEngine;
using System.Collections;

public class JumpingDragon : AI {

    public float jumpPause;

    protected override void Start()
    {
        StartCoroutine("JumpAround");
        base.Start();
    }

    IEnumerator JumpAround()
    {
        while (true)
        {
            Jump();
            yield return new WaitForSeconds(jumpPause);
        }
    }
}
