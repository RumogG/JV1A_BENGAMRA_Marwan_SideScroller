using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject Perso;
    public Transform respawnPoint;
    public Rigidbody2D rb;
    public CapsuleCollider2D cc2d;
    public Animator animator;
    public bool finito = false;
    public HpBar hpBar;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "portal")
        {
            //Destroy(rb.gameObject);
            animator.SetTrigger("End");
            //rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector3.zero;
            if (finito == true)
            {
                Destroy(Perso);
            }
        }
    }

    public void Respawn()
    {
        Perso.transform.position = respawnPoint.position;
        rb.bodyType = RigidbodyType2D.Dynamic;
        Hp.instance.health = Hp.instance.maxHealth;
        hpBar.setHealth(Hp.instance.health);
    }
}
