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

public class UIBack4app : MonoBehaviour
{
    [SerializeField]  TMP_InputField emailinput;
    [SerializeField] TMP_InputField passwordinput;
    [SerializeField] TMP_InputField emailinput2;
    [SerializeField] TMP_InputField passwordinput2;
    private string gmail = "@gmail.com";
    private string outlook = "@outlook.com";
    private string hotmail = "@hotmail.com";
    private string yahoo = "@yahoo.com";
   
    private bool contain = false;


 
    public  IEnumerator CreateUser()
    {
        
        
        using (var request = new UnityWebRequest("https://parseapi.back4app.com/users", "Post"))
        {
            request.SetRequestHeader("X-Parse-Application-Id", secrets.ApplicationId);
            request.SetRequestHeader("X-Parse-REST-API-Key", secrets.RestApiKey);
            request.SetRequestHeader("X-Parse-Revocable-Session", "1");
            request.SetRequestHeader("Content-Type", "application/json");
            var data = new { username = emailinput.text, email = emailinput.text, password = passwordinput.text };
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
    public IEnumerator VerifyUser()
    {
        using (var request = new UnityWebRequest("https://parseapi.back4app.com/verificationEmailRequest", "Post"))
        {
            request.SetRequestHeader("X-Parse-Application-Id", secrets.ApplicationId);
            request.SetRequestHeader("X-Parse-REST-API-Key", secrets.RestApiKey);
            request.SetRequestHeader("Content-Type", "application/json");
            var data = new { username = emailinput.text, email = emailinput.text, password = passwordinput.text };
            string json = JsonConvert.SerializeObject(data);
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();


            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;

            }
            Debug.Log(request.error);

        }
    }
  

   
    public void CalluserCreation()
    {
        Debug.Log(emailinput.text.Contains(gmail));
        Debug.Log(emailinput.text.Contains(outlook));
        Debug.Log(emailinput.text.Contains(hotmail));
        Debug.Log(emailinput.text.Contains(yahoo));
        if (emailinput.text.Contains(gmail) || emailinput.text.Contains(outlook) || emailinput.text.Contains(hotmail) || emailinput.text.Contains(yahoo))
        {
             StartCoroutine(CreateUser());
             //StartCoroutine(VerifyUser());
        }
        else
        {
            Debug.LogError("Email format invalid!");
        }

    }

    public void CallluserLogin()
    {
        StartCoroutine(LoginUser());
    }

    public IEnumerator LoginUser()
    {
        using (var request = new UnityWebRequest("https://parseapi.back4app.com/login", "Post"))
        {
            request.SetRequestHeader("X-Parse-Application-Id", secrets.ApplicationId);
            request.SetRequestHeader("X-Parse-REST-API-Key", secrets.RestApiKey);
            request.SetRequestHeader("X-Parse-Revocable-Session", "1");
            request.SetRequestHeader("Content-Type", "application/json");
            var data = new { username = emailinput2.text, password = passwordinput2.text };
            string json = JsonConvert.SerializeObject(data);
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();


            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                Debug.Log(emailinput.text + " " + passwordinput.text);
            }
            Debug.Log(request.downloadHandler.text);
        }
    }
}
