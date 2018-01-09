using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestInfo : MonoBehaviour {

    public Text bestStage;
    public Text bestTime;


    void OnEnable(){
        bestTime.text = "" + dataControl.loadData("bestTime") + "초";
        bestStage.text = "STAGE " + (int)(dataControl.loadData("bestTime") / 15 + 1);
    }

	// Use this for initialization
	void Awake () { 

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
