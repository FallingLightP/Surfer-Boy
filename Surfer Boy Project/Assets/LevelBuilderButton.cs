using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuilderButton : MonoBehaviour
{
    LevelBuilder builder;
    Button thisButton;

    [SerializeField]int myTile;
    
    private void Start() {
        builder = GetComponentInParent<LevelBuilder>();
        thisButton = GetComponent<Button>();
    }

    public void ButtonPressed()
    {
        builder.AddNewPart(myTile);
    }

    private void Update() {
        if(builder.capped)
        {
            thisButton.interactable = false;
        }
    }
}
