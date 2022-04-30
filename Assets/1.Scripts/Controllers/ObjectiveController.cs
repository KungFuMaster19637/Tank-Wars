using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveController : MonoBehaviour
{
    public static event System.Action<int> e_ObjectiveCompleted = delegate { };
    [SerializeField] private int _objectiveID;

    public void ObjectiveCompleted()
    {
        e_ObjectiveCompleted(_objectiveID);
    }
}
