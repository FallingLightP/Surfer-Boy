using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    ParticleSystem part;

    PlayerGameFuntion playerFunction;

    private void Start() {
        part = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            StartCoroutine(BACKTOMENU());
            playerFunction = other.GetComponentInChildren<PlayerGameFuntion>();
        }
    }

    IEnumerator BACKTOMENU()
    {
        if(GameManager.originalMode){
            print("Progress : " + GameManager.originalModeProgress + " -- Current Level : " + GameManager.currentLevel);
            if(GameManager.originalModeProgress == GameManager.currentLevel){
                GameManager.originalModeProgress++;
                PlayerPrefs.SetInt("Progress", GameManager.originalModeProgress);
                PlayerPrefs.Save();
            }
        }

        GameManager.initialized = false;
        yield return null;
        //SceneManager.LoadScene(0);
        playerFunction.Win();

    }
}