using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

    public static bool paused;
    public static bool gameOver;

    public int myGold = 1000;
    int maxLife = 5;
    int currentLife;
    public int stage;
    public float currentTime = 0;
    public GameObject heartPrefab;
    Image lifePanel;
    GameObject infoPanel;

	// Use this for initialization
	void Awake () {
        lifePanel = GameObject.Find("lifePanel").GetComponent<Image>();
        currentLife = maxLife;
        paused = false;
        gameOver = false;
        setHeart();
        infoPanel = GameObject.Find("infoPanel");
        infoPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape)){
            if (paused){
                load.loadScene("intro");
            }
            else{
                paused = true;
            }
        }
        if (gameOver){ // 게임오버
            if(Input.GetMouseButton(0)){ // 마우스 입력 됨
                load.loadScene("intro");
            }
            return;
        }

        if (paused){ // 일시정지
            if (Input.GetMouseButton(0)){
                paused = false;
            }
            return;
        }
        currentTime += Time.deltaTime;
        stage = (int)(currentTime / 15) + 1;
	}

    public void monsterEnd(){ // 몬스터가 끝까지 감
        currentLife -= 1;
        changeHeart();
        if(currentLife <= 0){
            Debug.Log("GameOver! 스테이지 : " + stage + " 시간 : " + currentTime + "초");
            gameOver = true;
            if (dataControl.loadData("bestTime") < currentTime){
                dataControl.saveData("bestTime", currentTime);
            }
            infoPanel.SetActive(true);
            // UnityEditor.EditorApplication.isPlaying = false; // 게임 종료
        }
    }

    public void addGold(int gold){
        myGold += gold;
        // 골드 획득 효과음
    }

    public bool useGold(int gold){
        if(myGold < gold){
            return false;
        }
        else{
            myGold -= gold;
            return true;
        }
    }

    void setHeart(){ // maxLife에 따라서 lifePanel에 하트를 정렬해서 생성
        float paddingX = (259 - 32 * 5) / 6;
        for (int i = 0; i < maxLife; i++){
            GameObject h = Instantiate(heartPrefab) as GameObject;
            RectTransform rt = h.GetComponent<RectTransform>();
            h.transform.parent = lifePanel.transform; // 계층 구조 맞추기용
            rt.localPosition = new Vector2(i * 32 - (259 - 32) / 2 + paddingX * (i + 1), 0);
        }
    }

    void changeHeart(){
        RectTransform[] hearts = lifePanel.GetComponentsInChildren<RectTransform>();
        Destroy(hearts[hearts.Length - 1].gameObject);

        float paddingX = (lifePanel.rectTransform.rect.width - 32 * currentLife) / (currentLife + 1);
        for (int i = 0; i < currentLife; i++){
            hearts[i + 1].localPosition = new Vector2(i * 32 - (259 - 32) / 2 + paddingX * (i + 1), 0);
        }
    }
}
