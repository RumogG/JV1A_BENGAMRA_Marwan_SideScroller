using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim.SetTrigger("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
