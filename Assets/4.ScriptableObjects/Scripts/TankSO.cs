using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankSO", menuName = "ScriptableObjects/TankSO", order = 2)]
public class TankSO : VehicleSO
{
    public AmmoSO Ammo;
    public int AmmoCapacity;
    public float MoveForce;
    public float MaxMovementSpeed;
    public float MaxRotationSpeed;
    public float RateOfFire;
    public float FirePower;


}
