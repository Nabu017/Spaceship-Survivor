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
    }

}
