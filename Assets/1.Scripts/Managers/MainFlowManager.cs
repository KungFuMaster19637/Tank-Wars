using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum MainSceneState
{
    None, 
    Main, 
    Select,
    Map,
    Multiplayer,
    Options
}

[Serializable]
public class MainSceneStateCanvas
{
    public MainSceneState State;
    public AnimatedCanvasVirtual AnimatedCanvas;
}
public class MainFlowManager : MonoBehaviour
{
    public static MainSceneState CurrentState;
    public static event Action<MainSceneState, MainSceneState> e_CloseFlowState = delegate { };
    public static event Action<MainSceneState, MainSceneState> e_SwitchFlowState = delegate { };
    public static event Action<MainSceneState, MainSceneState> e_OpenedFlowState = delegate { };

    [Header("Canvas States")]
    [SerializeField] private MainSceneStateCanvas[] _stateCanvasses;

    #region Singleton
    public static MainFlowManager Instance { get; private set; }


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

    private void Start()
    {
        SetMainFlowState(MainSceneState.Main);
    }

    #region Flow State
    private void SetMainFlowState(MainSceneState newState)
    {
        if (newState == CurrentState) { Debug.LogWarning($"SetFlowState {newState} while already in {newState}"); return; }
        StartCoroutine(IE_SetFlowState(newState));
    }

    private IEnumerator IE_SetFlowState(MainSceneState newState)
    {
        MainSceneState oldState = CurrentState;
        e_CloseFlowState(oldState, newState);

        //IF animations needed, remove if 
        if (GetAnimatedCanvasForState(oldState) != null)
        {
            yield return GetAnimatedCanvasForState(oldState).OnClose();
        }

        CurrentState = newState;

        e_SwitchFlowState(oldState, newState);

        if (GetAnimatedCanvasForState(newState) != null)
        {
            yield return GetAnimatedCanvasForState(newState).OnOpen();
        }

        e_OpenedFlowState(oldState, newState);

        yield return null;
    }
    private AnimatedCanvasVirtual GetAnimatedCanvasForState(MainSceneState state)
    {
        for (int i = 0; i < _stateCanvasses.Length; i++)
        {
            if (_stateCanvasses[i].State == state)
            {
                return _stateCanvasses[i].AnimatedCanvas;
            }
        }
        return null;
    }

    #endregion

    #region Buttons

    #region Main Menu
    public void OnCampaignButton()
    {
        SetMainFlowState(MainSceneState.Select);
    }

    public void OnMultiplayerButton()
    {
        SetMainFlowState(MainSceneState.Multiplayer);
    }
    public void OnOptionButton()
    {
        SetMainFlowState(MainSceneState.Options);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }

    #endregion

    #region Select Tank Menu
    public void OnChooseTankButton()
    {
        SetMainFlowState(MainSceneState.Map);
    }
    public void OnBackToMainButton()
    {
        SetMainFlowState(MainSceneState.Main);

    }

    #endregion

    #region Select Map Menu
    public void OnChooseMapButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnBackToSelect()
    {
        SetMainFlowState(MainSceneState.Select);
    }
    #endregion

    #endregion
}
