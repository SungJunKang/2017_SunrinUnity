using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 moveDir = new Vector3(0, 0,Input.GetAxisRaw("Vertical"));
        Vector3 rotateAngle = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0);
        transform.Rotate(rotateAngle);
        GetComponent<Rigidbody>().velocity = transform.forward * Input.GetAxisRaw("Vertical") * speed;
        //transform.Translate(moveDir);

	}
}
