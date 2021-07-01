using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelBuilder : MonoBehaviour
{
    public void LoadLevelBuilder()
    {
        SceneManager.LoadScene(2);
    }
}
