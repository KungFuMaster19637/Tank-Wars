using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Transform _ammoSpawnUI;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TMP_Text _healthText;

    private int _ammoIndex;

    private void Awake()
    {
        InitTankAmmoUI();
        OnDamageTaken();

        TankController.e_TankShot += OnTankShot;
        TankController.e_TankReloaded += OnTankReload;
        TankController.e_TakenDamage += OnDamageTaken;
    }


    private void OnDestroy()
    {
        TankController.e_TankShot -= OnTankShot;
        TankController.e_TankReloaded -= OnTankReload;
    }
    private void InitTankAmmoUI()
    {
        for (int i = 0; i < SelectManager.SelectedTank.AmmoCapacity; i++)
        {
            Instantiate(SelectManager.SelectedTank.Ammo.AmmoUI, _ammoSpawnUI);
        }
        _ammoIndex = 0;
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

    private void OnDamageTaken()
    {
        float currentHealth = SelectManager.SelectedTank.CurrentHealth;
        float maxHealth = SelectManager.SelectedTank.MaxHealth;
        _healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        _healthBar.fillAmount = currentHealth / maxHealth;
    }
}
