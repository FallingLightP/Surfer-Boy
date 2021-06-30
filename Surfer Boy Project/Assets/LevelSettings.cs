using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Settings")]
public class LevelSettings : ScriptableObject
{
    public int totalTiles;
    public int tileUntilCurve;
}
