using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController player;
    public float speed = 20;
    [SerializeField] private GameObject prefab;
    
    // Start is called before the first frame update
    Camera myCamera;
    void Start()
    {
        player = GetComponent<CharacterController>();
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
      
        Movement();
        Shooting();
    }

    private void Movement()
    {
        
        Vector3 move = Vector3.zero;
        move.x = Input.GetAxis("Horizontal") * speed;
        move.y = Input.GetAxis("Vertical") * speed;
        player.Move(move * Time.deltaTime);

    }


    private void Shooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var positioncursor = myCamera.ScreenToWorldPoint(Input.mousePosition);
            positioncursor.z = 0;
            var bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.transform.up = (positioncursor - transform.position).normalized;
        }
    }
}
