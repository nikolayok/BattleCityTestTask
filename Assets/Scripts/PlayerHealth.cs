using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 3;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;
    private GameOverEvents _gameOverEvents;

    private void Start() 
    {
        _gameOverEvents = GameObject.FindWithTag("GameOverEvents").GetComponent<GameOverEvents>();
    }

    public int GetCurrentHealth()
    {
        return _health;
    }

    public void RemoveHealth()
    {
        --_health;

        if (_health <= 0)
        {
            GameOver();
        }
        else
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
    }

    private void GameOver()
    {
        _gameOverEvents.ShowGameOverCanvas();
    }
}
