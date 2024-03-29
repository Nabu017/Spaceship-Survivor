using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Sources :https://www.youtube.com/watch?v=LNLVOjbrQj4&t=801s&ab_channel=Brackeys et Professeur Soumpholphakdy
public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public Transform firepointNova;
    public GameObject prefab;
    public GameObject LaserBeam;
    public float bulletforce = 20f;
    public float SupernovaForce = 30f;
    public int novaCount = 3;

    ObjectPool objectpooler;

   [SerializeField] public bool poweredGun = false;

    private int bulletCount = 0;
    public Text SupernovaText;
    const string SupernovaPlaceholder = "SuperNova left : ";
    private bool BuyUpgrade = false;
    Scene currentScene;
    string scene;
   



    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        scene = currentScene.name;
        Debug.Log(scene);
        objectpooler = ObjectPool.Instance;
        //loadShooting();
        Debug.Log("Nova count : " + novaCount);
    }

    // Update is called once per frame
    void Update()
    {
       




        if (Input.GetButtonDown("Jump") && novaCount > 0 && scene != "GameHub")
        {
            novaCount--;
            ShootLaserBeam();
        }

        if(poweredGun == false)
        {
            if (Input.GetButtonDown("Fire1") && scene != "GameHub")
            {
                ShootNormalBullets();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && scene != "GameHub")
            {
                ShootNormalBullets();
            }
        }
     
      
      
    }
    public void saveshooting()
    {
        SaveSystem.SaveShooting(this);
    }
    public void loadShooting()
    {
        PlayerData shootingdata = SaveSystem.LoadPlayer();
        novaCount = shootingdata.supernova;
        poweredGun = shootingdata.powerup;

        Debug.Log(poweredGun);
    }
    private void FixedUpdate()
    {
        SupernovaText.text = SupernovaPlaceholder + novaCount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("GunPowerUp"))
        {
            Debug.Log("powerup unlocked!");
            Destroy(collision.gameObject);

            poweredGun = true;
            bulletCount = 0;

        }
       
    }
    void ShootNormalBullets()
    {


        
        GameObject bullet = objectpooler.SpawnfromPool("Bullet", firepoint.position, firepoint.rotation);
      //GameObject bullet =  Instantiate(prefab, firepoint.position, firepoint.rotation);

      Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
        bulletCount++;
        //Debug.Log(bulletCount);

       /* if(bulletCount >= 1000)
        {
            poweredGun = false;
        }*/




    }
    
    void ShootLaserBeam()
    {

        GameObject bullet2 = objectpooler.SpawnfromPool("LaserBeam", firepointNova.position, firepoint.rotation);
        //GameObject bullet =  Instantiate(prefab, firepoint.position, firepoint.rotation);

        Rigidbody2D rb = bullet2.GetComponent<Rigidbody2D>();


        rb.AddForce(firepoint.up * SupernovaForce, ForceMode2D.Force );

        Destroy(bullet2, 15);
    }




  public  void BuyUpgradeNova()
    {
        novaCount++;
        Debug.Log("Nova count : " + novaCount);

    }


    
}
