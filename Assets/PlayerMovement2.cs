using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Source : https://www.youtube.com/watch?v=LNLVOjbrQj4&t=801s&ab_channel=Brackeys 

public class PlayerMovement2 : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera myCamera;
    public float angle;
  [SerializeField]  public int Health = 100;
   [SerializeField] private Transform worldlimit0;
    [SerializeField] private Transform worldlimit1;
    [SerializeField] private Transform worldlimitUp;
    [SerializeField] private Transform worldlimitDown;
    [SerializeField] private Transform StartingPoint;
    public Text healthText;
    const string placeholder = "Player Health: ";
 public int EnergyCounter = 0;
    [SerializeField] GameObject EnergyObject;

    public string playername = "Player1";

    public Text KillcounterText;
    const string placeholder2 = "Energy Found : ";
   [SerializeField] public RatHealth deathchecker;

    //private int lives = 3;
    private void Start()
    {
        loadPlayer();
    }
    // Update is called once per frame
    void Update()
    {
      

    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void loadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Health = data.hp;
        EnergyCounter = data.energy;
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
         angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f ;
        rb.rotation = angle;

        if(Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
     
        healthText.text = placeholder + Health.ToString();
        KillcounterText.text = placeholder2 + EnergyCounter.ToString();


    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
      

        if(collision.gameObject.CompareTag("Projectile"))
        {

            //gameObject.transform.position = new Vector3(StartingPoint.position.x,StartingPoint.position.y, StartingPoint.position.z);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Health -= 10;

            Debug.Log(Health);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {

            Health -= 5;
            Debug.Log(Health);
            Destroy(collision.gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );


        }

        if(collision.gameObject.CompareTag("Energy"))
        {
            Debug.Log("Energy Hit!");
            EnergyCounter+= 1;


        }
      /*  if (collision.gameObject.CompareTag("WorldLimit"))
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
            gameObject.transform.position = new Vector3(StartingPoint.position.x, StartingPoint.position.y, StartingPoint.position.z);
        }

        if (collision.gameObject.CompareTag("WorldLimit3"))
        {
            gameObject.transform.position = new Vector3(StartingPoint.position.x, StartingPoint.position.y, StartingPoint.position.z);
        }*/
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
