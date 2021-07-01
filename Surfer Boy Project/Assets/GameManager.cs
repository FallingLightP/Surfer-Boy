using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    public GameObject[] tiles;
    public GameObject[] curvedTiles;

    //Static reference of the tiles for use in the Level Builder
    public static GameObject[] levelCreatorTiles;

    public static GameObject goal;
    public GameObject goalTemp;

    public static int currentLevel = 0;
    public static bool originalMode = true;

    public LevelSequence[] levelSequences;

    public static int originalModeProgress = 0;

    Vector3 playerStart;
    Vector3 playerStartRotation = Vector3.zero;

    private void Awake() {
        gameManager = this;
        if(goalTemp != null && goal == null)
            goal = goalTemp;

        originalModeProgress = PlayerPrefs.GetInt("Progress");

        levelCreatorTiles = tiles;
    }

    private void Start() {
        //Scene Check, these functions only pass in the Generator Scene
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(originalMode)
                Generate();
            else
                StartCoroutine(RANDOMLEVEL());
        }
    }

    //If Original Mode is true, load pre generated Level
    public void OriginalMode()
    {
        originalMode = true;
    }

    //Else, Generate Random Level, doesn't affect original mode progress
    public void RandomMode()
    {
        originalMode = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //If there is the scriptable object already has level data, load level
    //Else generate level data in that scriptable objecy
    public void Generate()
    {
        if(levelSequences[currentLevel].mySequence.Count == 0)
            StartCoroutine(GENERATELEVEL());
        else
            StartCoroutine(LOADSEQUENCE());
    }

    public void RandomLevel()
    {
        originalMode = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator RANDOMLEVEL()
    {
        int maxTiles = Random.Range(4,8);
        int tilesUntilCurve = Random.Range(2,4);

        
        Vector3 tilePosition = Vector3.zero;
        Quaternion tileRotation = Quaternion.Euler(0,0,0);

        Vector3 tileOffset = new Vector3(0,0,50);
        Vector3 curveOffset = new Vector3(15,0,15);
        Quaternion curveRotation = Quaternion.Euler(0,90,0);

        int currentTile = 0;

        

        GameObject completeLevel = Instantiate(new GameObject());
        completeLevel.transform.position = Vector3.zero;
        while(maxTiles > currentTile)
        {
            if(currentTile == tilesUntilCurve)
            {
                
                Instantiate
                (
                    curvedTiles[Random.Range(0, curvedTiles.Length)],
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                );
                    tileOffset = new Vector3(50,0,0);
                    tilePosition += curveOffset;
                    tileRotation = curveRotation;
            }
            else
            {
                int tileIndex = Random.Range(0, tiles.Length);
                Instantiate(
                    tiles[tileIndex],
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                );
                tilePosition += tileOffset;
            }
            currentTile++;
            yield return null;
            if(currentTile == maxTiles)
            {
                Instantiate
                (
                    goal,
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                    //CHANGE THE COMPLETE LEVEL VARIABLE NAME
                );
            }
        }
    }

    IEnumerator GENERATELEVEL()
    {

        LevelSequence saveInstance = levelSequences[currentLevel];

        int maxTiles = Random.Range(4,8);
        int tilesUntilCurve = Random.Range(1,4);

        
        Vector3 tilePosition = Vector3.zero;
        Quaternion tileRotation = Quaternion.Euler(0,0,0);

        Vector3 tileOffset = new Vector3(0,0,50);
        Vector3 curveOffset = new Vector3(15,0,15);
        Quaternion curveRotation = Quaternion.Euler(0,90,0);

        //int maxTiles = level[currentLevel].totalTiles;
        int currentTile = 0;

        

        GameObject completeLevel = Instantiate(new GameObject());
        completeLevel.transform.position = Vector3.zero;
        while(maxTiles > currentTile)
        {
            if(currentTile == tilesUntilCurve)
            {
                
                Instantiate
                (
                    curvedTiles[Random.Range(0, curvedTiles.Length)],
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                );
                    tileOffset = new Vector3(50,0,0);
                    tilePosition += curveOffset;
                    tileRotation = curveRotation;

                saveInstance.mySequence.Add(0);
            }
            else
            {
                int tileIndex = Random.Range(0, tiles.Length);
                Instantiate(
                    tiles[tileIndex],
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                );
                tilePosition += tileOffset;
                saveInstance.mySequence.Add(tileIndex + 1);
            }
            currentTile++;
            yield return null;
            if(currentTile == maxTiles)
            {
                Instantiate
                (
                    goal,
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                    //CHANGE THE COMPLETE LEVEL VARIABLE NAME
                );
            }
        }
        
    }

    //Used to load pre-generated level data
    IEnumerator LOADSEQUENCE()
    {
        LevelSequence thisLevelSequence = levelSequences[currentLevel];

        int tilesUntilCurve = Random.Range(0,4);

        Vector3 tilePosition = Vector3.zero;
        Quaternion tileRotation = Quaternion.Euler(0,0,0);

        Vector3 tileOffset = new Vector3(0,0,50);
        Vector3 curveOffset = new Vector3(15,0,15);
        Quaternion curveRotation = Quaternion.Euler(0,90,0);

        int maxTiles = levelSequences[currentLevel].mySequence.Count;
        int currentTile = 0;

        

        GameObject completeLevel = Instantiate(new GameObject());
        completeLevel.transform.position = Vector3.zero;
        while(maxTiles > currentTile)
        {
            if(thisLevelSequence.mySequence[currentTile] == 0)
            {
                
                Instantiate
                (
                    curvedTiles[Random.Range(0, curvedTiles.Length)],
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                );
                tileOffset = new Vector3(50,0,0);
                tilePosition += curveOffset;
                tileRotation = curveRotation;
            }
            else
            {
                int tileIndex = thisLevelSequence.mySequence[currentTile];
                tileIndex--;
                print(tileIndex);
                Instantiate(
                    tiles[tileIndex],
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                );
                tilePosition += tileOffset;
            }
            currentTile++;
            yield return null;
            if(currentTile == maxTiles)
            {
                Instantiate
                (
                    goal,
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                    //CHANGE THE COMPLETE LEVEL VARIABLE NAME
                );
            }
        }
    }

}
