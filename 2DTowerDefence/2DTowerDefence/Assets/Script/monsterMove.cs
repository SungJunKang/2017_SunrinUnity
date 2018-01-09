using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour {

    Transform endPosition;
    public float mobSpeed = 100f;
    Transform[] wayPoints;
    Vector2 targetPos;
    int targetNum;
    bool isDie;
    gameManager gm;

	// Use this for initialization
	void Awake () {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        isDie = false;
        targetNum = 1;
        endPosition = GameObject.Find("mobEnd").transform;
        wayPoints = GameObject.Find("wayPointParent").GetComponentsInChildren<Transform>();
        targetPos = wayPoints[targetNum].position;
        mobSpeed += 20 * (gm.stage - 1);
	}
	
	// Update is called once per frame
	void Update () {
        // 끝까지 가면 monsterEnd 호출하고 더이상 이동하지 않는다.
        if (gameManager.paused || gameManager.gameOver){
            return;
        }

        // 갈 길 설정
        moveToWay();
        // 설정된 길로 이동
        moveTotarget();
	}

    void moveToWay(){
        if(Vector2.Distance(targetPos, transform.position) <= 0){
            if (targetNum < wayPoints.Length - 1){
                targetNum++;
                targetPos = wayPoints[targetNum].position;
            }
            else{
                monsterEnd();
            }
        }
    }

    void moveTotarget(){
        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * mobSpeed);
    }

    void monsterEnd(){ // 몬스터가 끝까지 갔을때
        isDie = true;
        gm.monsterEnd();
        Destroy(gameObject);
    }
}
