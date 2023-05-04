using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform destination;
    GameObject Puck;
    private void Awake()
    { Puck = GameObject.FindGameObjectWithTag("Puck");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puck"))
        {
            if ( Vector2.Distance(Puck.transform.position, transform.position)>0.6f)
            {
                Puck.transform.position= destination.transform.position;
            }
        }
    }
}
