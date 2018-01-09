using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nameHUD : MonoBehaviour {

    Transform HUDTransform;
    RectTransform rt;

	// Use this for initialization
	void Start () {
        HUDTransform = GameObject.Find("HUDpos").transform;
        rt = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        // 게임 월드 좌표계 --> 캔버스 UI 화면 좌표계
        rt.position = Camera.main.WorldToScreenPoint(HUDTransform.position);
	}
}
