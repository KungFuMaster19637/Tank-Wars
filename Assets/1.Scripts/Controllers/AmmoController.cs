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

    private void OnCollisionEnter(Collision collision)
    {
        //If building hit;
        if (collision.transform.GetComponent<BuildingController>())
        {
            collision.transform.GetComponent<BuildingController>().TakeDamage(SelectManager.SelectedTank.FirePower);
            TargetHit();
        }

        //If enemy tank hit;
        if (collision.transform.GetComponent<TankController>())
        {
            Debug.Log("tank hit");
            collision.transform.GetComponent<TankController>().TakeDamage(SelectManager.SelectedTank.FirePower);
            TargetHit();
        }
    }

    private void TargetHit()
    {
        //Later add particles
        Destroy(gameObject);
    }

    public Transform GetFirePoint()
    {
        return _ammoSO.FirePointRotation;
    }
}
