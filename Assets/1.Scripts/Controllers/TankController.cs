using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public static event System.Action e_TankShot = delegate { }; 
    public static event System.Action e_TankReloaded = delegate { };

    [SerializeField] private TankSO _tankSO;
    [SerializeField] private Transform _firePoint;

    private int _currentAmmo;
    private Coroutine _shootLock;

    private void Awake()
    {
        Reload();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

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
}
