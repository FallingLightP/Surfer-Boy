using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuilder : MonoBehaviour
{

    public Button[] myButtons;

    [SerializeField]PlayerMovement player;
    [SerializeField]GameObject goal;

    [SerializeField]Button done;

    int minimumTiles = 1;
    int maximumTiles = 5;
    int currentTiles = 0;

    public bool more = true;
    public bool capped = false;

    Vector3 tilePosition;

    private void Awake() {
        GameManager.originalMode = false;
    }

    private void Start() {
        player.movementOverhaul = true;
        GameManager.originalMode = false;
        myButtons = GetComponentsInChildren<Button>();
    }

    public void AddNewPart(int i)
    {
        if(!capped)
        {
            Instantiate(GameManager.levelCreatorTiles[i], tilePosition, Quaternion.identity);
            currentTiles ++;
            tilePosition += Vector3.forward * 50f;
            if(currentTiles >= minimumTiles)
                more = false;
            if(currentTiles == maximumTiles)
                capped = true;
        }
    }

    public void DoneCreating()
    {
        Instantiate(goal, tilePosition, Quaternion.identity);
        foreach(Button b in myButtons)
        {
            b.transform.LeanScale(Vector3.zero, 0.25f).setEase(LeanTweenType.easeSpring);
        }
        player.movementOverhaul = false;
    }
}
