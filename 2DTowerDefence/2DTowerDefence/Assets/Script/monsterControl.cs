using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterControl : MonoBehaviour {

    public float maxHP = 100;
    float currentHP;
    public int price = 500;
    gameManager gm;
    public AudioClip deathSound;
    Animator anim;

	// Use this for initialization
	void Awake () {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        maxHP += 500 * (gm.stage - 1);
        currentHP = maxHP;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.enabled = !(gameManager.gameOver || gameManager.paused);
	}

    public void damaged(float d){
        currentHP -= d;
        if (currentHP <= 0){
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, 1);
            gm.addGold(price);
            Destroy(gameObject);
        }
    }
}
