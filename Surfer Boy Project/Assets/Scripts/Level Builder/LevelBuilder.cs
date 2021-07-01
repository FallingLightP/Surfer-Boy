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

    //Function invoked on button press, buttons lock themselves out if maximum tile count is matched, that is done locally in said button
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

    //Instantiates Goal Tile and starts level, is locked while the minimum requirement of tiles is not met
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
