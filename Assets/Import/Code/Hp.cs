using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public HpBar hpBar;
    public Animator animator;
    public Rigidbody2D rb;
    public bool inAcid;
    public bool stopDmg;
    public int acideScaling = 1;
    public SpriteRenderer graphics;
    private float invincibilityTimeAfterHit = 3f;
    private float invincibilityFlashDelay = 0.2f;
    private bool isInvincible = false;

    public static Hp instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Hp dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        health = maxHealth;
        hpBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (inAcid == true)
        {
            if (stopDmg == false)
            {
                stopDmg = true;
                StartCoroutine(Acid());
            }
            
        }
        if (!inAcid)
        {
            StopCoroutine(Acid());
        }
    }

    void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            hpBar.setHealth(health);
            if (health <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    void TakeDamageAcid(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            hpBar.setHealth(health);
            if (health <= 0)
            {
                Die();
                return;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "acide")
        {
            inAcid = true;
        }
        if (collision.gameObject.tag == "c1")
        {
            graphics.color = new Color32(170, 207, 166, 255);
        }
        if (collision.gameObject.tag == "c2")
        {
            graphics.color = new Color32(133, 171, 204, 255);
        }
        if (collision.gameObject.tag == "c3")
        {
            graphics.color = new Color32(192, 133, 204, 255);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "acide")
        {
            inAcid = false;
            acideScaling = 1;
        }
        if (collision.gameObject.tag == "c1" && collision.gameObject.tag == "c2" && collision.gameObject.tag == "c3")
        {
            graphics.color = new Color32(255, 255, 255, 255);
        }
        }
 

    IEnumerator Acid()
    {
        acideScaling += 1;
        TakeDamageAcid(acideScaling);
        yield return new WaitForSeconds(1f);
        stopDmg = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trap")
        {
            TakeDamage(100);
            animator.SetTrigger("Dead");
            rb.velocity = Vector3.zero;
        }
    }

    void Die()
    {
            animator.SetTrigger("Dead");
            rb.velocity = Vector3.zero;
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 0f, 0f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}

