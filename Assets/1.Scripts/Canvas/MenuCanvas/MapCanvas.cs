using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapCanvas : AnimatedCanvasVirtual
{
    [SerializeField] private TMP_Text _mapNameText;
    [SerializeField] private Image _mapImage;

    private int _currentSelectedMapIdex;

    private void Awake()
    {
        _currentSelectedMapIdex = 0;
        RefreshMap(_currentSelectedMapIdex);
    }

    public void RightButton()
    {
        if (_currentSelectedMapIdex + 1 >= SelectManager.Instance.MapList.Count)
        {
            _currentSelectedMapIdex = 0;
        }
        else
        {
            _currentSelectedMapIdex++;
        }
        RefreshMap(_currentSelectedMapIdex);
    }

    public void LeftButton()
    {
        if (_currentSelectedMapIdex - 1 <= -1)
        {
            _currentSelectedMapIdex = SelectManager.Instance.MapList.Count - 1;
        }
        else
        {
            _currentSelectedMapIdex--;
        }
        RefreshMap(_currentSelectedMapIdex);
    }

    private void RefreshMap(int currentMap)
    {
        MapSO selectedMap = SelectManager.Instance.MapList[currentMap];
        _mapNameText.text = selectedMap.MapName;
        _mapImage.sprite = selectedMap.MapSprite;
    }
    
    public void ChooseButton()
    {
        SelectManager.SelectedMap = SelectManager.Instance.MapList[_currentSelectedMapIdex];
        MainFlowManager.Instance.OnChooseMapButton();
    }

    public void BackButton()
    {
        SelectManager.SelectedMap = null;
        MainFlowManager.Instance.OnBackToSelect();
    }

}
