using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHit : HittableObject{

    public Text healthText;

    public float invulnerabilityDuration = 1f;
    public float blinkPause = 0.2f;
    public int blinkCount = 3;

    private GameController gameController;
    private bool canTakeDamage = true;


    protected override void Start()
    {
        base.Start();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected override void TakeDamage(float t_damage)
    {
        if (!canTakeDamage) { return; }

        healthText.text = health + "/" + maxHealth;
        base.TakeDamage(t_damage);
        StartCoroutine(Blink(blinkCount));
    }

    IEnumerator Blink(int times)
    {
        canTakeDamage = false;
        for (int i = 0; i < times; i++)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(blinkPause);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(blinkPause);
        }
        canTakeDamage = true;
    }

    protected override void Die()
    {
        gameController.LoadStartMenu();
        base.Die();
    }
}
