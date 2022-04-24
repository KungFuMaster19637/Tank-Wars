using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    #region Singleton
    public static SelectManager Instance { get; private set; }


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

    public List<TankSO> TankList = new List<TankSO>();
    public Transform TankSpawn;



}
