using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public Transform firepointNova;
    public GameObject prefab;
    public GameObject LaserBeam;
    public float bulletforce = 20f;
    public float SupernovaForce = 30f;
    private int novaCount = 0;

    ObjectPool objectpooler;

   [SerializeField] public bool poweredGun = false;

    private int bulletCount = 0;
  

   


    private void Start()
    {
        objectpooler = ObjectPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {


     

        if(Input.GetButtonDown("Jump") && novaCount < 3)
        {
            novaCount++;
            ShootLaserBeam();
        }

        if(poweredGun == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootNormalBullets();
            }
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                ShootNormalBullets();
            }
        }
     
      
      
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
        Debug.Log(bulletCount);

        if(bulletCount >= 1000)
        {
            poweredGun = false;
        }




    }

    void ShootLaserBeam()
    {

        GameObject bullet2 = objectpooler.SpawnfromPool("LaserBeam", firepointNova.position, firepoint.rotation);
        //GameObject bullet =  Instantiate(prefab, firepoint.position, firepoint.rotation);

        Rigidbody2D rb = bullet2.GetComponent<Rigidbody2D>();


        rb.AddForce(firepoint.up * SupernovaForce, ForceMode2D.Force );
    }
}
