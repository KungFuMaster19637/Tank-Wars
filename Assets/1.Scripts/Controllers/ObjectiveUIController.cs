using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _objectiveDescription;
    [SerializeField] private TMP_Text _objectiveCount;
    [SerializeField] private GameObject _completionCheck;

    private int maxCount;
    public void InitDescription(string description, int objectiveCount)
    {
        _objectiveDescription.text = description;
        maxCount = objectiveCount;
        if (objectiveCount > 1)
        {
            _objectiveCount.text = "0/" + objectiveCount;
        }
        else
        {
            _objectiveCount.gameObject.SetActive(false);
        }
    }

    public void OnCountChanged(int currentCount)
    {
        _objectiveCount.text = currentCount + "/" + maxCount; 
    }

    public void ObjectiveCompleted()
    {
        _completionCheck.SetActive(true);
    }
}
