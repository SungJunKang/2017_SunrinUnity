using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour {

    public static string sceneName = "intro";

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void loadScene(string name){
        sceneName = name;
        SceneManager.LoadScene("loadingScene");
    }
}
