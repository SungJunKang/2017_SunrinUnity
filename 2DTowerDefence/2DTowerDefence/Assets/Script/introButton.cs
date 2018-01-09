using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introButton : MonoBehaviour {

    public GameObject bgmManagerPrefab;

	// Use this for initialization
	void Awake () {
        if (GameObject.FindGameObjectWithTag("bgm")== null){
            GameObject g = Instantiate(bgmManagerPrefab);
            DontDestroyOnLoad(g);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
	}

    public void onIntroButtonClicked(){
        load.loadScene("mainTitle");
    }
}
