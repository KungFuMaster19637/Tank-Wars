using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankSO", menuName = "ScriptableObjects/TankSO", order = 2)]
public class TankSO : VehicleSO
{
    public float MaxMovementSpeed;
    public float MaxRotationSpeed;
    public float FireRate;
    public float FirePower;


}
