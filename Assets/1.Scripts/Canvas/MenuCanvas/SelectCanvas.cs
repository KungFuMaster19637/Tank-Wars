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

    private float _maxHealth;
    private float _maxAmmoCapacity;
    private float _maxFirePower;
    private float _maxRateOfFire;
    private float _maxSpeed;

    [SerializeField] private Sprite[] _flags;
    public List<TankSO> TankList = new List<TankSO>();
    private int _currentSelectedTankIndex;


    public void RightButton()
    {
        if (_currentSelectedTankIndex + 1 >= TankList.Count)
        {
            _currentSelectedTankIndex = 0;
        }
        else
        {
            _currentSelectedTankIndex++;
        }
    }

    public void LeftButton()
    {
        if (_currentSelectedTankIndex - 1 <= -1)
        {
            _currentSelectedTankIndex = TankList.Count;
        }
        else
        {
            _currentSelectedTankIndex--;
        }
    }

    public void RefreshUI(int currentTank)
    {
        TankSO tankSelected = TankList[currentTank];
        //Tank Name and Flag
        _tankNameText.text = tankSelected.VehicleName.ToString();
        _tankFaction.sprite = GetTankFlag(tankSelected);

        //Tank stats
        _healthText.text = tankSelected.MaxHealth.ToString();
        _ammoCapacityText.text = tankSelected.AmmoCapacity.ToString();
        _firepowerText.text = tankSelected.FirePower.ToString();
        _rateOfFireText.text = tankSelected.RateOfFire.ToString();
        _speedAmount.text = tankSelected.MaxMovementSpeed.ToString();

        //Tank bars
        _healthBar.fillAmount = GetStatsRatio(tankSelected.MaxHealth, _maxHealth);
        _ammoCapacityBar.fillAmount = GetStatsRatio(tankSelected.AmmoCapacity, _maxAmmoCapacity);
        _firepowerBar.fillAmount = GetStatsRatio(tankSelected.FirePower, _maxFirePower);
        _rateOfFireBar.fillAmount = GetStatsRatio(tankSelected.RateOfFire, _maxRateOfFire);
        _speedBar.fillAmount = GetStatsRatio(tankSelected.MaxMovementSpeed, _maxSpeed);
    }

    private Sprite GetTankFlag(TankSO currentTank)
    {
        switch(currentTank.VehicleFaction)
        {
            case Faction.China:
                return _flags[0];
            case Faction.Germany:
                return _flags[1];
            case Faction.Italy:
                return _flags[2];
            case Faction.Japan:
                return _flags[3];
            case Faction.Russia:
                return _flags[4];
            case Faction.UK:
                return _flags[5];
            case Faction.USA:
                return _flags[6];
            default:
                return null;
        }
    }

    private float GetStatsRatio(float currentStat, float maxStat)
    {
        return maxStat / currentStat;
    }

}
