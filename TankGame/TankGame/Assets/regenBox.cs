using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regenBox : MonoBehaviour {

    public GameObject boxPrefab;
    float regenTime = 3f;
    float tempTime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempTime += Time.deltaTime;
        if(tempTime >= regenTime) {
            tempTime %= regenTime;
            float x = Random.RandomRange(-72.5f, 55f);
            float z = Random.RandomRange(-45.4f, 50f);
            Instantiate(boxPrefab, new Vector3(x, boxPrefab.transform.position.y, z), Quaternion.identity);
        }
	}
}
