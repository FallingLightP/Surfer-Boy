using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{  

    [SerializeField]Button nextLevelButton;

    [SerializeField]RectTransform[] subMenus;

    private void Start() {
        foreach(RectTransform r in subMenus)
            r.localScale = Vector3.zero;

        if(GameManager.currentLevel >= GameManager.gameManager.levelSequences.Length - 1 && GameManager.originalMode)
            nextLevelButton.interactable = false;

    }

    public void Retry()
    {
        StartCoroutine(RETRY());
    }

    IEnumerator RETRY()
    {
        yield return null;
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        StartCoroutine(BACKTOMENU());
    }

    IEnumerator BACKTOMENU()
    {
        yield return null;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        StartCoroutine(NEXTLEVEL());
    }

    IEnumerator NEXTLEVEL()
    {
        yield return null;
        
        if(GameManager.originalMode)
            GameManager.currentLevel++;

        

        SceneManager.LoadScene(1);
    }

    public void ReloadLevelBuilder()
    {
        StartCoroutine(RELOADBUILDER());
    }

    IEnumerator RELOADBUILDER()
    {
        yield return null;
        SceneManager.LoadScene(2);
    }

}
