using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScreenController : IExitScreen
{
    private ExitScreenUI _ui;
    private IGameplayInput _gameplayInput;

    public ExitScreenController(ExitScreenUI _uiInstance ,IGameplayInput gameplayInput)
    {
        _ui = _uiInstance;
        _gameplayInput = gameplayInput;
        _ui.Hide();
        _ui.OnClose += _gameplayInput.EnableInput;
    }

    public void Open()
    {
        _ui.Show();
        _gameplayInput.DisableInput();
    }
}
