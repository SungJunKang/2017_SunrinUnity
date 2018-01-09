using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour { // 유도탄

    public Transform targetTransform;
    public float bulletSpeed = 300;
    public float myDamage = 50;

	// Use this for initialization
	void Awake () { // 타워에서 타겟트랜스폼을 줌
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameManager.paused || gameManager.gameOver){
            return;
        }

        if (targetTransform == null){
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, Time.deltaTime * bulletSpeed);

        Vector2 diff = targetTransform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(Transform.Equals(other.transform, targetTransform)){
            other.GetComponent<monsterControl>().damaged(myDamage);
            Destroy(gameObject);
        }
    }
}
