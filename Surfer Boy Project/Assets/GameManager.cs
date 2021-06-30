using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject[] curvedTiles;

    public static int currentLevel = 1;

    public LevelSettings[] level;
    public CompleteLevel[] premadeLevels;

    Vector3 playerStart;
    Vector3 playerStartRotation = Vector3.zero;

    [SerializeField]Canvas canvas;

    private void Awake() {

    }

    private void Start() {
        currentLevel --;

        //level[currentLevel].tileUntilCurve = Random.Range(0, 4);
        //level[currentLevel].totalTiles = Random.Range(0, 8);

        //StartCoroutine(GENERATELEVEL());
    }

    public void Generate()
    {
        StartCoroutine(GENERATELEVEL());
    }

    public void PreMade()
    {
        StartCoroutine(LOADLEVEL());
    }

    IEnumerator GENERATELEVEL()
    {
        
        Vector3 tilePosition = Vector3.zero;
        Quaternion tileRotation = Quaternion.Euler(0,0,0);

        Vector3 tileOffset = new Vector3(0,0,50);
        Vector3 curveOffset = new Vector3(15,0,15);
        Quaternion curveRotation = Quaternion.Euler(0,90,0);

        int maxTiles = level[currentLevel].totalTiles;
        int currentTile = 0;

        


        GameObject completeLevel = Instantiate(new GameObject());
        completeLevel.transform.position = Vector3.zero;
        while(maxTiles > currentTile)
        {
            if(currentTile == level[currentLevel].tileUntilCurve)
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
                    print(tilePosition);
            }
            else
            {
                Instantiate(
                    tiles[Random.Range(0, tiles.Length)],
                    tilePosition,
                    tileRotation,
                    completeLevel.transform
                );
                tilePosition += tileOffset;
            }
            currentTile++;
            yield return null;
            canvas.enabled = false;
        }
        
    }

    IEnumerator LOADLEVEL()
    {
        Vector3 tilePosition = Vector3.zero;
        Quaternion tileRotation = Quaternion.Euler(0,0,0);

        CompleteLevel myLevel = premadeLevels[currentLevel];

        Vector3 tileOffset = new Vector3(0,0,50);
        Vector3 curveOffset = new Vector3(15,0,15);
        Quaternion curveRotation = Quaternion.Euler(0,90,0);

        int maxTiles = myLevel.levelParts.Length;
        print(premadeLevels.Length);
        int currentTile = 0;

        GameObject levelParent = Instantiate(new GameObject());
        levelParent.transform.position = Vector3.zero;

        while(maxTiles > currentTile)
        {
            if(myLevel.levelParts[currentTile].tag == "Curve")
            {
                Instantiate
                (
                    myLevel.levelParts[currentTile],
                    tilePosition,
                    tileRotation,
                    levelParent.transform
                );
                    tileOffset = new Vector3(50,0,0);
                    tilePosition += curveOffset;
                    tileRotation = curveRotation;
            }
            else
            {
                Instantiate(
                    myLevel.levelParts[currentTile],
                    tilePosition,
                    tileRotation,
                    levelParent.transform
                );
                tilePosition += tileOffset;
            }
            currentTile++;
            yield return null;
        }
        
    }
}
