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
    public int totalHealth;
    public const int  startinghealth = 500;
    const string placeholder = "Player Health: ";
 public int EnergyCounter = 0;
    [SerializeField] GameObject EnergyObject;
  [SerializeField]  SceneLoaderAdressables sceneloader;

    public string playername = "Player1";

    public Text KillcounterText;
    const string placeholder2 = "Energy Found : ";
   [SerializeField] public RatHealth deathchecker;
    private int BossDamage;

    //private int lives = 3;
    private void Start()
    {

        Health = totalHealth;
        loadPlayer();
        Debug.Log("Health: " + Health);
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
            // SceneManager.LoadScene("GameOver");
            SavePlayer();
            sceneloader.Load("Scene2");
           
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
       if(collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("The Boss is here!");
        }
        if(collision.gameObject.CompareTag("BossBullet"))
        {
            BossDamage = Random.RandomRange(20, 100);
            Debug.Log("Boss damage : " + BossDamage);
            Health -= BossDamage;
            


        }
    }

   
    public void BuyHealthUpgrade()
    {
        Health += 100;
    }


   
    
}
