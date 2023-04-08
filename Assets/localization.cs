using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localization : MonoBehaviour
{





    [SerializeField] static Dictionary<string, string> csvEN = new Dictionary<string, string>();
    [SerializeField] static Dictionary<string, string> csvFR = new Dictionary<string, string>();
    [SerializeField] static Dictionary<string, string> csvES = new Dictionary<string, string>();
    [SerializeField] static Dictionary<string, string> csvDE = new Dictionary<string, string>();
    [SerializeField] static Dictionary<string, string> csvIT = new Dictionary<string, string>();
    [SerializeField] static Dictionary<string, string> currentDictionary = new Dictionary<string, string>();
    public static bool checkifloaded = false;
    public static localization instance { get; private set; }
    public static string currentlanguageCSV { get; internal set; }








    private void Awake()
    {
        instance = this;
    }


    public static void loadcsv()
    {
        CSVloader loader = new CSVloader();
        loader.loadCSV();

        csvEN = loader.GetDictionaryValues("en");
        csvFR = loader.GetDictionaryValues("fr");
        csvES = loader.GetDictionaryValues("es");
        csvDE = loader.GetDictionaryValues("de");
        csvIT = loader.GetDictionaryValues("it");

        checkifloaded = true;
    }


    public static string getString(string stringkey)
    {
        if (!checkifloaded) loadcsv();


        string value = stringkey;

        if(csvEN.ContainsKey(stringkey) || csvFR.ContainsKey(stringkey)|| csvES.ContainsKey(stringkey) || csvDE.ContainsKey(stringkey))
        {
           // Debug.Log("found");
            switch(currentlanguageCSV)
            {
                case "en":
                 
                    currentDictionary = csvEN;
                    currentDictionary.TryGetValue(stringkey, out value);
                    break;
                case "fr":
                  
                    currentDictionary = csvFR;
                    currentDictionary.TryGetValue(stringkey, out value);
          
                   
                    break;
                case "es":
                    currentDictionary = csvES;
                    currentDictionary.TryGetValue(stringkey, out value);

                    break;
                case "de":
                    currentDictionary = csvDE;
                    currentDictionary.TryGetValue(stringkey, out value);

                    break;
                case "it":
                    currentDictionary = csvIT;
                    currentDictionary.TryGetValue(stringkey, out value);
                    break;
                default:
                   // csvFR.TryGetValue(stringkey, out value);
                    currentDictionary = csvEN;
                    currentDictionary.TryGetValue(stringkey, out value);
                    Debug.Log(currentDictionary);
                    break;
            }
            return value;
        }
        else
        {
            //Debug.Log("returned key :" + stringkey);
            Debug.LogWarning("Missing string key: " + stringkey);
            //csvFR.TryGetValue(stringkey, out value);
            return stringkey;
            
        }
    }
}
