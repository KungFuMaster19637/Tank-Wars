using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
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
        if (_currentAmmo > 0)
        {
            _tankSO.Ammo.FirePointRotation = transform;
            Instantiate(_tankSO.Ammo.AmmoPrefab, _firePoint.position, transform.rotation);
            _currentAmmo--;
            yield return new WaitForSeconds(_tankSO.RateOfFire);
        }
        else
        {
            Reload();
            yield return new WaitForSeconds(2f);
        }
        _shootLock = null;
    }

    private void Reload()
    {
        _currentAmmo = _tankSO.AmmoCapacity;
    }
}
