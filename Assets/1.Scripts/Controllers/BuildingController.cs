using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingController : MonoBehaviour
{
    [SerializeField] private DestroySO _destroySO;
    [SerializeField] private Image _healthbar;
    [SerializeField] private ParticleSystem _destructionParticles;

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
            RefreshHealthbar();
        }
    }

    private void RefreshHealthbar()
    {
        _healthbar.fillAmount = _destroySO.CurrentHealth / _destroySO.MaxHealth;
    }

    private void BuildingDestroyed()
    {
        Destroy(gameObject);
    }
}
