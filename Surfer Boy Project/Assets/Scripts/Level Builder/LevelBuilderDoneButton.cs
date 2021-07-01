using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuilderDoneButton : MonoBehaviour
{
    Button doneButton;

    LevelBuilder builder;

    private void Start() {
        doneButton = GetComponent<Button>();
        builder = GetComponentInParent<LevelBuilder>();
    }

    private void Update() {
        if(builder.more)
            doneButton.interactable = false;
        else if(builder.capped)
            doneButton.interactable = true;
        else
            doneButton.interactable = true;
    }

    public void SubmitCreation()
    {
        builder.DoneCreating();
    }
}
