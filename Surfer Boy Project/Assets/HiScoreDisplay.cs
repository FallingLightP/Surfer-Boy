using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    int hiScore;

    private void Start() {
        textMesh = GetComponent<TextMeshProUGUI>();
        hiScore = PlayerPrefs.GetInt("Hi Score");
        textMesh.text = "Random Mode Hi-Score = " + hiScore.ToString();
    }
}
