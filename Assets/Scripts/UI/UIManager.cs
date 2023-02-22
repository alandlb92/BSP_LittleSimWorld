using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("UI Prefabs")]
    [SerializeField] private StartUI StartUI_Referece;
    [SerializeField] private CustomizationUI CustomizationUI_Referece;

    [Header("References")]
    [SerializeField] private Canvas _mainCanvas;

    public void ShowStartUI(IStartOptions IStartOptions)
    {
        Instantiate(StartUI_Referece, _mainCanvas.transform).Configure(IStartOptions);
    }

    public void ShowCustomizeUI(ICustomizeCharacter ICustomize)
    {
        Instantiate(CustomizationUI_Referece, _mainCanvas.transform).Configure(ICustomize);
    }

    public Transform GetCanvasTransform()
    {
        return _mainCanvas.transform;   
    }
}
