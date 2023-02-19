using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletforce : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 20f;
    Worldlimit1position worlimit1;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("WorldLimit") || collision.gameObject.CompareTag("WorldLimit1") || collision.gameObject.CompareTag("WorldLimit2") || collision.gameObject.CompareTag("WorldLimit3"))
        {
            Destroy(gameObject);
        }

                
    }

}
