using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : MonoBehaviour
{
     [SerializeField] Transform playerTransform;
    public float RotateSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 directionPlayer = playerTransform.position - transform.position;


        Quaternion targetRotate = Quaternion.LookRotation(directionPlayer);


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotate, RotateSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
