using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    Transform bulletPoint;

	// Use this for initialization
	void Start () {
        bulletPoint = GameObject.Find("BulletPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity)as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 100;
            Destroy(bullet, 1f);
        }
	}
}
