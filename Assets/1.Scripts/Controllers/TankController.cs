using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public static event System.Action e_TankShot = delegate { }; 
    public static event System.Action e_TankReloaded = delegate { };
    public static event System.Action e_TakenDamage = delegate { };

    [SerializeField] private TankSO _tankSO;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Image _healthbar;

    [SerializeField] private ObjectiveController _objectiveController;
    private int _currentAmmo;
    private Coroutine _shootLock;
    public bool PlayerLock = false;

    private void Awake()
    {
        Init();
        Reload();
    }

    private void Update()
    {
        if (PlayerLock == false) return;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(7f);
        }
    }

    private void Init()
    {
        _tankSO.CurrentHealth = _tankSO.MaxHealth;
    }
    public void HideHealthbar()
    {
        _healthbar.gameObject.SetActive(false);
    }


    #region Shooting
    private void Shoot()
    {
        if (_shootLock != null) { return; }

        _shootLock = StartCoroutine(IE_Shoot());
    }
    private IEnumerator IE_Shoot()
    {
        if (_currentAmmo - 1 > 0)
        {
            AmmoUsed();
            yield return new WaitForSeconds(_tankSO.RateOfFire);
        }
        else if (_currentAmmo - 1 == 0)
        {
            AmmoUsed();
            Reload();
            yield return new WaitForSeconds(2f);
            e_TankReloaded();
        }
        _shootLock = null;
    }

    private void AmmoUsed()
    {
        _tankSO.Ammo.FirePointRotation = transform;
        Instantiate(_tankSO.Ammo.AmmoPrefab, _firePoint.position, transform.rotation);
        e_TankShot();
        _currentAmmo--;
    }

    private void Reload()
    {
        _currentAmmo = _tankSO.AmmoCapacity;
    }
    #endregion

    #region Damage & Health
    private void RefreshHealthbar()
    {
        _healthbar.fillAmount = _tankSO.CurrentHealth / _tankSO.MaxHealth;
    }

    public void TakeDamage(float incomingDamage)
    {
        if (_tankSO.CurrentHealth - incomingDamage <= 0)
        {
            TankDestroyed();
            if (PlayerLock == true)
            {
                //Game over
                e_TakenDamage();
            }
        }
        else
        {
            _tankSO.CurrentHealth -= incomingDamage;
            RefreshHealthbar();
            if (PlayerLock == true)
            {
                Debug.Log("this tnk is yours");
                e_TakenDamage();
            }
        }
    }

    private void TankDestroyed()
    {
        if (_objectiveController)
        {
            _objectiveController.ObjectiveCompleted();
        }
        Destroy(gameObject);
        //play death particles;
    }

    #endregion
}
