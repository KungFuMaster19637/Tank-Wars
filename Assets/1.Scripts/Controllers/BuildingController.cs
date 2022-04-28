using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] private DestroySO _destroySO;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _destroySO.CurrentHealth = _destroySO.MaxHealth;
    }

    public void TakeDamage(float incomingDamage)
    {
        if (_destroySO.CurrentHealth - incomingDamage <= 0)
        {
            BuildingDestroyed();
        }
        else
        {
            _destroySO.CurrentHealth -= incomingDamage;
        }
    }

    private void BuildingDestroyed()
    {

    }
}
