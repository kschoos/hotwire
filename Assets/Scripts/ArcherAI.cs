using UnityEngine;
using System.Collections;

public class ArcherAI : MonoBehaviour {

    public GameObject projectile;
    public float shootPause = 1f;
    public float projectileMaxHeight = 1f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine("ShootAround");
    }

    IEnumerator ShootAround()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootPause);
        }
    }


    void Shoot()
    {
        GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        float height = player.position.y - transform.position.y > 0 ? player.position.y - transform.position.y : 1f;
        float vertSpeed = Mathf.Sqrt(2 * Physics2D.gravity.magnitude * height * 2);
        float trajectoryTime = 2 * vertSpeed / Physics2D.gravity.magnitude;
        float horSpeed  = (player.position.x - transform.position.x) / trajectoryTime;
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(horSpeed, vertSpeed);
    }
}
