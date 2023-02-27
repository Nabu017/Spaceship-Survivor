using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sources : https://www.youtube.com/watch?v=--u20SaCCow&t=677s&ab_channel=MoreBBlakeyyy
public class EnemyShooting : MonoBehaviour
{

    [SerializeField] public GameObject bullet;
    public Transform bulletPos;


    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
