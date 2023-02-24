using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("UI Prefabs")]
    [SerializeField] private StartUI StartUI_Referece;
    [SerializeField] private CustomizationUI CustomizationUI_Referece;
    [SerializeField] private DialogUI DialogUI_Reference;

    [Header("References")]
    [SerializeField] private Canvas _mainCanvas;

    private DialogController _dialogController;

    public IDialog IDialog => _dialogController;

    public void ConfigurePlayerUIS(IGameplayInput _input)
    {        
        _dialogController = new DialogController(Instantiate(DialogUI_Reference, _mainCanvas.transform), _input);
    }

    private void Update()
    {
        _dialogController?.Update();
    }

    public void ShowStartUI(IStartOptions IStartOptions)
    {
        Instantiate(StartUI_Referece, _mainCanvas.transform).Configure(IStartOptions);
    }

    public void ShowCustomizeUI(ICustomizeCharacter ICustomize, Action onReady)
    {
        Instantiate(CustomizationUI_Referece, _mainCanvas.transform).Configure(ICustomize, onReady);
    }

    public Transform GetCanvasTransform()
    {
        return _mainCanvas.transform;   
    }
}
