using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectCanvas : AnimatedCanvasVirtual
{
    [Header("Tank Info")]
    [SerializeField] private TMP_Text _tankNameText;
    [SerializeField] private Image _tankFaction;

    [Header("Stats Text")]
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _ammoCapacityText;
    [SerializeField] private TMP_Text _firepowerText;
    [SerializeField] private TMP_Text _rateOfFireText;
    [SerializeField] private TMP_Text _speedAmount;

    [Header("Stats Bar")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _ammoCapacityBar;
    [SerializeField] private Image _firepowerBar;
    [SerializeField] private Image _rateOfFireBar;
    [SerializeField] private Image _speedBar;

    private float _maxHealth = 1200;
    private float _maxAmmoCapacity = 12;
    private float _maxFirePower = 200;
    private float _maxRateOfFire = 5;
    private float _maxSpeed = 30;

    private GameObject _currentTankGO;
    private int _currentSelectedTankIndex;

    private void Awake()
    {
        //Default 0 
        _currentSelectedTankIndex = 0;
        RefreshGO(_currentSelectedTankIndex);
        RefreshUI(_currentSelectedTankIndex);
    }

    public void RightButton()
    {
        if (_currentSelectedTankIndex + 1 >= SelectManager.Instance.TankList.Count)
        {
            _currentSelectedTankIndex = 0;
        }
        else
        {
            _currentSelectedTankIndex++;
        }
        RefreshUI(_currentSelectedTankIndex);
        RefreshGO(_currentSelectedTankIndex);
    }

    public void LeftButton()
    {
        if (_currentSelectedTankIndex - 1 <= -1)
        {
            _currentSelectedTankIndex = SelectManager.Instance.TankList.Count - 1;
        }
        else
        {
            _currentSelectedTankIndex--;
        }
        RefreshUI(_currentSelectedTankIndex);
        RefreshGO(_currentSelectedTankIndex);
    }
    public void ChooseButton()
    {
        SelectManager.SelectedTank = SelectManager.Instance.TankList[_currentSelectedTankIndex];
        MainFlowManager.Instance.OnChooseTankButton();
    }

    public void BackButton()
    {
        SelectManager.SelectedTank = null;
        MainFlowManager.Instance.OnBackToMainButton();
    }

    private void RefreshUI(int currentTank)
    {
        TankSO tankSelected = SelectManager.Instance.TankList[currentTank];
        //Tank Name and Flag
        _tankNameText.text = tankSelected.VehicleName.ToString();
        _tankFaction.sprite = GetTankFlag(tankSelected);

        //Tank stats
        _healthText.text = "Health: " + tankSelected.MaxHealth.ToString();
        _ammoCapacityText.text = "Ammo Capacity: " + tankSelected.AmmoCapacity.ToString();
        _firepowerText.text = "Firepower: " + tankSelected.FirePower.ToString();
        _rateOfFireText.text = "Rate Of Fire: " + tankSelected.RateOfFire.ToString();
        _speedAmount.text = "Speed: " + tankSelected.MaxMovementSpeed.ToString();

        //Tank bars
        _healthBar.fillAmount = GetStatsRatio(tankSelected.MaxHealth, _maxHealth);
        _ammoCapacityBar.fillAmount = GetStatsRatio(tankSelected.AmmoCapacity, _maxAmmoCapacity);
        _firepowerBar.fillAmount = GetStatsRatio(tankSelected.FirePower, _maxFirePower);
        _rateOfFireBar.fillAmount = GetStatsRatio(Mathf.Pow(tankSelected.RateOfFire, -1), _maxRateOfFire);
        _speedBar.fillAmount = GetStatsRatio(tankSelected.MaxMovementSpeed, _maxSpeed);
    }

    private void RefreshGO(int currentTank)
    {
        if (_currentTankGO != null) Destroy(_currentTankGO);
        TankSO tankSelected = SelectManager.Instance.TankList[currentTank];
        _currentTankGO = Instantiate(tankSelected.VehiclePrefab, SelectManager.Instance.TankSpawn);

        //Don't allow tank to move;
        if (_currentTankGO.GetComponent<TankController>() && _currentTankGO.GetComponent<TankMovement>())
        {            
            _currentTankGO.GetComponent<TankController>().enabled = false;
            _currentTankGO.GetComponent<TankMovement>().enabled = false;
            _currentTankGO.GetComponent<TankController>().HideHealthbar();
        }
    }

    private Sprite GetTankFlag(TankSO currentTank)
    {
        switch(currentTank.VehicleFaction)
        {
            case Faction.France:
                return SelectManager.Instance.FlagList[0];
            case Faction.Germany:
                return SelectManager.Instance.FlagList[1];
            case Faction.Italy:
                return SelectManager.Instance.FlagList[2];
            case Faction.Japan:
                return SelectManager.Instance.FlagList[3];
            case Faction.Russia:
                return SelectManager.Instance.FlagList[4];
            case Faction.UK:
                return SelectManager.Instance.FlagList[5];
            case Faction.USA:
                return SelectManager.Instance.FlagList[6];
            default:
                return null;
        }
    }

    private float GetStatsRatio(float currentStat, float maxStat)
    {
        return currentStat / maxStat;
    }

}
