using UnityEngine;
using System.Collections;

public class DropperAI : AI {


    public GameObject drop;
    public Transform dropSpawn;
    public float maxDropDelay;
    public float minDropDelay;
    public float y;

    protected override void Start()
    {
        base.Start();
        transform.position = new Vector2(transform.position.x, y);
        StartCoroutine(DropDroplets());
    }

    IEnumerator DropDroplets()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDropDelay, maxDropDelay));
            Instantiate(drop, dropSpawn.position, Quaternion.identity);
        }
    }
	
}
