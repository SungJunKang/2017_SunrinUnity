using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 rotateAngle = new Vector3(v, 0, h);
        transform.Rotate(rotateAngle);
	}
}
