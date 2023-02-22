using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IStartOptions
{
    [Header("Prefabs")]
    [SerializeField] private CharacterComponent PlayerPrefab_Referece;
    [SerializeField] private StartUI StartUI_Referece;

    [Header("References")]
    [SerializeField] private Camera _startCamera;
    [SerializeField] private Transform _gameStartPoint;
    [SerializeField] private Canvas _mainCanvas;

    private UIManager _uiManager;
    private CharacterComponent _player;

    public void Awake()
    {
        _startCamera.transform.position = new Vector3(_gameStartPoint.position.x, _gameStartPoint.position.y, _startCamera.transform.position.z);
        _uiManager = new UIManager(_mainCanvas, StartUI_Referece, this);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        _player = Instantiate(PlayerPrefab_Referece, _gameStartPoint);
        _player.InitializePlayer(_mainCanvas.transform, _gameStartPoint.position);
        _startCamera.gameObject.SetActive(false);
    }
}
