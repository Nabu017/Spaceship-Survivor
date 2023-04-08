using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UiController : MonoBehaviour
{
    string language = "fr";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Alpha1))
        {
             language = "en";

            if (!string.IsNullOrWhiteSpace(language))
            {
                localization.currentlanguageCSV = language;
                FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
            }
           

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            language = "fr";
            if (!string.IsNullOrWhiteSpace(language))
            {
                localization.currentlanguageCSV = language;
                FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            language = "es";
            if (!string.IsNullOrWhiteSpace(language))
            {
                localization.currentlanguageCSV = language;
                FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            language = "de";
            if (!string.IsNullOrWhiteSpace(language))
            {
                localization.currentlanguageCSV = language;
                FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
            }

        }*/
    }


    public void loadEnlanguage()
    {
        language = "en";

        if (!string.IsNullOrWhiteSpace(language))
        {
            localization.currentlanguageCSV = language;
            FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
        }
    }
    public void loadFRlanguage()
    {
        language = "fr";

        if (!string.IsNullOrWhiteSpace(language))
        {
            localization.currentlanguageCSV = language;
            FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
        }
    }
    public void loadESlanguage()
    {
        language = "es";

        if (!string.IsNullOrWhiteSpace(language))
        {
            localization.currentlanguageCSV = language;
            FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
        }
    }
    public void loadDElanguage()
    {
        language = "de";

        if (!string.IsNullOrWhiteSpace(language))
        {
            localization.currentlanguageCSV = language;
            FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
        }
    }
    public void loadITlanguage()
    {
        language = "it";

        if (!string.IsNullOrWhiteSpace(language))
        {
            localization.currentlanguageCSV = language;
            FindObjectsOfType<TextLocalizer>().ToList().ForEach(x => x.localize());
        }
    }

}
