using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSO", menuName = "ScriptableObjects/MapSO", order = 4)]
public class MapSO : ScriptableObject
{
    public string MapName;
    public Sprite MapSprite;
}
