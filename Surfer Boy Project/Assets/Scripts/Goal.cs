using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    ParticleSystem part;

    PlayerGameFuntion playerFunction;

    [SerializeField]float confettiDelay = 0.2f;

    public bool test;

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
            if(GameManager.originalModeProgress == GameManager.currentLevel){
                GameManager.originalModeProgress++;
                PlayerPrefs.SetInt("Progress", GameManager.originalModeProgress);
                PlayerPrefs.Save();
            }
        }

        if(!GameManager.originalMode && SceneManager.GetActiveScene().buildIndex == 1)
        {
            int i = PlayerStack.myStack.boxes.Count;

            if(i>PlayerPrefs.GetInt("Hi Score"))
            {
                PlayerPrefs.SetInt("Hi Score", i);
                PlayerPrefs.Save();
            }
        }
        yield return null;
        part.TriggerSubEmitter(0);
        playerFunction.Win();

        StartCoroutine(CONFETTI());

    }

    IEnumerator CONFETTI()
    {
        part.TriggerSubEmitter(0);
        yield return new WaitForSeconds(confettiDelay);
        part.TriggerSubEmitter(0);
        StartCoroutine(CONFETTI());
    }
}
