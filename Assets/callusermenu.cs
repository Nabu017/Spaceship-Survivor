using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callusermenu : MonoBehaviour
{
    [SerializeField] GameObject usercreation;
    [SerializeField] GameObject LoginUser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void calluserCreationMenu()
    {
        LoginUser.SetActive(false);
        usercreation.SetActive(true);
    }
    public void callLoginCreationMenu()
    {
        usercreation.SetActive(false);
        LoginUser.SetActive(true);
    }
}
