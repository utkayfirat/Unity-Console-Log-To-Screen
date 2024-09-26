using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleLog : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform content;

    void OnEnable(){
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable(){
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type){
        AddLog(logString, type);
    }

    public void AddLog(string message, LogType type){
        GameObject newText = Instantiate(textPrefab, content);
        Text textComponent = newText.GetComponent<Text>();
        textComponent.text = message;

        switch (type)
        {
            case LogType.Error:
                textComponent.color = Color.red;
                break;
            case LogType.Warning:
                textComponent.color = Color.yellow;
                break;
            default:
                textComponent.color = Color.white;
                break;
        }
    }
}
