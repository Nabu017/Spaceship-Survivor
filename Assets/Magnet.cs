using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject Nova;
    public float movespeed = 17f;
    // Start is called before the first frame update
    void Start()
    {
        Nova = GameObject.FindGameObjectWithTag("Nova");
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyWorm"))
        {
            

            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }

    }
}


