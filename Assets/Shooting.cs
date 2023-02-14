using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject prefab;
    ObjectPool objectpooler;

    public float bulletforce = 20f;


    private void Start()
    {
        objectpooler = ObjectPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        GameObject bullet = objectpooler.SpawnfromPool("Bullet", firepoint.position, firepoint.rotation);
      //GameObject bullet =  Instantiate(prefab, firepoint.position, firepoint.rotation);

      Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
    }
}