using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUtil : MonoBehaviour {
    public static void ccMove(Vector3 moverDir, CharacterController _cc, float moveSpeed){
        _cc.Move(moverDir * moveSpeed * Time.deltaTime);
    }
    public static void RotateToDir(Vector3 dir, Transform _t, float turnSpeed){
        if(dir == Vector3.zero){
            return; 
        }
        _t.rotation = Quaternion.RotateTowards(
            _t.rotation, 
            Quaternion.LookRotation(dir),  // 지금 되야할 각
            turnSpeed * Time.deltaTime // 턴 속도
            );
    }
}
