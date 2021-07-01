using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OriginalLevelSelect : MonoBehaviour
{

    List<GameObject> levelIcons;

    GameObject presetButton;

    RectTransform position;

    Vector2 offset = Vector2.zero;

    Vector2 currentButton = new Vector2(-170, -300);

    private void Start() {
        levelIcons = new List<GameObject>();
        presetButton = transform.GetChild(0).gameObject;
        int i = 0;
        
        if(GameManager.gameManager.premadeLevels.Length > 1)
        foreach(CompleteLevel c in GameManager.gameManager.premadeLevels)
        {
            if(i == 0)
                print("no");
            else if(i%2==0)
            {
                offset = new Vector2(-340, -300);
                GameObject newButton = Instantiate(presetButton, transform.position, Quaternion.identity, transform);
                currentButton += offset;
                newButton.GetComponent<RectTransform>().anchoredPosition = currentButton;
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            }
            else
            {

                offset = new Vector2(340, 0);
                GameObject newButton = Instantiate(presetButton, transform.position, Quaternion.identity, transform);
                currentButton += offset;
                newButton.GetComponent<RectTransform>().anchoredPosition = currentButton;
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            }
            i++;
        }
    }
}
