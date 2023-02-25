using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public static bool isEnemyKilled = false;
    Path path;
    int currentWaypoint = 0;
    bool isEndofPath = false;
    private float magnetspeed = 5f;

    public Transform enemy;
    PlayerMovement2 playerdeath;

    Seeker seeker;
    Rigidbody2D rb;
   [SerializeField] GameObject nova;
    

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

      
        
            target = GameObject.Find("PlayerShip").transform;


      
            
        
      
        
       
    
    }

    void  UpdatePath()
    {
        if (seeker.IsDone() && target != null)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

      
    }
    private void OnPathComplete(Path p)
    {
       if(!p.error)
        {
            path = p;
            currentWaypoint = 0;

        }
    }

    // Update is called once per frame
     void FixedUpdate()
    {
        FlipEnemy();
       
    }

    private void FlipEnemy()
    {

      
        if (path == null)
        {
            return;
        }


        if (currentWaypoint >= path.vectorPath.Count)
        {
            isEndofPath = true;
            return;
        }
        else
        {
            isEndofPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;


        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        if (force.x >= 0.01f && enemy != null)
        {
         
            
                enemy.localScale = new Vector3(-1f, 1f, 1f);
            

        }
        else if (force.x <= -0.01f && enemy != null)
        {


            enemy.localScale = new Vector3(1f, 1f, 1f);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Nova"))
        {
           
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nova.transform.position, magnetspeed * Time.deltaTime);
        }
    }
}
