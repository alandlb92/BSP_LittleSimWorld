using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject _pivot;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonExit;

    public event Action OnClose;

    private void Start()
    {
        buttonContinue.onClick.AddListener(CloseScreen);
        buttonExit.onClick.AddListener(ExitGame);
    }

    public void Hide()
    {
        _pivot.SetActive(false);
        OnClose?.Invoke();
    }

    public void Show()
    {
        _pivot.SetActive(true);
    }

    private void CloseScreen()
    {
        Hide();
    }

    private void ExitGame()
    {
        Debug.Log("Quit request");
        Application.Quit();
    }
}
