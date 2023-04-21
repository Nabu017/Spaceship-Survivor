using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    [SerializeField] public GameObject bullet1;
  
    public Transform bulletPos1;
    public Transform bulletPos2;
    public Transform bulletPos3;
    public Transform bulletPos4;



    private float timer;
   

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

    

    private void  Shoot()
    {
        Instantiate(bullet1, bulletPos1.position, Quaternion.identity);
        Instantiate(bullet1, bulletPos2.position, Quaternion.identity);
        Instantiate(bullet1, bulletPos3.position, Quaternion.identity);
        Instantiate(bullet1, bulletPos4.position, Quaternion.identity);
    }
}
