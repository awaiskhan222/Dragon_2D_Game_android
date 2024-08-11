using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthColactibles : MonoBehaviour
{
    private PlayerHealth playerhealth;
    private float health = 1;

    private void Start()
    {
        playerhealth = GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("Touch");
            collision.GetComponent<PlayerHealth>().TakeHealth(health);
            Destroy(gameObject);
            /*playerhealth.TakeHealth(1);*/
        }
        
    }

}
