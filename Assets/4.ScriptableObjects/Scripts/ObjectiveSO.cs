using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectiveSO", menuName = "ScriptableObjects/ObjectiveSO", order = 6)]
public class ObjectiveSO : ScriptableObject
{
    public ObjectiveObjects[] Objectives;
}

[System.Serializable]
public class ObjectiveObjects
{
    public int ObjectiveID;
    public string Description;
    public int ObjectiveCount;
    public bool Completed;

    public void HasCompletedObjective()
    {
        Completed = true;
    }
}
