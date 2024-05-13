using System;
using UnityEngine;

public class DartBoard : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("YEAH HIT HIT HIT");
        Destroy(collision.gameObject);
        Destroy(gameObject);
        
    }
}