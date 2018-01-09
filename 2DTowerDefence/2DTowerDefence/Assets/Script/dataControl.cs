using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class dataControl{

    public static void saveData(string dataName, float dataValue){
        PlayerPrefs.SetFloat(dataName, dataValue);
    }

    public static float loadData(string dataName){
        return PlayerPrefs.GetFloat(dataName, -1);
    }
}
