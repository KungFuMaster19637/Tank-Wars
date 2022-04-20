using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AmmoSO", menuName = "ScriptableObjects/AmmoSO", order = 3)]
public class AmmoSO : ScriptableObject
{
    public float TravelSpeed;
    public Transform FirePointRotation;
    public GameObject AmmoPrefab;
    public ParticleSystem ImpactParticles;
}
