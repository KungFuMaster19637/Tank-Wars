using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Faction
{
    China,
    Germany,
    Italy,
    Japan,
    Russia,
    UK,
    USA
}

[CreateAssetMenu(fileName = "VehicleSO", menuName = "ScriptableObjects/VehicleSO", order = 1)]
public class VehicleSO : ScriptableObject
{
    public string VehicleName;
    public Faction VehicleFaction;
    public GameObject VehiclePrefab;
    public float MaxHealth;

    public GameObject RuntimeGO;

}
