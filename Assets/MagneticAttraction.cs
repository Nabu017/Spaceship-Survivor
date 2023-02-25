using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticAttraction : MonoBehaviour
{
    public Transform SuperNova;
    public float moveSpeed = 17f;

    MagneticField magnetfield;

    // Start is called before the first frame update
    void Start()
    {
        SuperNova = GameObject.FindGameObjectWithTag("Nova").transform;
        magnetfield = gameObject.GetComponent<MagneticField>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Nova")
        {

        }
    }
}
