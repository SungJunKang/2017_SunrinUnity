using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour {
    public float playerScore;

	// Use this for initialization
	void Start () {
        playerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("점수 : " + playerScore);
	}
}
