using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System;
using Newtonsoft.Json.Linq;
public class Back4appPromoCode : MonoBehaviour
{
    string randomString;
    [SerializeField] TMP_InputField promocodeInput;
    string promoCodeType;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CreateCodes());
    }

    
    public IEnumerator CreateCodes()
    {
        string PromoType = "Health";
        for (int i = 0; i < 100; i++)
        {
            using (var request = new UnityWebRequest("https://parseapi.back4app.com/classes/PromoCodes", "POST"))
            {
                if(i > 33 && i < 66)
                {
                    PromoType = "Energy";
                }
                else if(i > 66)
                {
                    PromoType = "SuperNova";
                }
                request.SetRequestHeader("X-Parse-Application-Id", secrets.ApplicationId);
                request.SetRequestHeader("X-Parse-REST-API-Key", secrets.RestApiKey);
                request.SetRequestHeader("X-Parse-Revocable-Session", "1");
                request.SetRequestHeader("Content-Type", "application/json");
                var data = new { PromoCode = RandomStrings(randomString), CodeIdNumber = i, PromoCodeType = PromoType };
                string json = JsonConvert.SerializeObject(data);
                request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
                request.downloadHandler = new DownloadHandlerBuffer();



                yield return request.SendWebRequest();
                if(request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                }
                Debug.Log(request.error);
            }
        }


        
    }


    public IEnumerator ReadPromoCode()
    {
        Debug.Log(promocodeInput.text);
        for(int i = 0; i < 100; i++)
        {
            string counter = i.ToString();
            string url = "https://parseapi.back4app.com/classes/PromoCodes/?where={\"CodeIdNumber\":" + i + "}";
            using (var request = UnityWebRequest.Get(url))
            {
                request.SetRequestHeader("X-Parse-Application-Id", secrets.ApplicationId);
                request.SetRequestHeader("X-Parse-REST-API-Key", secrets.RestApiKey);

                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);

                }
                //Debug.Log(request.downloadHandler.text);
                var jObject = JObject.Parse(request.downloadHandler.text);
                string code = jObject["results"][0]["PromoCode"].ToString();
                string code2 = jObject["results"][0]["PromoCodeType"].ToString();
                string code3 = jObject["results"][0]["IsRedeemed"].ToString();

                //var matches = Regex.Matches(request.downloadHandler.text, "\"PromoCode\":(\\d+)", RegexOptions.Multiline);
             
                // Debug.Log(code);
                // Debug.Log(code2);
                //Debug.Log(code3);
                if(promocodeInput.text == code)
                {
                    Debug.Log("code is valid !" + " " + "promoType = " + code2);

                    break;
                }
               
            }
        }
    }

    public  void CallReadCode()
    {
        StartCoroutine(ReadPromoCode());
    }
    public string RandomStrings(string token)
    {
        var randomNumber = new byte[15];


        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            token = Convert.ToBase64String(randomNumber);
            Debug.Log("random Code : " + " " + token);
            return token;
        }
    }
}
