using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const int TRUE_CONST = 1;
    const int FALSE_CONST = 0;

    public static void SetMasterVolume(float volume) {
        if( volume >= 0f && volume <= 1f ) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.Log("Master volume out of range");
        }
    }
    
    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty) {
        if( difficulty >= 1f && difficulty <= 3f ) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        } else {
            Debug.Log("Difficulty out of range");
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void UnlockLevel (int level) {
        if( level <= SceneManager.sceneCountInBuildSettings ) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
        } else {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level) {
        if( level <= SceneManager.sceneCountInBuildSettings ) {
            return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == TRUE_CONST;
        } else {
            Debug.LogError("Trying to retrieve unlocked level not in build order");
            return false;
        }
    }
}
