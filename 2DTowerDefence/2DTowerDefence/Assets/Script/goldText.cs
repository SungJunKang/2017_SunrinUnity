using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldText : MonoBehaviour {

    gameManager gm;
    Text myText;

	// Use this for initialization
	void Awake () {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        myText.text = "" + gm.myGold + "G";
	}
}
