using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private IStartOptions _options;

    public void Configure(IStartOptions startOptions)
    {
        _options = startOptions;
        _startButton.onClick.AddListener(_options.StartGame);
        _startButton.onClick.AddListener(() => { Destroy(gameObject); });
        _exitButton.onClick.AddListener(_options.ExitGame);
        _startButton.Select();
    }
}
