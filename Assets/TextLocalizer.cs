using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLocalizer : MonoBehaviour
{
    [SerializeField] string key;


 public void localize()
    {
     GetComponent<TMP_Text>().text = localization.getString(key);
       
    }
    void Start()
    {
        localize();
    }

   
}
