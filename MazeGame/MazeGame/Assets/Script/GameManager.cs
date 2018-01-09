using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public List<goalScript> goalList;
    public Text timeText;
    public Text ScoreText;
    float currentTime;
    public Image scoreImage;
    bool onGaming;
    int currentScore;

    public GameObject dataPanel;
    public Text bestText;
    public Text nameText;
    public Text timeScoreText;

    //public GameObject p;
    //Vector3 f;

	// Use this for initialization
	void Awake () {
        goalList = new List<goalScript>();
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Box");
        foreach(GameObject g in goals){
            goalList.Add(g.GetComponent<goalScript>());
        }
        // Debug.Log(dataControl.loadData("clearTime"));
        // Debug.Log(dataControl.loadClass("bestTime"));
        currentTime = 0;
        onGaming = true;
        currentScore = 0;
        dataPanel.SetActive(false);
        //f = p.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (onGaming){
            currentTime += Time.deltaTime;
        }
        foreach (goalScript g in goalList){
            if (g.isDie && g.gameObject.activeInHierarchy){
                g.gameObject.SetActive(false);
                currentScore++;
            }
        }
        timeText.text = "" + currentTime;
        ScoreText.text = "" + currentScore + " / " + goalList.Count;
        scoreImage.fillAmount = (float)currentScore / (float)goalList.Count;
        if(currentScore == goalList.Count){
            dataPanel.SetActive(true);
            float bestTime = dataControl.loadClass("bestTime").time;
            bestText.text = "최고기록 달성 실패";
            if (bestTime <= 0 || bestTime >= currentTime){
                dataControl.saveData("clearTime", currentTime);
                dataClass bestData = new dataClass("ZI존 킹왕짱", currentTime, goalList.Count);
                dataControl.saveClass("bestTime", bestData);
                Debug.Log(currentTime);
                bestText.text = "최고기록 달성!!";
            }
            dataClass changedData = dataControl.loadClass("bestTime");
            nameText.text = "" + changedData.playerName;
            timeScoreText.text = "" + changedData.time + " / " + changedData.boxCount + "개";

            onGaming = false;
        }
    }
    //public void ResetGame(){
    //    // 시간 초기화
    //    currentTime = 0;
    //    // 점수 초기화
    //    currentScore = 0;
    //    // 플레이어 초기화
    //    // 시작하자마자 플레이어 포지션을 받아서 저장해놓고
    //    // 리셋하면 그 포지션으로 이동
    //    p.transform.position = f;
    //    // 상자 초기화
    //    foreach (goalScript g in goalList) {
    //        g.gameObject.SetActive(true);
    //        g.isDie = false;
    //    }
    //}
    public void ResetGame(){
        // 2번째 방법 : 씬을 다시 시작하기
        SceneManager.LoadScene("gameScene");
    }
}
