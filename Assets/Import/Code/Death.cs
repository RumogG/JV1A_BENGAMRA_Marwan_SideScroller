using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject Perso;
    public Transform respawnPoint;
    public float health;
    public Rigidbody2D rb;
    public CapsuleCollider2D cc2d;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trap")
        {
            //Destroy(rb.gameObject);
            animator.SetTrigger("Dead");
        }
    }

    public void Respawn()
    {
        Perso.transform.position = respawnPoint.position;
    }
}
