using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFSM : MonoBehaviour
{
    // finite-state machine
    // 유한 상태 기계

    CharacterController _cc;
    float playerSpeed = 50f;
    public float turnSpeed = 480f;
    Vector3 targetDir;
    public Transform marker;
    int _layerMask;
    Vector3 targetPos;
    public STATE playerState;
    Animator _anim;
    bool newState;
    bool ani_end;
    bool attack_end;

    public enum STATE
    {
        IDLE,
        WALK,
        TO_SWORD,
        IDLE_SWORD,
        WALK_SWORD,
        ATTACK,
        TO_IDLE,
    }

    // Use this for initialization
    void Awake()
    {
        _cc = GetComponent<CharacterController>();
        targetDir = Vector3.zero;
        targetPos = transform.position;
        _layerMask = (1 << 8) + (1 << 9);
        playerState = STATE.IDLE;
        _anim = GetComponent<Animator>();
        newState = false;
        ani_end = false;
        attack_end = false;
        StartCoroutine("FSMmain");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);
        if (!_cc.isGrounded)
        {
            moveDir = new Vector3(0, Physics.gravity.y, 0);
            moveDir *= Time.deltaTime;
        }
        _cc.Move(moveDir);
        //if (movePlayer()){
        //    playerState = STATE.WALK;
        //}
        //else{
        //    playerState = STATE.IDLE;
        //}
        //_anim.SetInteger("playerState", (int)playerState);
    }

    bool movePlayer()
    {
        Vector3 moveDir = moveInput2();
        moveUtil.RotateToDir(targetDir, transform, turnSpeed);
        if (moveDir != Vector3.zero)
        {
            targetDir = moveDir;
            moveUtil.ccMove(moveDir, _cc, playerSpeed);
            return true;
        }
        return false;
    }

    Vector3 moveInput1()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(h, 0, v);
        return moveDir;
    }

    Vector3 moveInput2(){
        Vector3 moveDir = new Vector3(0, 0, 0);
        if (Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 레이저 정보
            RaycastHit hitInfo; // 레이저 맞은 애 정보 저장
            if (Physics.Raycast(ray, out hitInfo, 1000f, _layerMask)){ // 레이저 발사 
                if (hitInfo.transform.gameObject.layer == 8){
                    targetPos = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
                    marker.position = hitInfo.point;
                    marker.gameObject.SetActive(true);
                }
            }
        }
        targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
        moveDir = Vector3.MoveTowards(transform.position, targetPos, playerSpeed * Time.deltaTime) - transform.position;
        if ((targetPos - transform.position).magnitude < 0.5f){
            targetPos = transform.position;
            return Vector3.zero;
        }
        else {
            return moveDir;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == marker.name)
        {
            marker.gameObject.SetActive(false);
        }
    }

    public void EndAni()
    {
        ani_end = true;
    }

    public void EndAttack(){
        attack_end = true;
    }

    void setState(STATE s)
    {
        newState = true;
        playerState = s;
        _anim.SetInteger("playerState", (int)playerState);
    }

    bool attackInput(){
        if (Input.GetKeyDown(KeyCode.A)){
            return true;
        }
        return false;
    }

    bool swordInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }

    IEnumerator FSMmain()
    {
        while (true)
        {
            newState = false;
            yield return StartCoroutine(playerState.ToString());
        }
    }

    IEnumerator IDLE(){
        do
        {
            yield return null;
            if (swordInput())
            {
                setState(STATE.TO_SWORD);
            }
            else {
                if (movePlayer())
                {
                    setState(STATE.WALK);
                }
            }
        } while (!newState);
    }

    IEnumerator WALK(){
        do{
            yield return null;
            if (swordInput()){
                setState(STATE.TO_SWORD);
            }
            else {
                if (movePlayer()){
                    setState(STATE.WALK);
                }
                else {
                    setState(STATE.IDLE);
                }
            }
        } while (!newState);
    }

    IEnumerator TO_SWORD(){
        ani_end = false;
        do{
            yield return null;
        } while (!ani_end);
        setState(STATE.IDLE_SWORD);
    }

    IEnumerator TO_IDLE(){
        ani_end = false;
        do{
            yield return null;
        } while (!ani_end);
        setState(STATE.IDLE);
    }

    IEnumerator IDLE_SWORD(){
        do{
            yield return null;
            if (swordInput()){
                setState(STATE.TO_IDLE);
            }
            else if (attackInput()){
                setState(STATE.ATTACK);
            }
            else if (movePlayer()){
                    setState(STATE.WALK_SWORD);
            }
        } while (!newState);
    }

    IEnumerator WALK_SWORD(){
        do{
            yield return null;
            if (swordInput()){
                setState(STATE.TO_IDLE);
            }
            else if (attackInput()){
                setState(STATE.ATTACK);
            }
            else {
                if (movePlayer()) {
                    setState(STATE.WALK_SWORD);
                }
                else {
                    setState(STATE.IDLE_SWORD);
                }
            }
        } while (!newState);
    }

    IEnumerator ATTACK(){
        ani_end = false;
        attack_end = false;
        do{
            yield return null;
            if (attack_end){ // 베고난뒤 손이 뒤로감
                // 추가 공격 가능
                if (attackInput()){
                    attack_end = false;
                    _anim.Play("sword_slash_01", 0, 0f);
                    setState(STATE.ATTACK);
                }
            }
        } while (!ani_end); // 공격 애니메이션 끝남
        if (movePlayer()){
            setState(STATE.WALK_SWORD);
        }
        else{
            setState(STATE.IDLE_SWORD);
        }
    }
}