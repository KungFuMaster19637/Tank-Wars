using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Ammo")]
    [SerializeField] private Transform _ammoSpawnUI;

    [Header("Health")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private TMP_Text _healthText;

    [Header("Objective")]
    public Transform _objectiveHolder;
    [SerializeField] private ObjectiveUIController[] _objectiveUIs;

    

    private int _ammoIndex;

    private void Awake()
    {
        InitTankAmmoUI();
        OnDamageTaken();

        TankController.e_TankShot += OnTankShot;
        TankController.e_TankReloaded += OnTankReload;
        TankController.e_TakenDamage += OnDamageTaken;
        ObjectiveController.e_ObjectiveCompleted += OnObjectiveCompleted;
    }


    private void OnDestroy()
    {
        TankController.e_TankShot -= OnTankShot;
        TankController.e_TankReloaded -= OnTankReload;
        TankController.e_TakenDamage -= OnDamageTaken;
        ObjectiveController.e_ObjectiveCompleted -= OnObjectiveCompleted;

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

    private void OnObjectiveCompleted(int objectiveID)
    {
         ObjectiveSO currentObjective = ObjectiveManager.Instance.GetObjectiveSO();
        if (currentObjective.Objectives[objectiveID].ObjectiveMaxCount > 1)
        {
            currentObjective.Objectives[objectiveID].ObjectiveCurrentCount++;
            _objectiveHolder.GetChild(objectiveID).GetComponent<ObjectiveUIController>().OnCountChanged(currentObjective.Objectives[objectiveID].ObjectiveCurrentCount);
            if (currentObjective.Objectives[objectiveID].ObjectiveCurrentCount == currentObjective.Objectives[objectiveID].ObjectiveMaxCount)
            {
                ObjectiveManager.Instance.OnObjectiveCompleted(objectiveID);
                _objectiveHolder.GetChild(objectiveID).GetComponent<ObjectiveUIController>().ObjectiveCompleted();
            }
        }
        else
        {
            ObjectiveManager.Instance.OnObjectiveCompleted(objectiveID);
            _objectiveHolder.GetChild(objectiveID).GetComponent<ObjectiveUIController>().ObjectiveCompleted();
        }

        //_objectiveUIs[objectiveID].ObjectiveCompleted();
    }
}
