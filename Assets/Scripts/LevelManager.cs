using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour {

	public float AutoLoadNextLevelAfter;

	public void Start() {
        if (AutoLoadNextLevelAfter == 0) {
            Debug.Log("Level Auto Load Disabled");
        }
        else {
            Invoke("LoadNextLevel", AutoLoadNextLevelAfter);
        }
        
	}

	public void LoadLevel(string name){
        Debug.Log(string.Format("Level load requested for: {0}", name));
        SceneManager.LoadScene(name);
    }
    
    public void QuitRequest(){
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    
}
