using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerMakeManager : MonoBehaviour {

    public GameObject towerPrefab;
    gameManager gm;
    public int towerPrice = 1000;

	// Use this for initialization
	void Awake () {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
	}

    // Update is called once per frame
    void FixedUpdate(){
        if (gameManager.gameOver){
            return;
        }

        if (gameManager.paused){
            return;
        }
        towerBuild();
    }

    void towerBuild(){
        if (Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f); // 레이저 정보
            if (hit.collider != null && hit.transform.tag == "tile"){ // 레이저에 감지 
                // 타워 이미 있나 확인
                if (hit.collider.GetComponent<tileScript>().onTower != true){ // 타워 없음
                    // 타워 설치
                    if (gm.useGold(towerPrice)){
                        GameObject tow = Instantiate(towerPrefab) as GameObject;
                        tow.transform.parent = GameObject.Find("towerParent").transform;
                        tow.transform.position = hit.transform.position;
                        hit.collider.GetComponent<tileScript>().onTower = true;
                    }
                }
                else{ // 타워 있음
                    // 타워 관리 UI 표시
                }
            }
        }
    }
}
