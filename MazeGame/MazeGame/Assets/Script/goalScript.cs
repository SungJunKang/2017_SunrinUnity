using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour {

    public playerFSM fsm;
    public bool isDie;
    public AudioClip crushSound;

	// Use this for initialization
	void Start () {
        isDie = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other){
        if(other.tag == "sword"){
            if(fsm.playerState == playerFSM.STATE.ATTACK){
                isDie = true;
                AudioSource.PlayClipAtPoint(crushSound, transform.position);
            }
        }
    }
}
