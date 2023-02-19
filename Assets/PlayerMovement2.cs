using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera myCamera;
   
   [SerializeField] private Transform worldlimit0;
    [SerializeField] private Transform worldlimit1;
    [SerializeField] private Transform worldlimitUp;
    [SerializeField] private Transform worldlimitDown;


    // Update is called once per frame
    void Update()
    {
       

    }

    public void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f ;
        rb.rotation = angle;
      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("player hit");


        if(collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("RAt infected you!");

           // Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("WorldLimit"))
        {
            //gameObject.transform.position = GameObject.FindGameObjectWithTag("WorldLimit1").transform.position ;
            gameObject.transform.position = new Vector3(worldlimit1.position.x - 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }


        if (collision.gameObject.CompareTag("WorldLimit1"))
        {
            gameObject.transform.position = new Vector3(worldlimit0.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (collision.gameObject.CompareTag("WorldLimit2"))
        {
            gameObject.transform.position = Vector3.zero;
        }

        if (collision.gameObject.CompareTag("WorldLimit3"))
        {
            gameObject.transform.position =Vector3.zero;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if(collision.gameObject.CompareTag("WorldLimit"))
        {
            //gameObject.transform.position = GameObject.FindGameObjectWithTag("WorldLimit1").transform.position ;
            gameObject.transform.position = new Vector3(worldlimit1.position.x - 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }

      if(collision.gameObject.CompareTag("WorldLimit1"))
        {
            gameObject.transform.position = new Vector3(worldlimit0.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }*/
      
        /*if(collision.gameObject.CompareTag("WorldLimit2"))
        {
            gameObject.transform.position = new Vector3(worldlimitUp.position.y , gameObject.transform.position.x,gameObject.transform.position.z);
        }
        
         if(collision.gameObject.CompareTag("WorldLimit3"))
        {
            gameObject.transform.position = new Vector3(worldlimitDown.position.y,gameObject.transform.position.x,gameObject.transform.position.z);
        }*/


     

    }

    
}
