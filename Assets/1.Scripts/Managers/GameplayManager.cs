using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Transform _tankSpawnLocation;
    [SerializeField] private GameUI _gameUI;

    private void Awake()
    {
        Init();
    }

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
