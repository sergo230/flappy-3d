using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class RecordLoadAndSave : MonoBehaviour
{
    public Text RecordT;
    public string FileName;
    private string path;
    public _record recordCl = new _record();
    
    private void Awake()
    {
        LoadRecord();
    }
    private void LoadRecord()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, FileName + ".json");

#else
        path = Path.Combine(Application.dataPath, FileName + ".json");
#endif
        if (File.Exists(path))
        {
            recordCl = JsonUtility.FromJson<_record>(File.ReadAllText(path));
        }
        else
        {
            recordCl.Record = 0;
        }
    }

    public void SaveRecord()
    {
        File.WriteAllText(path, JsonUtility.ToJson(recordCl));
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus) SaveRecord();
    }
#endif
    private void OnApplicationQuit()
    {
        SaveRecord();
    }

    public void ShowRecord() => RecordT.text = recordCl.Record.ToString() + " record";
}