using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OriginalLevelButton : MonoBehaviour
{
    public int myLevel;

    Button button;

    private void Start() {
        button = GetComponent<Button>();
        print("yo!!!");
        if(myLevel > GameManager.originalModeProgress)
            button.interactable = false;
    }

    public void LoadOriginalLevel()
    {
        GameManager.currentLevel = myLevel;
        GameManager.originalMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
