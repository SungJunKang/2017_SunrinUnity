using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMove : MonoBehaviour {

    NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 레이저 정보
            RaycastHit hitInfo; // 레이저 맞은 애 정보 저장
            if (Physics.Raycast(ray, out hitInfo, 1000f)){ // 레이저 발사 
                navAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
