using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OriginalLevelButton : MonoBehaviour
{
    public int myLevel;

    public void LoadOriginalLevel()
    {
        GameManager.currentLevel = myLevel;
        GameManager.originalMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
