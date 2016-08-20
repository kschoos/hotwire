using UnityEngine;
using System.Collections;

public class HittableObject : MonoBehaviour {

    public float weight;
    public float maxHealth = 100;
    public GameObject pow;

    public bool friendlyFire = false;

    protected float health;
    protected Vector2 hitFromRight, hitFromLeft;

    protected Rigidbody2D body;

    private MovingObject movingObject;

	// Use this for initialization
	protected virtual void Start () {
        health = maxHealth;
        movingObject = GetComponent<MovingObject>();
        body = GetComponent<Rigidbody2D>();
        hitFromLeft = new Vector2(1, 1);
        hitFromRight = new Vector2(-1, 1);
	}


    protected virtual void Die()
    {
        Instantiate(pow, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
	
    protected virtual void TakeDamage(float t_damage)
    {
        health -= t_damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D t_collision)
    {
        if(t_collision.gameObject.tag == "Border")
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D t_collider)
    {
        if((t_collider.tag == "Weapon" && tag == "Enemy" && t_collider.name == "Sword") ||
           (t_collider.tag == "Weapon" && tag == "Player") ||
           (t_collider.tag == "Weapon" && tag == "Enemy" && friendlyFire))
        {
            Debug.Log(gameObject.name +", "+ t_collider.name);
            Vector2 enemyPosition = t_collider.transform.root.transform.position;
            Weapon weapon = t_collider.gameObject.GetComponent<Weapon>();

            if(transform.position.x - enemyPosition.x < 0)
            {
                if (movingObject)
                {
                    movingObject.SetHasControl(false);
                }
                body.AddForce(hitFromRight * 1/weight, ForceMode2D.Impulse);
                TakeDamage(weapon.damage);
            } else
            {
                if (movingObject)
                {
                    movingObject.SetHasControl(false);
                }
                body.AddForce(hitFromLeft * 1/weight, ForceMode2D.Impulse);
                TakeDamage(weapon.damage);
            }
        }
    }
}
