using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerControl : MonoBehaviour {
    // 몹을 바라보고
    // 사정거리 안에 왔는지 감지
    // 총알 발사 O

    Transform mobParent;
    Transform targetPos;
    public float detectDistance = 10;
    public float rotateSpeed = 480;
    public GameObject bulletPrefab;
    public float attackSpeed = 0.5f; // 몇초 마다 공격
    Transform bulletPoint;
    public float myDmg = 50f;
    public AudioClip bulletSound;

	// Use this for initialization
	void Awake () {
        mobParent = GameObject.Find("mobParent").transform;
        bulletPoint = GetComponentsInChildren<Transform>()[1];
        StartCoroutine(attacking());
	}

    // Update is called once per frame
    void Update(){
        if(gameManager.paused || gameManager.gameOver){
            return;
        }
        if (targetPos == null || Vector2.Distance(targetPos.position, transform.position) > detectDistance){ // 타켓이 없거나 거리를 벗어났을때 새로운 타겟 설정
            Transform[] mobTrans = mobParent.GetComponentsInChildren<Transform>();
            for (int i = mobTrans.Length - 1; i >= 1; i--){
                if (Vector2.Distance(mobTrans[i].position, transform.position) <= detectDistance){
                    // 사정거리 안에 들어옴
                    targetPos = mobTrans[i];
                    Vector2 diff = targetPos.position - transform.position;
                    diff.Normalize();

                    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                }
            }
        }
        else{ // 타겟이 있고, 사거리 안에 있음
            Vector2 diff = targetPos.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
    
    void attackToTarget(){
        GameObject b = Instantiate(bulletPrefab);
        b.transform.position = bulletPoint.position;
        b.GetComponent<bulletScript>().targetTransform = targetPos;
        b.GetComponent<bulletScript>().myDamage = myDmg;
        AudioSource.PlayClipAtPoint(bulletSound, Camera.main.transform.position, 1);
    }

    IEnumerator attacking(){
        do {
            yield return new WaitForSeconds(attackSpeed);
            if (gameManager.paused || gameManager.gameOver){
                continue;
            }
            if (targetPos != null){
                attackToTarget();
            }
        } while (true);
    }
}
