using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PasswordFormat : MonoBehaviour
{
    [SerializeField] TMP_InputField passwordCreate;
    [SerializeField] TMP_InputField passwordLogin;
    // Start is called before the first frame update
    void Start()
    {
        passwordCreate.contentType = TMP_InputField.ContentType.Password;
        passwordLogin.contentType = TMP_InputField.ContentType.Password;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
