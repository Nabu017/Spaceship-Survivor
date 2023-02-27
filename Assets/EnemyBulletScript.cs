using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sources : https://www.youtube.com/watch?v=--u20SaCCow&t=677s&ab_channel=MoreBBlakeyyy
public class EnemyBulletScript : MonoBehaviour
{

    public GameObject player;

   [SerializeField] private Rigidbody2D rigid;
    public float force;
    
    // Start is called before the first frame update
    void Start()
    {
     
        rigid.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

       
        
           if(player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            rigid.velocity = new Vector2(direction.x, direction.y).normalized * force;



            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rot + 270);

            Destroy(gameObject, 5f);
        }
           
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
