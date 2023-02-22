using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private Canvas _mainCanvas;

    public UIManager(Canvas mainCanvas, StartUI startUI_Referece, IStartOptions startOptions)
    {
        this._mainCanvas = mainCanvas;
        GameObject.Instantiate(startUI_Referece, _mainCanvas.transform).Configure(startOptions);
    }
}
