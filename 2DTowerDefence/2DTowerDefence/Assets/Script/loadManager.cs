using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadManager : MonoBehaviour { // 일단 게임씬으로 ㄱ

    public Slider loadingBar;
    string sceneName;
    AsyncOperation async;
    bool isLoadScene;

    public IEnumerator loadStart(string sceneName){
        if(isLoadScene == false){
            isLoadScene = true;
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;
            while(async.isDone == false){
                float p = async.progress;
                if(async.progress >= 0.9f){ // almost 됨
                    async.allowSceneActivation = true;
                }
                loadingBar.value = p;
                yield return null;
            }
        }
    }

	// Use this for initialization
	void Awake () {
        sceneName = load.sceneName;
        loadingBar.maxValue = 0.9f;
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("loadStart", sceneName);
    }

}
