using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRig : MonoBehaviour {

    public Transform tankTransform;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        transform.position = tankTransform.position;
        transform.rotation = tankTransform.rotation;
	}
}
