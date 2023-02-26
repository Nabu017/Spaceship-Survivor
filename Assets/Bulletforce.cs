using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bulletforce : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 20f;
    Worldlimit1position worlimit1;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * 5f;
      
        Destroy(gameObject, 3);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<RatHealth>();
        if(enemy)
        {
         
            enemy.Damage();
        
            Destroy(gameObject);
        }

        var enemy2 = collision.GetComponent<WormHealth>();
        if(enemy2)
        {
            
            enemy2.Damage();
          
            Destroy(gameObject);
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("WorldLimit") || collision.gameObject.CompareTag("WorldLimit1") || collision.gameObject.CompareTag("WorldLimit2") || collision.gameObject.CompareTag("WorldLimit3"))
        {
            Destroy(gameObject);
        }

                
    }

}
