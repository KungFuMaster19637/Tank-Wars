using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _objectiveDescription;
    [SerializeField] private GameObject _completionCheck;

    public void InitDescription(string description)
    {
        _objectiveDescription.text = description;
    }

    public void ObjectiveCompleted()
    {
        _completionCheck.SetActive(true);
    }
}
