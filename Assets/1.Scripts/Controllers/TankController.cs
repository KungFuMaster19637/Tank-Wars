using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankSO _tankSO;
    [SerializeField] private Transform _firePoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _tankSO.Ammo.FirePointRotation = transform;
        Instantiate(_tankSO.Ammo.AmmoPrefab, _firePoint.position, transform.rotation);
    }
}
