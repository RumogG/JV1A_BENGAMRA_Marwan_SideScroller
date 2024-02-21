using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOnSaw : MonoBehaviour
{
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("killed_player");
        }
    }
}
    

