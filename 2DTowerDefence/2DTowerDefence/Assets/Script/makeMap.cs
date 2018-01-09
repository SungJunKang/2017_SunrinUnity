using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMap : MonoBehaviour {
    // 총길이 960
    // -480 ~ 480 : x
    // -240 ~ 240 : y
    // 타일의 크기 : 64 x 64
    // -480 + 32 + 64씩 960 / 64번
    // -240 + 32 + 64씩 480 / 64번

    public GameObject tilePrefab;
    Transform mapParentTrans;

	// Use this for initialization
	void Awake () {
        mapMake();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void mapMake(){
        mapParentTrans = GameObject.Find("mapParent").transform;
        for (int i = 0; i <= 960 / 64; i++){
            for (int j = 0; j <= 480 / 64; j++){
                GameObject t = Instantiate(tilePrefab) as GameObject;
                t.transform.parent = mapParentTrans;
                t.transform.position = new Vector2(-480 + 32 + i * 64, 240 - 32 - j * 64);
            }
        }
    }

}
