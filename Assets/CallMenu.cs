using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallMenu : MonoBehaviour
{

    [SerializeField] private GameObject optionMenu ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("key pressed");
            optionMenu.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
       
    }
}
