using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IStartOptions
{
    [Header("Prefabs")]
    [SerializeField] private CharacterComponent PlayerPrefab_Referece;

    [Header("References")]
    [SerializeField] private Camera _startCamera;
    [SerializeField] private Transform _gameStartPoint;
    [SerializeField] private UIManager _uiManager;

    private CharacterComponent _player;

    public void Awake()
    {
        _startCamera.transform.position = new Vector3(_gameStartPoint.position.x, _gameStartPoint.position.y, _startCamera.transform.position.z);
        _uiManager?.ShowStartUI(this);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        _player = Instantiate(PlayerPrefab_Referece, _gameStartPoint.position, _gameStartPoint.rotation);
        _startCamera.gameObject.SetActive(false);
        _uiManager?.ShowCustomizeUI(_player.ICustomize, ReadyToPlay);
        _uiManager?.ConfigurePlayerUIS(_player.IInput, _player.ICustomize, _player.IData);
        _player.InitializePlayer(_uiManager?.GetCanvasTransform(), _gameStartPoint.position, _uiManager.IDialog, _uiManager.IInventory, _uiManager.IStore);
        _player.ICamera.SetCameraDistance(3);
        _player.IInput.DisableInput();
    }

    public void ReadyToPlay()
    {
        _player.IInput.EnableInput();
        _player.ICamera.SetCameraDistance(6);
        _player.SetInitializeData();
    }
}
