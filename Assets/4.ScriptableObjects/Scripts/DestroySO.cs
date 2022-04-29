using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DestroySO", menuName = "ScriptableObjects/DestroySO", order = 5)]

public class DestroySO : ScriptableObject
{
    public float CurrentHealth;
    public float MaxHealth;
}
