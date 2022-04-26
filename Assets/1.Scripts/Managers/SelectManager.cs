using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public static TankSO SelectedTank; 
    public static MapSO SelectedMap;

    #region Singleton
    public static SelectManager Instance { get; private set; }


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnDestroy()
    {
        Instance = null;
    }
    #endregion

    public List<TankSO> TankList = new List<TankSO>();
    public List<MapSO> MapList = new List<MapSO>();
    public List<Sprite> FlagList = new List<Sprite>();
    public Transform TankSpawn;



}
