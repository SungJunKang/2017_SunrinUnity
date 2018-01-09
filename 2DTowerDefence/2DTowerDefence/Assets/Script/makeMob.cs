using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMob : MonoBehaviour {

    Transform mobPoint;
    Transform mobParent;
    public GameObject mobPrefab;

	// Use this for initialization
	void Awake () {
        mobPoint = GameObject.Find("mobPoint").transform;
        mobParent = GameObject.Find("mobParent").transform;
        StartCoroutine(spawnMonster());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawnMonster(){
        do {
            yield return new WaitForSeconds(1);
            if (gameManager.paused || gameManager.gameOver){
                continue;
            }
            GameObject m = Instantiate(mobPrefab, mobParent)as GameObject;
            m.transform.position = mobPoint.position;
        } while(true);
    }
}
