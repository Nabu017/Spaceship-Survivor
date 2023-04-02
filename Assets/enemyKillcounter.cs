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
using System;

public class enemyKillcounter : MonoBehaviour
{
    public string playername = "player1";

    public int killcounter = 0;

    private void Start()
    {
        //StartCoroutine(createKillcounter());
    }

    private void FixedUpdate()
    {
        
    }
    public IEnumerator createKillcounter()
    {
        using (var request = new UnityWebRequest("https://parseapi.back4app.com/classes/PlayerStats", "POST"))
        {
            request.SetRequestHeader("X-Parse-Application-Id", secrets.ApplicationId);
            request.SetRequestHeader("X-Parse-REST-API-Key", secrets.RestApiKey);
            request.SetRequestHeader("Content-Type", "application/json");
            var Data = new { Name = playername, KillCount = killcounter };
            string json = JsonConvert.SerializeObject(Data);


            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }
        }
    }
}
