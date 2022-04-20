using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField] private AmmoSO _ammoSO;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody.velocity = _ammoSO.TravelSpeed * GetFirePoint().forward;
    }
    public Transform GetFirePoint()
    {
        return _ammoSO.FirePointRotation;
    }
}
