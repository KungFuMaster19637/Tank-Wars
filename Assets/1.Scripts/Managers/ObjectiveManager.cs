using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private ObjectiveSO _currentObjectiveSO;
    [SerializeField] private GameObject _objectiveUIPrefab;

    #region Singleton
    public static ObjectiveManager Instance { get; private set; }


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnDestroy()
    {
        Instance = null;
    }
    #endregion

    public void Init(GameObject spawnedUI)
    {
        for (int i = 0; i < _currentObjectiveSO.Objectives.Length; i++)
        {
            GameObject uiController = Instantiate(_objectiveUIPrefab, spawnedUI.GetComponent<GameUI>()._objectiveHolder);
            uiController.GetComponent<ObjectiveUIController>().InitDescription(_currentObjectiveSO.Objectives[i].Description);
        }
    }

}
