using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class dataControl : MonoBehaviour {
    // 2가지 방식
    // 1. 간단하게 하는 방식 - 간단한 데이터 밖에 못함
    // 2. 어렵게 하는 방식 - 복잡한 데이터 OK

    public static void saveData(string dataName, float dataValue){
        PlayerPrefs.SetFloat(dataName, dataValue);
    }

    public static float loadData(string dataName){
        return PlayerPrefs.GetFloat(dataName,-1);
    }

    public static void saveClass(string dataName, dataClass dataValue){
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();

        bf.Serialize(ms, dataValue); // dataValue를 바이트 배열로 변환

        // 문자열로 변환해서 저장
        PlayerPrefs.SetString(dataName, Convert.ToBase64String(ms.GetBuffer()));
    }

    public static dataClass loadClass(string dataName){
        string data = PlayerPrefs.GetString(dataName);
        dataClass bestTime = new dataClass("", -1, -1);

        if (!string.IsNullOrEmpty(data)){
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(data));
            bestTime = ((dataClass)bf.Deserialize(ms));
        }
        return bestTime;
    }
}
