using System.Collections.Generic;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Internal;

public class LogCustomEvents : MonoBehaviour 
{
    private int _counter = 0;

    // Update is called once per frame
    void Update () 
    {
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _counter++;
            String message = _counter + " times";
           LogPlayFabEvent("SPACE pressed", message);
            Debug.Log("SPACE pressed " + message);
        }
		
    }
    
    private void LogPlayFabEvent(string eventName, string message)
    {
        PlayFabClientAPI.WritePlayerEvent(new WriteClientPlayerEventRequest() {
                Body = new Dictionary<string, object>() {
                    { "BuiltItBetterEvent", eventName },
                    { "Message", message }
                },
                EventName = "build_it_better_event"
            },
            result => Debug.Log("Success"),
            error => Debug.LogError(error.GenerateErrorReport()));
    }


}
