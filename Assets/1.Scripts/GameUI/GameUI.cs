using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Transform _ammoSpawnUI;
    [SerializeField] private TMP_Text _healthText;

    private int _ammoIndex;

    private void Awake()
    {
        InitTankAmmoUI();

        TankController.e_TankShot += OnTankShot;
        TankController.e_TankReloaded += OnTankReload;
    }


    private void OnDestroy()
    {
        TankController.e_TankShot -= OnTankShot;
        TankController.e_TankReloaded -= OnTankReload;
    }

    private void OnTankShot()
    {
        _ammoSpawnUI.GetChild(_ammoIndex).gameObject.SetActive(false);
        _ammoIndex++;
    }
    private void OnTankReload()
    {
        foreach (Transform ammo in _ammoSpawnUI)
        {
            ammo.gameObject.SetActive(true);
        }
        _ammoIndex = 0;
    }

    private void InitTankAmmoUI()
    {
        for (int i = 0; i < SelectManager.SelectedTank.AmmoCapacity; i++)
        {
            Instantiate(SelectManager.SelectedTank.Ammo.AmmoUI, _ammoSpawnUI);
        }
        _ammoIndex = 0;
    }
}
