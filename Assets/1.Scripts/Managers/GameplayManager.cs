using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Transform _tankSpawnLocation;
    [SerializeField] private GameUI _gameUI;

    #region Singleton
    public static GameplayManager Instance { get; private set; }


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
    }


    private void OnDestroy()
    {
        Instance = null;
    }
    #endregion

    private void Init()
    {
        if (SelectManager.SelectedTank == null)
        {
            Instantiate(SelectManager.Instance.TankList[0].VehiclePrefab, _tankSpawnLocation);
        }
        else
        {
            Instantiate(SelectManager.SelectedTank.VehiclePrefab, _tankSpawnLocation);
        }
        Instantiate(_gameUI);
    }
}
