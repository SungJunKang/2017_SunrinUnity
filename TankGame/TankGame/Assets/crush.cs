using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crush : MonoBehaviour {

    public scoreManager mgr;

	// Use this for initialization
	void Start () {
        mgr = GameObject.Find("scoreManager").GetComponent<scoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other){
        if(other.transform.tag == "BOX"){
            // 점수 올리고
            mgr.playerScore += 100;
            // 박스 삭제
            Destroy(other.gameObject);
        }
    }
}
