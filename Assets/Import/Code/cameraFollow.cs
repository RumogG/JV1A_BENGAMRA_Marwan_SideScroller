using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;

    void Update()
    {
        //fais en sorte de modifier la pos de la cam de tant de pxl en tant de temsp lorsque la pos du joueur bouge
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
